using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : Singleton<MapManager>
{
	public TileSprite[] tileSet;

	List< List< Tile > > mapMatrix;

	MapManager ()
	{
		mapMatrix = new List<List<Tile>>();
	}

	public void LoadMap(Texture2D map)
	{
		Debug.Log("Loading map...");

		LoadTexture(map);
		DisplayMap();
	}

	public Tile GetTile(int x, int y)
	{
		if ((x >= 0) && (y >= 0) && (x < mapMatrix.Count) && (y < mapMatrix[0].Count))
		{
			return mapMatrix[x][y];
		}
		else
		{
			return new Tile(-1, Type.Back);
		}
	}

	void DisplayMap()
	{
		for (int x = 0; x < mapMatrix.Count; x++)
		{
			for (int y = 0; y < mapMatrix[0].Count; y++)
			{
				int type = mapMatrix[x][y].sprite;

				if (type >= 0)
				{
					GameObject tempTile = new GameObject("Tile");
					tempTile.AddComponent<SpriteRenderer>();

					tempTile.transform.position = new Vector3(x * 0.16f, y * 0.16f, 0);

					Rect tileRect = findRect(mapMatrix[x][y].type);

					tempTile.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tileSet[type].sprite, tileRect, new Vector2(0.5f, 0.5f));
				}
			}
		}
	}
	
	
	void SetDim(int xDim, int yDim)
	{
		mapMatrix.Clear();

		for (int x=0; x<xDim; x++)
		{
			mapMatrix.Add(new List<Tile>());

			for (int y=0; y<yDim; y++)
			{
				mapMatrix[x].Add(new Tile());
			}
		}		
	}

	void LoadTexture(Texture2D map)
	{
		SetDim(map.width, map.height);

		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				int idSprite = findTile(map.GetPixel(x, y));
				mapMatrix[x][y].sprite = idSprite;
				if (idSprite >= 0)
				{
					mapMatrix[x][y].type = tileSet[idSprite].type;
				}
			}
		}
	}

	int findTile(Color color)
	{
		for (int i=0; i<tileSet.Length; i++)
		{
			if (tileSet[i].color == color)
			{
				return i;
			}
		}

		return -1;
	}

	Rect findRect(Type type)
	{
		if (type == Type.Wall)
		{

		}

		return new Rect(0, 0, 16, 16);
	}
}
