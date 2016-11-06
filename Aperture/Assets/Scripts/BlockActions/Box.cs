using UnityEngine;
using System.Collections;

public class Box : DefaultBlock {

    public bool hasmoved;
    [SerializeField]
    public float offset;
    public Vector2 position;
    public Vector2 oldPos;
    // Use this for initialization
    [SerializeField]
    private bool level4;
    void Start () {
        transform.position = position * 0.16f;
        transform.position += new Vector3(0, offset, 0);
        allowToPass = false;
        hasmoved = false;
	}

 	void Update () {
        transform.position = new Vector3(position.x, position.y, 0) * 0.16f + new Vector3(0, offset, 0);
        if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y) != null && hasmoved)
        {
            if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y).GetComponent<ChangingTextureOnActivate>() != null)
            {
                hasmoved = false;
                ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y).GetComponent<ChangingTextureOnActivate>().activate();
            }
        }
        if (ObjectManager.Instance.GetGameObject((int)oldPos.x, (int)oldPos.y) != null && hasmoved)
        {
            if (ObjectManager.Instance.GetGameObject((int)oldPos.x, (int)oldPos.y).GetComponent<ChangingTextureOnActivate>() != null)
            {
                Debug.Log("desactivate");
                ObjectManager.Instance.GetGameObject((int)oldPos.x, (int)oldPos.y).GetComponent<ChangingTextureOnActivate>().desactivate();
                oldPos = new Vector2(-50, -50);
                hasmoved = false;
            }
                
        }
        for (int j = 0; j < DynamicObjectManager.Instance.objectArray.Length; ++j)
        {
            if (DynamicObjectManager.Instance.objectArray[j].GetComponent<Box>() != null)
            {
                if (DynamicObjectManager.Instance.objectArray[j].GetComponent<Box>().hasmoved)
                {
                    DynamicObjectManager.Instance.objectArray[j].GetComponent<DefaultBlock>().activate();
                    hasmoved = false;
                }
            }
        }
    }

    public override void activateByPlayer(Direction direction)
    {
        switch (direction)
        {
            case Direction.DOWN:
                if (MapManager.Instance.GetTile((int)Mathf.Round(gameObject.transform.position.x / 0.16f), (int)Mathf.Round((gameObject.transform.position.y - 0.16f) / 0.16f)).type == TileType.Floor)
                {
                    Debug.Log(MapManager.Instance.GetTile((int)Mathf.Round(gameObject.transform.position.x / 0.16f), (int)Mathf.Round((gameObject.transform.position.y - 0.16f) / 0.16f)).type);
                    oldPos = position;
                    position += new Vector2(0, -1);
                    hasmoved = true;
                }
                break;
            case Direction.UP:
                if (MapManager.Instance.GetTile((int)Mathf.Round(gameObject.transform.position.x / 0.16f), (int)Mathf.Round((gameObject.transform.position.y + 0.16f) / 0.16f)).type == TileType.Floor)
                {
                    oldPos = position;
                    position += new Vector2(0, 1);
                    hasmoved = true;
                }
                else if (level4)
                {
                    Vector2 nextPos = new Vector2(position.x, position.y + 1);
                    Debug.Log("On appel le else if" + nextPos);
                    if (nextPos == new Vector2(11, 8) || nextPos == new Vector2(11, 9) || nextPos == new Vector2(11, 10))
                    {
                        MapManager.Instance.GetTile((int)nextPos.x, (int)nextPos.y).gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                        MapManager.Instance.GetTile((int)nextPos.x, (int)nextPos.y).type = TileType.Floor;
                        position = new Vector2(100,100);
                    }
                }
                break;
            case Direction.LEFT:
                if (MapManager.Instance.GetTile((int)Mathf.Round((gameObject.transform.position.x - 0.16f) / 0.16f), (int)Mathf.Round(gameObject.transform.position.y / 0.16f)).type == TileType.Floor)
                {
                    oldPos = position;
                    position += new Vector2(-1, 0);
                    hasmoved = true;
                }
                break;
            case Direction.RIGHT:
                if (MapManager.Instance.GetTile((int)Mathf.Round((gameObject.transform.position.x + 0.16f) / 0.16f), (int)Mathf.Round(gameObject.transform.position.y / 0.16f)).type == TileType.Floor)
                {
                    oldPos = position;
                    position += new Vector2(1, 0);
                    hasmoved = true;
                }
                break;
        }
        if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y) != null)
            if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y).GetComponent<DefaultBlock>() != null)
                if (!ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y).GetComponent<DefaultBlock>().allowToPass)
                    position = oldPos;
        for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
        {
            if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(position.x, position.y))
            {
                if (!DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().allowToPass && hasmoved)
                {
                    position = oldPos;
                    hasmoved = false;
                }
            }
            if (PlayerManager.Instance.getPlayerCoord(0) == new Vector2(position.x, position.y) || PlayerManager.Instance.getPlayerCoord(1) == new Vector2(position.x, position.y) && hasmoved)
            {
                position = oldPos;
                hasmoved = false;
            }
        }
    }
}
