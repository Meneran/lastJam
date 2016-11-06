using UnityEngine;
using System.Collections;

public class Level5 : MonoBehaviour {

    private bool[] boolArray;
    [SerializeField]
    private Vector2[] posArray;

    private GameObject door;

    // Use this for initialization
    void Start() {
        door = ObjectManager.Instance.GetGameObject(22, 6);
        boolArray = new bool[20];
        posArray = new Vector2[22] {
            new Vector2(5, 8),
            new Vector2(5, 7),
            new Vector2(5, 6),
            new Vector2(5, 5),
            new Vector2(5, 4),
            new Vector2(6, 4),
            new Vector2(7, 4),
            new Vector2(7, 5),
            new Vector2(7, 6),
            new Vector2(7, 7),
            new Vector2(7, 8),
            new Vector2(6, 8),
            new Vector2(8, 6),
            new Vector2(9, 6),
            new Vector2(11, 6),
            new Vector2(12, 6),
            new Vector2(14, 6),
            new Vector2(15, 6),
            new Vector2(16, 6),
            new Vector2(17, 6),
            new Vector2(18, 6),
            new Vector2(19, 6)};
    }
	
	// Update is called once per frame
	void Update () {
        if (verifieStructur())
        {
            door.GetComponent<DefaultBlock>().activate();
        } else
        {
            door.GetComponent<DefaultBlock>().desactivate();
        }
	}

    private bool verifieStructur()
    {
        for (int i = 0; i < 22; i++)
        {
            bool flag = false;
            for (int j = 0; j < 22; j++)
            {
                if (posArray[i] == DynamicObjectManager.Instance.getObjectCoord(j))
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Debug.Log("Stop at " + i);
                return true;
            }
        }

        return false;
    }
}
