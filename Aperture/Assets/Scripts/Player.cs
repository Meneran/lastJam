using UnityEngine;
using System.Collections;

public enum Direction
{
    DOWN,
    UP,
    RIGHT,
    LEFT
};
public class Player : MonoBehaviour
{
    protected GameObject isActivate;
    protected Vector2 isActivatePos;
    protected bool hasMoved;
    public Vector2 position;
    [SerializeField]
    protected int startX, startY;
    public Direction direction;
    protected Vector3 moveVector;
    public Vector2 newPos;
    public Vector2 oldPos;
    protected bool horizontal, vertical;
    [SerializeField]
    protected float tileSize;
    [SerializeField]
    protected float saveTimer;
    protected float timer;
    [SerializeField]
    public float offset;

    // Use this for initialization
    void Start()
    {
        position = new Vector2(startX, startY);
        transform.position = MapManager.Instance.GetCoord(startX, startY);
        transform.position += new Vector3(0, offset, 0);
        timer = saveTimer;
        newPos = position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && position == newPos)
        {
            timer = saveTimer;
            oldPos = position;
            move();
        }

        if (new Vector3(newPos.x * tileSize, newPos.y * tileSize, 0) != transform.position - new Vector3(0, offset, 0))
        {
            transform.position += moveVector;
        }
        else
        {
            position = newPos;
        }
        GetComponent<Animator>().SetInteger("direction", (int)direction);

        if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y) != null && hasMoved)
        {
            isActivate = ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y);
            isActivatePos = new Vector2(position.x, position.y);
            if (isActivate.GetComponent<DefaultBlock>() != null)
                isActivate.GetComponent<DefaultBlock>().activateOnWalk(gameObject);
            hasMoved = false;
        }

        if (ObjectManager.Instance.GetGameObject((int)oldPos.x, (int)oldPos.y) != null && hasMoved)
        {
            isActivate.GetComponent<DefaultBlock>().activateOnWalk(gameObject);
        }
    }

    public virtual void move()
    {

    }
}
