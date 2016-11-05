using UnityEngine;
using System.Collections;

public enum Type
{
	Floor,
	Wall,
	Back
}

public class Tile
{
	public int sprite;
	public Type type;

	public Tile (int sprite, Type type)
	{
		this.sprite = sprite;
		this.type = type;
	}

	public Tile() { }
}
