using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    private Vector3 stop = new Vector3(0, 0, 0);
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
                transform.localEulerAngles = (new Vector3(0, 0, 0));
                newPos = transform.position + new Vector3(1, 0, 0) * tileSize;
                move = new Vector3(1, 0, 0) * tileSize / 10;
                //transform.position += new Vector3(1, 0, 0) * tileSize;
            }
            if (Input.GetButton("Left"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, 180));
                newPos = transform.position + new Vector3(-1, 0, 0) * tileSize;
                move = new Vector3(-1, 0, 0) * tileSize / 10;
                //transform.position += new Vector3(-1, 0, 0) * tileSize;
            }
            if (Input.GetButton("Up"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, 90));
                newPos = transform.position + new Vector3(0, 1, 0) * tileSize;
                move = new Vector3(0, 1, 0) * tileSize / 10;
                //transform.position += new Vector3(0, 1, 0) * tileSize;
            }
            if (Input.GetButton("Down"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, -90));
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
