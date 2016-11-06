using UnityEngine;
using System.Collections;

public class Beam : DefaultBlock {


    [SerializeField]
    private Direction direction;
    private Direction directionInit;
    private Vector2 BeamPosition;
    private int Xint_BeamPosition;
    private int Yint_BeamPosition;
    private Vector3 Zoffset = new Vector3(0, 0, -0.5f);
    private bool deplacement;
    private bool beamLock;
    private GameObject activatedItem;

    [SerializeField]
    private Sprite[] spriteArray;

    private Vector3[] arrayOfBeamPoints;

    private int finalLineRendererPoint;

    // Use this for initialization
    void Start() {
        directionInit = direction;
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

    // Update is called once per frame
    void Update()
    {
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
            for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
            {
                if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(Xint_BeamPosition, Yint_BeamPosition))
                {
                    GameObject mirror = DynamicObjectManager.Instance.objectArray[i];
                    //GameObject mirror = ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition);
                    if (mirror != null)
                    {
                        if (mirror.CompareTag("mirror"))
                        {
                            mirror.GetComponent<DefaultBlock>().activateMirror(gameObject);
                            if (mirror.GetComponent<Box>().hasmoved)
                                reset();
                        }
                    }
                }
            }
            //if (ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).GetComponent<ChangingTextureOnActivate>() != null)
            //    ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition).GetComponent<DefaultBlock>().activate();
            //DynamicObjectManager.Instance.objectArray[i].GetComponent<DefaultBlock>().activate();
            //beamLock = true;
            GameObject other = ObjectManager.Instance.GetGameObject(Xint_BeamPosition, Yint_BeamPosition);
            if (other != null)
            {
                if (!other.CompareTag("mirror"))
                {
                    if (ObjectManager.Instance.GetTypeObject(Xint_BeamPosition, Yint_BeamPosition) == ObjectType.Light)
                    {
                        beamLock = true;    
                        other.GetComponent<DefaultBlock>().activate();
                        activatedItem = other;
                    }
                }
                deplacement = false;
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
        if (activatedItem != null)
        {
            activatedItem.GetComponent<DefaultBlock>().desactivate();
            activatedItem = null;
        }
        direction = directionInit;
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
