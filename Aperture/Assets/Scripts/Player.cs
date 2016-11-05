using UnityEngine;
using System.Collections;

public enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
};

public class Player : MonoBehaviour
{
    public Direction direction;
    private Vector3 move;
    private Vector3 newPos;
    private bool horizontal, vertical;
    [SerializeField]
    private float tileSize;
    [SerializeField]
    private float saveTimer;
    private float timer;
    // Use this for initialization


    void Start()
    {
        timer = saveTimer;
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0 && transform.position == newPos)
        {
            timer = saveTimer;
            if (Input.GetButton("Right"))
            {
                //transform.localEulerAngles = (new Vector3(0, 0, 0));
                direction = Direction.RIGHT;
                newPos = transform.position + new Vector3(1, 0, 0) * tileSize;
                //if (MapManager.Instance.GetTile((int)newPos.x, (int)newPos.y).type == Type::Floor)
                //    newPos = transform.position;
                move = new Vector3(1, 0, 0) * tileSize / 10;
                //transform.position += new Vector3(1, 0, 0) * tileSize;
            }
            if (Input.GetButton("Left"))
            {
                //transform.localEulerAngles = (new Vector3(0, 0, 180));
                direction = Direction.LEFT;
                newPos = transform.position + new Vector3(-1, 0, 0) * tileSize;
                move = new Vector3(-1, 0, 0) * tileSize / 10;
                //transform.position += new Vector3(-1, 0, 0) * tileSize;
            }
            if (Input.GetButton("Up"))
            {
                //transform.localEulerAngles = (new Vector3(0, 0, 90));
                direction = Direction.UP;
                newPos = transform.position + new Vector3(0, 1, 0) * tileSize;
                move = new Vector3(0, 1, 0) * tileSize / 10;
                //transform.position += new Vector3(0, 1, 0) * tileSize;
            }
            if (Input.GetButton("Down"))
            {
                //transform.localEulerAngles = (new Vector3(0, 0, -90));
                direction = Direction.DOWN;
                newPos = transform.position + new Vector3(0, -1, 0) * tileSize;
                move = new Vector3(0, -1, 0) * tileSize / 10;
                //transform.position += new Vector3(0, -1, 0) * tileSize;
            }
        }
        if (transform.position != newPos)
        {
            transform.position += move;
        }
    }
}
