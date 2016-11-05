using UnityEngine;
using System.Collections;

public enum TileType
{
	Ceil,
	Wall,
	Floor,
	WallVoid,
	Void
}

public class Tile
{
	public int sprite;
	public TileType type;

	public Tile (int sprite, TileType type)
	{
		this.sprite = sprite;
		this.type = type;
	}

	public Tile() { }
}
