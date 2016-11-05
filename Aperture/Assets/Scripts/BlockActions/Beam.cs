using UnityEngine;
using System.Collections;

public class Beam : DefaultBlock {

    [SerializeField]
    private Direction direction;

    private Vector2 BeamPosition;
    private int Xint_BeamPosition;
    private int Yint_BeamPosition;
    private Vector3 Zoffset = new Vector3(0, 0, -0.5f);

    [SerializeField]
    private Sprite[] spriteArray;

    private int finalLineRendererPoint;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[(int)direction];
        switch(direction)
        {
            case Direction.UP:
                GetComponent<LineRenderer>().SetPosition(0,transform.position + Zoffset + new Vector3(0, 0.06f, 0));    
                break;
            case Direction.DOWN:
                GetComponent<LineRenderer>().SetPosition(0, transform.position + Zoffset + new Vector3(0, -0.05f, 0));
                break;
            case Direction.RIGHT:
                GetComponent<LineRenderer>().SetPosition(0, transform.position + Zoffset + new Vector3(0.06f, 0, 0));
                break;
            case Direction.LEFT:
                GetComponent<LineRenderer>().SetPosition(0, transform.position + Zoffset + new Vector3(-0.06f, 0, 0));
                break;
        }
        BeamPosition = MapManager.Instance.GetTileCoord(new Vector2(transform.position.x, transform.position.y));
        finalLineRendererPoint = 1;
    }
	
	// Update is called once per frame
	void Update () {
        Xint_BeamPosition = Mathf.RoundToInt(BeamPosition.x);
        Yint_BeamPosition = Mathf.RoundToInt(BeamPosition.y);
        switch (direction) {
            case Direction.UP :
                if(MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition + 1).type == TileType.Floor)
                {
                    BeamPosition.y += 1;
                    Yint_BeamPosition += 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset);
                }
                break;
            case Direction.DOWN:
                if (MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition - 1).type == TileType.Floor)
                {
                    BeamPosition.y -= 1;
                    Yint_BeamPosition -= 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset);
                }
                break;
            case Direction.RIGHT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition + 1, Yint_BeamPosition).type == TileType.Floor)
                {
                    BeamPosition.x += 1;
                    Xint_BeamPosition += 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset);
                }
                break;
            case Direction.LEFT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition - 1, Yint_BeamPosition + 1).type == TileType.Floor)
                {
                    BeamPosition.x -= 1;
                    Xint_BeamPosition -= 1;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset);
                }
                break;
        }
	}

    public void reflect(Direction newDirection)
    {
        direction = newDirection;
        finalLineRendererPoint++;
    }
}
