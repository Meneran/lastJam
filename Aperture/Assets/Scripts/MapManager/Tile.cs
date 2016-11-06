using UnityEngine;
using System.Collections;

public enum TileType
{
	Ceil,
	Wall,
	Floor,
	WallVoid,
	Void,
    Box
}

public class Tile
{
	public int sprite;
	public TileType type;
	public GameObject gameObject;

	public Tile (int sprite, TileType type, GameObject gameObject)
	{
		this.sprite = sprite;
		this.type = type;
		this.gameObject = gameObject;
	}

	public Tile() { }
}
