using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public int selectedMenu;

	public GameObject[] btn_object;
	private int nBtn;

	// Use this for initialization
	void Start ()
	{
		nBtn = btn_object.Length;
		OnSelect(btn_object[selectedMenu]);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			OnLeave(btn_object[selectedMenu]);
			selectedMenu = (selectedMenu + 1) % nBtn;
			OnSelect(btn_object[selectedMenu]);
		}

		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			OnLeave(btn_object[selectedMenu]);
			selectedMenu = (selectedMenu + nBtn - 1) % nBtn;
			OnSelect(btn_object[selectedMenu]);
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{
			ExecuteAction();
		}
	}

	void OnSelect(GameObject btn_object)
	{
		btn_object.GetComponent<SpriteRenderer>().color = new Color(0.75f,0.75f,1.0f);
	}

	void OnLeave(GameObject btn_object)
	{
		btn_object.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f);
	}

	void ExecuteAction()
	{
		if (selectedMenu == 2)
		{
			Debug.Log("Exiting...");
			Application.Quit();
		}
	}
}
