using UnityEngine;
using System.Collections;

public class level1_teleport : MonoBehaviour {

    public GameObject door;
    public GameObject teleport1;
    public GameObject teleport2;
    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    // Use this for initialization
    void Start () {
        teleport1 = ObjectManager.Instance.GetGameObject(0, 0);
        teleport2 = ObjectManager.Instance.GetGameObject();
        switch1 = ObjectManager.Instance.GetGameObject(0, 0);
        switch2 = ObjectManager.Instance.GetGameObject(0, 0);
        switch3 = ObjectManager.Instance.GetGameObject(0, 0);
        door = ObjectManager.Instance.GetGameObject(0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (switch1.GetComponent<ChangingTextureOnActivate>().isActive)
            teleport1.GetComponent<ChangingTextureOnActivate>().activate();
        else 
            teleport1.GetComponent<ChangingTextureOnActivate>().desactivate();

        if (switch2.GetComponent<ChangingTextureOnActivate>().isActive)
            teleport2.GetComponent<ChangingTextureOnActivate>().activate();
        else
            teleport2.GetComponent<ChangingTextureOnActivate>().desactivate();

        if (switch3.GetComponent<ChangingTextureOnActivate>().isActive)
            door.GetComponent<ChangingTextureOnActivate>().activate();
        else
            door.GetComponent<ChangingTextureOnActivate>().desactivate();
    }
}
