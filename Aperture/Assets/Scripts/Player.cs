﻿using UnityEngine;
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
    private Vector2 position;
    [SerializeField]
    int startX, startY;
    public Direction direction;
    private Vector3 move;
    private Vector2 newPos;
    private bool horizontal, vertical;
    [SerializeField]
    private float tileSize;
    [SerializeField]
    private float saveTimer;
    private float timer;
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
        timer -= Time.deltaTime;
        if (timer < 0 && position == newPos)
        {
            timer = saveTimer;

           
            if (Input.GetAxis("XAxis1") > 0)
            {
                direction = Direction.RIGHT;
                newPos = position + new Vector2(1, 0);
                move = new Vector3(1, 0, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                    newPos = position;
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null)
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                        newPos = position;
            }
            if (Input.GetAxis("XAxis1") < 0)
            {
                direction = Direction.LEFT;
                newPos = position + new Vector2(-1, 0);
                move = new Vector3(-1, 0, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                    newPos = position;
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null)
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                        newPos = position;
            }
            if (Input.GetAxis("YAxis1") > 0)
            {
                direction = Direction.UP;
                newPos = position + new Vector2(0, 1);
                move = new Vector3(0, 1, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)(Mathf.Round(newPos.x)), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                    newPos = position;
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null)
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                        newPos = position;
            }
            if (Input.GetAxis("YAxis1") < 0)
            {
                direction = Direction.DOWN;
                newPos = position + new Vector2(0, -1);
                move = new Vector3(0, -1, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                    newPos = position;
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null)
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                        newPos = position;
            }
        }
        if (new Vector3(newPos.x * tileSize, newPos.y * tileSize, 0) != transform.position)
        {
            transform.position += move;
        }
        else
        {
            position = newPos;
        }
        GetComponent<Animator>().SetInteger("direction", (int)direction);

        if (ObjectManager.Instance.GetGameObject((int)position.x, (int)position.y) != null) 
            ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().activateOnWalk(this.gameObject);
    }

}
