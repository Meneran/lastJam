using UnityEngine;
using System.Collections;



public class Player1 : Player
{
    public override void move()
    {
        if (InputManagerSc.Instance.rightP1)
        {
            hasMoved = true;
            direction = Direction.RIGHT;
            newPos = position + new Vector2(1, 0);
            moveVector = new Vector3(1, 0, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                newPos = position;
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    newPos = position;
        }
        if (InputManagerSc.Instance.leftP1)
        {
            hasMoved = true;
            direction = Direction.LEFT;
            newPos = position + new Vector2(-1, 0);
            moveVector = new Vector3(-1, 0, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                newPos = position;
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    newPos = position;
        }
        if (InputManagerSc.Instance.upP1)
        {
            hasMoved = true;
            direction = Direction.UP;
            newPos = position + new Vector2(0, 1);
            moveVector = new Vector3(0, 1, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)(Mathf.Round(newPos.x)), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                newPos = position;
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    newPos = position;
        }
        if (InputManagerSc.Instance.downP1)
        {
            hasMoved = true;
            direction = Direction.DOWN;
            newPos = position + new Vector2(0, -1);
            moveVector = new Vector3(0, -1, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                newPos = position;
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    newPos = position;
        }
    }
}
