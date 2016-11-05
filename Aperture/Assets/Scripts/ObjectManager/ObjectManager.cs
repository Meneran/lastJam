using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
public struct ObjectSprite
{
	public ObjectType type;
	//public Texture2D sprite;
	public GameObject prefab;
}

public struct ObjectContainer
{
	public bool set;
	public GameObject gameObject;
	public ObjectType type;

	public ObjectContainer(bool set, GameObject gameObject, ObjectType type)
	{
		this.set = set;
		this.gameObject = gameObject;
		this.type = type;
	}

}

public class ObjectManager : Singleton<ObjectManager>
{
	public MapObject mapObject;
	public ObjectSprite[] spriteArray;

	ObjectContainer[,] objectMatrix;

	public GameObject objectHolder;

	public void SaveMap(string path)
	{
		XmlHelpers.SaveToXML<MapObject>(Application.dataPath + "/Resources/Save/" + path, mapObject);
	}

	public void LoadMap(TextAsset level)
	{
		mapObject = XmlHelpers.LoadFromTextAsset<MapObject>(level);

		InitMatrix();
		LoadSprite();
	}

	public GameObject GetGameObject(int x, int y)
	{
		if ((x >= 0) && (y >= 0) && (x < objectMatrix.GetLength(0)) && (y < objectMatrix.GetLength(1)))
		{
			if (objectMatrix[x, y].set)
			{
				return objectMatrix[x, y].gameObject;
			}
			else
			{
				return null;
			}
		}
		else
		{
			return null;
		}
	}
	
	public ObjectType GetTypeObject(int x, int y)
	{
		if ((x >= 0) && (y >= 0) && (x < objectMatrix.GetLength(0)) && (y < objectMatrix.GetLength(1)))
		{
			if (objectMatrix[x, y].set)
			{
				return objectMatrix[x, y].type;
			}
			else
			{
				return ObjectType.Default;
			}
		}
		else
		{
			return ObjectType.Default;
		}
	}

	public void InitMatrix()
	{
		MapManager map = MapManager.Instance;
		int xDim = map.xDim;
		int yDim = map.yDim;

		objectMatrix = new ObjectContainer[xDim, yDim];
	}

	public void LoadSprite()
	{
		MapManager map = MapManager.Instance;

		for (int i = 0; i < mapObject.ObjectArray.Length; i++)
		{
			for (int j = 0; j < spriteArray.Length; j++)
			{
				if (mapObject.ObjectArray[i].type == spriteArray[j].type)
				{
					int x = (int)mapObject.ObjectArray[i].position.x;
					int y = (int)mapObject.ObjectArray[i].position.y;

					if (spriteArray[j].prefab != null)
					{
						objectMatrix[x, y] = new ObjectContainer(true, (GameObject)Instantiate(spriteArray[j].prefab, new Vector3(0, 0, 0), Quaternion.identity), spriteArray[j].type);
						objectMatrix[x, y].gameObject.transform.position = new Vector3(x * 0.16f, y * 0.16f, -0.1f);
                        objectMatrix[x, y].gameObject.transform.parent = objectHolder.transform;
					}
					/*
					objectMatrix[x, y] = new ObjectContainer(true, new GameObject("Object"));

					objectMatrix[x, y].gameObject.transform.parent = objectHolder.transform;
					//objectMatrix[x, y].gameObject.AddComponent<SpriteRenderer>();

					objectMatrix[x, y].gameObject.transform.position = new Vector3(x * 0.16f, y * 0.16f, -0.1f);
					//objectMatrix[x, y].gameObject.GetComponent<SpriteRenderer>().sprite = Sprite.Create(spriteArray[j].sprite, new Rect(0, 0, 16, 16), new Vector2(0.5f, 0.5f));

					objectMatrix[x, y].gameObject.AddComponent<DefaultBlock>();

					if (spriteArray[j].prefab != null)
					{
						GameObject childPrefab = (GameObject)Instantiate(spriteArray[j].prefab, new Vector3(0, 0, 0), Quaternion.identity);
						childPrefab.transform.parent = objectMatrix[x, y].gameObject.transform;
					}
					*/
				}
			}
		}
	}


}
