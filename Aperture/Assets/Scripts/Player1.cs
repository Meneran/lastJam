using UnityEngine;
using System.Collections;



public class Player1 : Player
{
    public override void move()
    {
        if (Input.GetAxis("XAxis1") > 0)
        {
            direction = Direction.RIGHT;
            newPos = position + new Vector2(1, 0);
            moveVector = new Vector3(1, 0, 0) * tileSize / 10;
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
            moveVector = new Vector3(-1, 0, 0) * tileSize / 10;
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
            moveVector = new Vector3(0, 1, 0) * tileSize / 10;
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
            moveVector = new Vector3(0, -1, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                newPos = position;
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null)
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    newPos = position;
        }
    }
}
