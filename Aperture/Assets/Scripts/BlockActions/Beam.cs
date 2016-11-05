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

    private Vector3[] arrayOfBeamPoints;

    private int finalLineRendererPoint;

	// Use this for initialization
	void Start () {
        finalLineRendererPoint = 1;
        arrayOfBeamPoints = new Vector3[finalLineRendererPoint + 1];
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[(int)direction];
        switch(direction)
        {
            case Direction.UP:
                arrayOfBeamPoints[0] = transform.position + Zoffset + new Vector3(0, 0.06f, 0.1f);   
                break;
            case Direction.DOWN:
                arrayOfBeamPoints[0] = transform.position + Zoffset + new Vector3(0, -0.05f, 0.1f);
                break;
            case Direction.RIGHT:
                arrayOfBeamPoints[0] = transform.position + Zoffset + new Vector3(0.06f, 0, 0.1f);
                break;
            case Direction.LEFT:
                arrayOfBeamPoints[0] = transform.position + Zoffset + new Vector3(-0.06f, 0, 0.1f);
                break;
        }
        GetComponent<LineRenderer>().SetPosition(0, arrayOfBeamPoints[0]);
        BeamPosition = MapManager.Instance.GetTileCoord(new Vector2(transform.position.x, transform.position.y));
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
                    arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                }
                break;
            case Direction.DOWN:
                if (MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition - 1).type == TileType.Floor)
                {
                    BeamPosition.y -= 1;
                    Yint_BeamPosition -= 1;
                    arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                }
                break;
            case Direction.RIGHT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition + 1, Yint_BeamPosition).type == TileType.Floor)
                {
                    BeamPosition.x += 1;
                    Xint_BeamPosition += 1;
                    arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                }
                break;
            case Direction.LEFT:
                if (MapManager.Instance.GetTile(Xint_BeamPosition - 1, Yint_BeamPosition + 1).type == TileType.Floor)
                {
                    BeamPosition.x -= 1;
                    Xint_BeamPosition -= 1;
                    arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                    GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                }
                break;
        }
        GameObject mirror = ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition);
        if (mirror != null)
        {
            Debug.Log(direction);
            Debug.Log("Object met");
            if (ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).CompareTag("mirror"))
            {
                Debug.Log("That was a mirror");
                ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).GetComponent<MirrorBlock>().activateMirror(gameObject);
            }
            Debug.Log(direction);
        }
	}

    public void reflect(Direction newDirection)
    {
        Debug.Log("new direction = " + newDirection);
        direction = newDirection;
        finalLineRendererPoint++;
        Vector3[] array = new Vector3[finalLineRendererPoint+1];
        for(int i = 0; i < finalLineRendererPoint; i++)
        {
            array[i] = arrayOfBeamPoints[i];
        }
        array[finalLineRendererPoint] = arrayOfBeamPoints[finalLineRendererPoint - 1];
        arrayOfBeamPoints = array;
        GetComponent<LineRenderer>().SetVertexCount(finalLineRendererPoint + 1);
        GetComponent<LineRenderer>().SetPositions(arrayOfBeamPoints);
    }

    public Direction getLazerDirection()
    {
        return direction;
    }
}
