using UnityEngine;
using System.Collections;

public class FloorAction : DefaultBlock {

    TileType memType;
    [SerializeField]
    public TileType newType;

    Vector2 myCoord;
    Vector2 tileCoord;
    void Start()
    {
        myCoord = new Vector2(gameObject.GetComponent<Transform>().position.x, (int)Mathf.Round(gameObject.GetComponent<Transform>().position.y));
        tileCoord = MapManager.Instance.GetTileCoord(myCoord);


        memType = MapManager.Instance.GetTile((int)tileCoord.x, (int)tileCoord.y).type;
    }
    void Update()
    {
        ChangeTileFloor();
    }
    void ChangeTileFloor()
    {
        myCoord = new Vector2(gameObject.GetComponent<Transform>().position.x, gameObject.GetComponent<Transform>().position.y);

       // Debug.Log(myCoord.x + ";" + myCoord.y);

        tileCoord= MapManager.Instance.GetTileCoord(myCoord);

        //Debug.Log(MapManager.Instance.GetTile((int)tileCoord.x, (int)tileCoord.y).type);
        //Debug.Log(gameObject.GetComponent<ChangingTextureOnActivate>().isActive);

        if (gameObject.GetComponent<ChangingTextureOnActivate>().isActive)
        {
             MapManager.Instance.UpdateTile((int)tileCoord.x, (int)tileCoord.y, newType);
        } else {
            MapManager.Instance.UpdateTile((int)tileCoord.x, (int)tileCoord.y, memType);
        }
    }

    //MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor
}
