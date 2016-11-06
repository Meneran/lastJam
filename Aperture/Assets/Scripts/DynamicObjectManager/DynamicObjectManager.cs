using UnityEngine;
using System.Collections;

public class DynamicObjectManager : Singleton<DynamicObjectManager>
{
    public GameObject[] objectArray;
    public ObjectType[] objectType;

    public Vector2 getObjectCoord(int i)
    {
        if (objectArray != null)
        {
            if (objectArray.Length > i)
            {
                return new Vector2(Mathf.Round(objectArray[i].transform.position.x / 0.16f), Mathf.Round(objectArray[i].transform.position.y / 0.16f));
            }
            else
            {
                return new Vector2(-1, -1);
            }
        }
        else
            return new Vector2(-1, -1);
    }
        
    public ObjectType getObjectType(int i)
    {
        if (objectArray != null)
        {
            if (objectArray.Length > i)
            {
                return objectType[i];
            }
            else
            {
                return ObjectType.Default;
            }
        }
        else
            return ObjectType.Default;
    }
}
