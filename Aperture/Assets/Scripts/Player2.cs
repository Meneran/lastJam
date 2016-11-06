using UnityEngine;
using System.Collections;



public class Player2 : Player
{
    public override void move()
    {
        if (InputManagerSc.Instance.rightP2)
        {
            hasMoved = true;
            direction = Direction.RIGHT;
            newPos = position + new Vector2(1, 0);
            moveVector = new Vector3(1, 0, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
            {
                hasMoved = false;
                newPos = position;
            }
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                {
                    hasMoved = false;
                    newPos = position;
                }
            for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
            {
                if (DynamicObjectManager.Instance.getObjectCoord(i) == newPos)
                {
                    newPos = position;
                    hasMoved = false;
                }
            }
            if (PlayerManager.Instance.getPlayerCoord(0) == newPos)
                newPos = position;
        }
        if (InputManagerSc.Instance.leftP2)
        {
            hasMoved = true;
            direction = Direction.LEFT;
            newPos = position + new Vector2(-1, 0);
            moveVector = new Vector3(-1, 0, 0) * tileSize / 10;
            if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
            {
                newPos = position;
                hasMoved = false;
            }
            if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                {
                    newPos = position;
                    hasMoved = false;
                }
            for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
            {
                if (DynamicObjectManager.Instance.getObjectCoord(i) == newPos)
                {
                    newPos = position;
                    hasMoved = false;
                }
            }
            if (PlayerManager.Instance.getPlayerCoord(0) == newPos)
            {
                hasMoved = false;
                newPos = position;
            }
        }
        if (InputManagerSc.Instance.upP2)
        {
                hasMoved = true;
                direction = Direction.UP;
                newPos = position + new Vector2(0, 1);
                moveVector = new Vector3(0, 1, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)(Mathf.Round(newPos.x)), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                {
                    newPos = position;
                    hasMoved = false;
                }
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    {
                        newPos = position;
                        hasMoved = false;
                    }
                for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                {
                    if (DynamicObjectManager.Instance.getObjectCoord(i) == newPos)
                    {
                        newPos = position;
                        hasMoved = false;
                    }
                }
                if (PlayerManager.Instance.getPlayerCoord(0) == newPos)
                {
                    newPos = position;
                    hasMoved = false;
                }
            }
            if (InputManagerSc.Instance.downP2)
            {
                hasMoved = true;
                direction = Direction.DOWN;
                newPos = position + new Vector2(0, -1);
                moveVector = new Vector3(0, -1, 0) * tileSize / 10;
                if (MapManager.Instance.GetTile((int)Mathf.Round(newPos.x), (int)Mathf.Round(newPos.y)).type != TileType.Floor)
                {
                    newPos = position;
                    hasMoved = false;
                }
                if (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y) != null && (ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>() != null))
                    if ((!ObjectManager.Instance.GetGameObject((int)newPos.x, (int)newPos.y).GetComponent<DefaultBlock>().getPassing()))
                    {
                        newPos = position;
                        hasMoved = false;
                    }
                for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                {
                    if (DynamicObjectManager.Instance.getObjectCoord(i) == newPos)
                    {
                        newPos = position;
                        hasMoved = false;
                    }
                }
                if (PlayerManager.Instance.getPlayerCoord(0) == newPos)
                {
                    newPos = position;
                    hasMoved = false;
                }
            }
        }

    public override void action()
    {
        if (InputManagerSc.Instance.act1P2)
        {

            switch (direction)
            {
                case (Direction.UP):
                    for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                    {
                        if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(position.x, position.y + 1))
                        {
                            DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().activateByPlayer(direction);
                        }
                    }
                    break;
                case (Direction.DOWN):
                    for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                    {
                        if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(position.x, position.y - 1))
                        {
                            DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().activateByPlayer(direction);
                        }
                    }
                    break;
                case (Direction.LEFT):
                    for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                    {
                        if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(position.x - 1, position.y))
                        {
                            DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().activateByPlayer(direction);
                        }
                    }
                    break;
                case (Direction.RIGHT):
                    for (int i = 0; i < DynamicObjectManager.Instance.objectArray.Length; ++i)
                    {
                        if (DynamicObjectManager.Instance.getObjectCoord(i) == new Vector2(position.x + 1, position.y))
                        {
                            DynamicObjectManager.Instance.objectArray[i].GetComponent<Box>().activateByPlayer(direction);
                        }
                    }
                    break;
            }
        }
    }
}
