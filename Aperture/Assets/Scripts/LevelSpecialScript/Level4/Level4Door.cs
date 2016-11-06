using UnityEngine;
using System.Collections;

public class Level4Door : MonoBehaviour {

    private GameObject light1;
    private GameObject light2;
    private GameObject door;

	// Use this for initialization
	void Start () {
        light1 = ObjectManager.Instance.GetGameObject(10, 11);
        light2 = ObjectManager.Instance.GetGameObject(12, 11);
        door = ObjectManager.Instance.GetGameObject(11, 12);
	}
	
	// Update is called once per frame
	void Update () {
	    if(light1.GetComponent<ChangingTextureOnActivate>().isActive && light2.GetComponent<ChangingTextureOnActivate>().isActive)
        {
            Debug.Log("activation");
            door.GetComponent<ChangingTextureOnActivate>().activate();
        } else
        {
            door.GetComponent<ChangingTextureOnActivate>().desactivate();
        }
	}
}
