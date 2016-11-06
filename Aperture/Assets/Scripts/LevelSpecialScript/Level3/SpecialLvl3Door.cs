using UnityEngine;
using System.Collections;

public class SpecialLvl3Door : Door {

    [SerializeField]
    public bool conditionValidated;
    [SerializeField]
    private bool[] testArray;
    private Vector2 playerPos;

	// Use this for initialization
	void Start () {
	    testArray = new bool[4] {false, false, false, false };
        conditionValidated = false;
	}
	
	// Update is called once per frame
	new void Update () {

        if (!conditionValidated) {
            if (!(conditionValidated = isSurrounded(PlayerManager.Instance.playerArray[0])))
            {
                conditionValidated = isSurrounded(PlayerManager.Instance.playerArray[1]);
            }
            if (conditionValidated)
            {
                GetComponent<ChangingTextureOnActivate>().activate();
            }
        } else
        {
            base.Update();
        }
	}

    bool isSurrounded(GameObject player)
    {
        playerPos = MapManager.Instance.GetTileCoord((Vector3)player.transform.position);
        int X_player = Mathf.RoundToInt(playerPos.x);
        int Y_player = Mathf.RoundToInt(playerPos.y);
        //UP
        if(!(testArray[0] = (MapManager.Instance.GetTile(X_player, Y_player + 1)).type != TileType.Floor)){
            testArray[0] = testDynamicObject(X_player, Y_player + 1);
        }
        //DOWN
        if (!(testArray[1] = (MapManager.Instance.GetTile(X_player, Y_player - 1)).type != TileType.Floor))
        {
            testArray[1] = testDynamicObject(X_player, Y_player - 1);
        }
        //RIGHT
        if (!(testArray[2] = (MapManager.Instance.GetTile(X_player + 1, Y_player)).type != TileType.Floor))
        {
            testArray[2] = testDynamicObject(X_player + 1, Y_player);
        }
        //LEFT
        if (!(testArray[3] = (MapManager.Instance.GetTile(X_player - 1, Y_player)).type != TileType.Floor))
        {
            testArray[3] = testDynamicObject(X_player - 1, Y_player);
        }

        for(int i = 0; i < 4; i++)
        {
            if (!testArray[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool testDynamicObject(int x, int y)
    {
        for(int i = 0; i < 12; i++)
        {
            if(DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().position == new Vector2(x, y))
            {
                return true;
            }
        }
        return false;
    }
}
