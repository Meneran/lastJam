using UnityEngine;
using System.Collections;

public class OverlayManager : MonoBehaviour
{

	public int selectedMenu;
	public GameObject[] std_object;

	public Sprite sound_on;
	public Sprite sound_off;

	private float lastAction;

	private int nBtn;

	// Use this for initialization
	void Start()
	{
		selectedMenu = 0;
		nBtn = std_object.Length;
		OnSelect(std_object[selectedMenu]);
	}

	// Update is called once per frame
	void Update()
	{
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

			if (InputManagerSc.Instance.act1P1)
			{
				OnLeave(std_object[selectedMenu]);
				ExecuteAction(1);
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
		btn_object.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0.75f, 1.0f);
	}

	void OnLeave(GameObject btn_object)
	{
		btn_object.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
	}

	void ExecuteAction(int type = -1)
	{
		if (type == 1)
		{
			switch (selectedMenu)
			{
				case 0:
					GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
					break;
				case 1:
					GameManagerSc.Instance.sound = !GameManagerSc.Instance.sound;
					if (GameManagerSc.Instance.sound)
					{
						std_object[1].GetComponent<SpriteRenderer>().sprite = sound_on;
					}
					else
					{
						std_object[1].GetComponent<SpriteRenderer>().sprite = sound_off;
					}
					OnSelect(std_object[selectedMenu]);
					break;
				case 2:
					GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.MenuScene);
					break;
			}
		}
	}
}