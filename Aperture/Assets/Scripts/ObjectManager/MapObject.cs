using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[System.Serializable]
[XmlRoot("MapObject")]
public class MapObject
{
	[XmlArray("Objects")]
	[XmlArrayItem("Object")]
	public TileObject[] ObjectArray;
}
