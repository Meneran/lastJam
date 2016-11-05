using UnityEngine;
using System.Collections;

public class Beam : DefaultBlock {

    [SerializeField]
    private Direction direction;

    private Vector2 BeamPosition;
    private int Xint_BeamPosition;
    private int Yint_BeamPosition;
    private Vector3 Zoffset = new Vector3(0, 0, -1);

    private int finalLineRendererPoint;

	// Use this for initialization
	void Start () {
        GetComponent<LineRenderer>().SetPosition(0,transform.position + Zoffset);
        BeamPosition = MapManager.Instance.GetTileCoord(new Vector2(transform.position.x, transform.position.y));
        finalLineRendererPoint = 1;

    }
	
	// Update is called once per frame
	void Update () {
        Xint_BeamPosition = Mathf.RoundToInt(BeamPosition.x);
        Yint_BeamPosition = Mathf.RoundToInt(BeamPosition.y);
        switch (direction) {
            case Direction.UP :
                if(MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition+1).type == TileType.Floor)
                {
                    BeamPosition.y += 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition + 1) + Zoffset);
                }
                break;
            case Direction.DOWN:
                if (MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition - 1).type == TileType.Floor)
                {
                    BeamPosition.y -= 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition - 1) + Zoffset);
                }
                break;
            case Direction.RIGHT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition + 1, Yint_BeamPosition).type == TileType.Floor)
                {
                    BeamPosition.x += 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition + 1, Yint_BeamPosition) + Zoffset);
                }
                break;
            case Direction.LEFT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition - 1, Yint_BeamPosition + 1).type == TileType.Floor)
                {
                    BeamPosition.x -= 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition - 1, Yint_BeamPosition) + Zoffset);
                }
                break;
        }
	}
}
