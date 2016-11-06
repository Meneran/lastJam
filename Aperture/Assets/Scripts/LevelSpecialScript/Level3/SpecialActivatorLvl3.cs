using UnityEngine;
using System.Collections;

public class SpecialActivatorLvl3 : MonoBehaviour {

    private GameObject switchLvl;
    private GameObject door;

	// Use this for initialization
	void Start () {
	    switchLvl = ObjectManager.Instance.GetGameObject(15,5);
        door = ObjectManager.Instance.GetGameObject(16, 6);
	}
	
	// Update is called once per frame
	void Update () {
	    if(switchLvl.GetComponent<ChangingTextureOnActivate>().isActive && door.GetComponent<SpecialLvl3Door>().conditionValidated)
        {
            door.GetComponent<Door>().activate();
        }
        else
        {
            door.GetComponent<Door>().desactivate();
        }
	}
}
