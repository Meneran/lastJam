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
<<<<<<< HEAD
        teleport1 = ObjectManager.Instance.GetGameObject(0, 0);
        //teleport2 = ObjectManager.Instance.GetGameObject();
        switch1 = ObjectManager.Instance.GetGameObject(0, 0);
        switch2 = ObjectManager.Instance.GetGameObject(0, 0);
        switch3 = ObjectManager.Instance.GetGameObject(0, 0);
        door = ObjectManager.Instance.GetGameObject(0, 0);
=======
        teleport1 = ObjectManager.Instance.GetGameObject(7, 9);
        teleport2 = ObjectManager.Instance.GetGameObject(12, 9);
        switch1 = ObjectManager.Instance.GetGameObject(18, 3);
        switch2 = ObjectManager.Instance.GetGameObject(6, 3);
        switch3 = ObjectManager.Instance.GetGameObject(12, 3);
        door = ObjectManager.Instance.GetGameObject(18, 12);
>>>>>>> origin/master
    }
	
	// Update is called once per frame
	void Update () {
        teleport1 = ObjectManager.Instance.GetGameObject(7, 9);
        teleport2 = ObjectManager.Instance.GetGameObject(12, 9);
        switch1 = ObjectManager.Instance.GetGameObject(18, 3);
        switch2 = ObjectManager.Instance.GetGameObject(6, 3);
        switch3 = ObjectManager.Instance.GetGameObject(12, 3);
        door = ObjectManager.Instance.GetGameObject(18, 12);

        if (PlayerManager.Instance.getPlayerCoord(0) == new Vector2(18, 3))
        {
            teleport1.GetComponent<TeleportTo>().activate();
        }
        else 
            teleport1.GetComponent<TeleportTo>().desactivate();

        if (switch2.GetComponent<ChangingTextureOnActivate>().isActive)
            teleport2.GetComponent<TeleportTo>().activate();
        else
            teleport2.GetComponent<TeleportTo>().desactivate();

        if (switch3.GetComponent<ChangingTextureOnActivate>().isActive)
            door.GetComponent<ChangingTextureOnActivate>().activate();
        else
            door.GetComponent<ChangingTextureOnActivate>().desactivate();
    }
}
