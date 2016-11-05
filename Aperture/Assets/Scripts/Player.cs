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
    public Vector2 position;
    [SerializeField]
    protected int startX, startY;
    public Direction direction;
    protected Vector3 moveVector;
    protected Vector2 newPos;
    protected bool horizontal, vertical;
    [SerializeField]
    protected float tileSize;
    [SerializeField]
    protected float saveTimer;
    protected float timer;

    // Use this for initialization
    void Start()
    {
        position = new Vector2(startX, startY);
        transform.position = MapManager.Instance.GetCoord(startX, startY);
        timer = saveTimer;
        newPos = position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.position);
        Debug.Log(this.newPos);
        timer -= Time.deltaTime;
        if (timer < 0 && position == newPos)
        {
            timer = saveTimer;
            move();
        }

        if (new Vector3(newPos.x * tileSize, newPos.y * tileSize, 0) != transform.position)
        {
            transform.position += moveVector;
        }
        else
        {
            position = newPos;
        }
        GetComponent<Animator>().SetInteger("direction", (int)direction);

        if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y) != null)
        {
            ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().activateOnWalk(gameObject);
            newPos = position;
        }
    }

    public virtual void move()
    {

    }
}
