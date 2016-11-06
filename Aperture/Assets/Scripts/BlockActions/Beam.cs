using UnityEngine;
using System.Collections;

public class Beam : DefaultBlock {

    [SerializeField]
    private Direction direction;

    private Vector2 BeamPosition;
    private int Xint_BeamPosition;
    private int Yint_BeamPosition;
    private Vector3 Zoffset = new Vector3(0, 0, -0.5f);
    private bool deplacement;
    private bool beamLock;

    [SerializeField]
    private Sprite[] spriteArray;

    private Vector3[] arrayOfBeamPoints;

    private int finalLineRendererPoint;

	// Use this for initialization
	void Start () {
        beamLock = false;
        deplacement = false;
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
        arrayOfBeamPoints[finalLineRendererPoint] = transform.position + Zoffset;
        GetComponent<LineRenderer>().SetPosition(1, arrayOfBeamPoints[finalLineRendererPoint]);
    }
	
	// Update is called once per frame
	void Update () {
        deplacement = false;
        Xint_BeamPosition = Mathf.RoundToInt(BeamPosition.x);
        Yint_BeamPosition = Mathf.RoundToInt(BeamPosition.y);
        if (!beamLock)
        {
            switch (direction)
            {
                case Direction.UP:
                    if (MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition + 1).type != TileType.Wall)
                    {
                        deplacement = true;
                        BeamPosition.y += 1;
                        Yint_BeamPosition += 1;
                        arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                        GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                    }
                    break;
                case Direction.DOWN:
                    if (MapManager.Instance.GetTile(Xint_BeamPosition, Yint_BeamPosition - 1).type != TileType.Wall)
                    {
                        deplacement = true;
                        BeamPosition.y -= 1;
                        Yint_BeamPosition -= 1;
                        arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                        GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                    }
                    break;
                case Direction.RIGHT:
                    if (MapManager.Instance.GetTile(Xint_BeamPosition + 1, Yint_BeamPosition).type != TileType.Wall)
                    {
                        deplacement = true;
                        BeamPosition.x += 1;
                        Xint_BeamPosition += 1;
                        arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                        GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                    }
                    break;
                case Direction.LEFT:
                    if (MapManager.Instance.GetTile(Xint_BeamPosition - 1, Yint_BeamPosition).type != TileType.Wall)
                    {
                        deplacement = true;
                        BeamPosition.x -= 1;
                        Xint_BeamPosition -= 1;
                        arrayOfBeamPoints[finalLineRendererPoint] = (Vector3)MapManager.Instance.GetCoord(Xint_BeamPosition, Yint_BeamPosition) + Zoffset;
                        GetComponent<LineRenderer>().SetPosition(finalLineRendererPoint, arrayOfBeamPoints[finalLineRendererPoint]);
                    }
                    break;
            }
        }
        if (deplacement)
        {
            GameObject mirror = ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition);
            if (mirror != null)
            {
                if (ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).CompareTag("mirror"))
                {
                    ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).GetComponent<MirrorBlock>().activateMirror(gameObject);
                } else
                {
                    mirror.GetComponent<DefaultBlock>().activate();
                    beamLock = true;
                }
            }
        }
	}

    public void reflect(Direction newDirection)
    {
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

    public void reset()
    {
        GetComponent<LineRenderer>().SetVertexCount(2);
        beamLock = false;
        deplacement = false;
        finalLineRendererPoint = 1;
        arrayOfBeamPoints = new Vector3[finalLineRendererPoint + 1];
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[(int)direction];
        switch (direction)
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
        arrayOfBeamPoints[finalLineRendererPoint] = transform.position + Zoffset;
        GetComponent<LineRenderer>().SetPosition(1, arrayOfBeamPoints[finalLineRendererPoint]);
    }
}
