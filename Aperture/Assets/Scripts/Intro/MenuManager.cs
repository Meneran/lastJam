using UnityEngine;
using System.Collections;



public class MenuManager : MonoBehaviour {

	public enum StateMenu
	{
		Start,
		LevelSelector,
		Options
	};

	public int selectedMenu;

	public float timer;
	private float clock;

	public GameObject[] btn_object;
	public GameObject[] lvl_object;
	public GameObject fullHolder;
	
	private GameObject[] std_object;
	private int nBtn;
	private StateMenu state;

	private float lastAction;

	// Use this for initialization
	void Start ()
	{
		state = StateMenu.Start;

		Init(btn_object);
	}

	void Init(GameObject[] cObject)
	{
		std_object = cObject;
		selectedMenu = 0;

		nBtn = std_object.Length;
		OnSelect(std_object[selectedMenu]);
	}

	// Update is called once per frame
	void Update()
	{
		float displacement = -3.5f;

		if (clock > 0)
		{
			clock -= Time.deltaTime;

			if (state == StateMenu.Start)
			{
				fullHolder.transform.position = new Vector3(sinTransition(clock/timer) * displacement, 0, 0);
			}
			else if (state == StateMenu.LevelSelector)
			{
				fullHolder.transform.position = new Vector3(sinTransition(1 - clock / timer) * displacement, 0, 0);
			}
		}
		else
		{
			clock = 0;
			if (state == StateMenu.Start)
			{
				fullHolder.transform.position = new Vector3(0, 0, 0);
			}
			else if (state == StateMenu.LevelSelector)
			{
				fullHolder.transform.position = new Vector3(displacement, 0, 0);
			}
		}

		lastAction -= Time.deltaTime;

		if (lastAction < 0)
		{
			lastAction = 0;
		}

		if (lastAction <= 0)
		{

			if (InputManagerSc.Instance.downP1)
			{
				OnLeave(std_object[selectedMenu]);
				selectedMenu = (selectedMenu + 1) % nBtn;
				OnSelect(std_object[selectedMenu]);
				Action();
			}

			if (InputManagerSc.Instance.upP1)
			{
				OnLeave(std_object[selectedMenu]);
				selectedMenu = (selectedMenu + nBtn - 1) % nBtn;
				OnSelect(std_object[selectedMenu]);
				Action();
			}

			if (InputManagerSc.Instance.rightP1)
			{
				OnLeave(std_object[selectedMenu]);
				selectedMenu = (selectedMenu + 3) % nBtn;
				OnSelect(std_object[selectedMenu]);
				Action();
			}

			if (InputManagerSc.Instance.leftP1)
			{
				OnLeave(std_object[selectedMenu]);
				selectedMenu = (selectedMenu + nBtn - 3) % nBtn;
				OnSelect(std_object[selectedMenu]);
				Action();
			}

			if (InputManagerSc.Instance.act1P1)
			{
				OnLeave(std_object[selectedMenu]);
				ExecuteAction();
				Action();
			}

			if (InputManagerSc.Instance.act2P1)
			{
				ExecuteAction(0);
				Action();
			}
		}
	}

	void Action()
	{
		lastAction = 0.2f;
	}

	void OnSelect(GameObject btn_object)
	{
		btn_object.GetComponent<SpriteRenderer>().color = new Color(0.75f,0.75f,1.0f);
	}

	void OnLeave(GameObject btn_object)
	{
		btn_object.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
	}

	void ExecuteAction(int type = -1)
	{
		if (type == 0)
		{
			if (state != StateMenu.Start)
			{
				OnLeave(std_object[selectedMenu]);
				clock = timer;
				state = StateMenu.Start;
				Init(btn_object);
			}
		}
		else
		{
			switch (state)
			{
				case (StateMenu.Start):
			
					switch (selectedMenu)
					{
						case 0:
							Debug.Log("Goto Level Selector");
							clock = timer;
							state = StateMenu.LevelSelector;
							Init(lvl_object);
							
							break;
						case 2:
							Debug.Log("Exiting...");
							Application.Quit();
							break;
					}
					break;

				case (StateMenu.LevelSelector):
					GameManagerSc.Instance.level = selectedMenu+1;
					GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
					break;

			}
		}
	}

	float sinTransition(float x)
	{
		return 0.5f - 0.5f * Mathf.Cos(x * Mathf.PI);
	}
}
