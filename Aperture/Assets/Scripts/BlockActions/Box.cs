using UnityEngine;
using System.Collections;

public class Box : DefaultBlock {

    public Vector2 position;
    public Vector2 oldPos;
    // Use this for initialization
    void Start () {
        transform.position = position * 0.16f;
        transform.position += new Vector3(0, 0.05f, 0);
        allowToPass = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (ObjectManager.Instance.GetGameObject((int)(transform.position.x / 0.16f), (int)(transform.position.y / 0.16f)) != null)
            ObjectManager.Instance.GetGameObject((int)(transform.position.x / 0.16f), (int)(transform.position.y / 0.16f)).GetComponent<ChangingTextureOnActivate>().activate();
        if (ObjectManager.Instance.GetGameObject((int)oldPos.x, (int)oldPos.y) != null)
        {
            ObjectManager.Instance.GetGameObject((int)(oldPos.x), (int)(oldPos.y)).GetComponent<ChangingTextureOnActivate>().desactivate();
            oldPos = new Vector2(-50, -50);
        }
    }

    public override void activateByPlayer(Direction direction)
    {
        switch (direction)
        {
            case Direction.DOWN:
                if (MapManager.Instance.GetTile((int)Mathf.Round(gameObject.transform.position.x / 0.16f), (int)Mathf.Round((gameObject.transform.position.y - 0.16f) / 0.16f)).type == TileType.Floor)
                {
                    oldPos = transform.position / 0.16f;
                    gameObject.transform.position += new Vector3(0, -0.16f, 0);
                }
                break;
            case Direction.UP:
                if (MapManager.Instance.GetTile((int)Mathf.Round(gameObject.transform.position.x / 0.16f), (int)Mathf.Round((gameObject.transform.position.y + 0.16f) / 0.16f)).type == TileType.Floor)
                {
                    oldPos = transform.position / 0.16f;
                    gameObject.transform.position += new Vector3(0, 0.16f, 0);
                }
                break;
            case Direction.LEFT:
                if (MapManager.Instance.GetTile((int)Mathf.Round((gameObject.transform.position.x - 0.16f) / 0.16f), (int)Mathf.Round(gameObject.transform.position.y / 0.16f)).type == TileType.Floor)
                {
                    oldPos = transform.position / 0.16f;
                    gameObject.transform.position += new Vector3(-0.16f, 0, 0);
                }
                break;
            case Direction.RIGHT:
                if (MapManager.Instance.GetTile((int)Mathf.Round((gameObject.transform.position.x + 0.16f) / 0.16f), (int)Mathf.Round(gameObject.transform.position.y / 0.16f)).type == TileType.Floor)
                {
                    oldPos = transform.position / 0.16f;
                    gameObject.transform.position += new Vector3(0.16f, 0, 0);
                }
                break;
        }
    }
}
