using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public enum ObjectType
{
	Default,
	Light,
	Switch,
	Box,
	Teleporter,
    Beam1,
    Beam2,
    Mirror1,
    Mirror2,
    Mirror3,
    Mirror4,
    Door,
    DoorPivoted,
}

[System.Serializable]
public class TileObject
{
	public ObjectType type;
	public Vector3 position;
}
