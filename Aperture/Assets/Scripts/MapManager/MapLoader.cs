using UnityEngine;
using System.Collections;

public class MapLoader : MonoBehaviour {
	
	public Texture2D defaultMap;
	public TextAsset defaultLevelObject;

	// Use this for initialization
	void Start () {
		MapManager.Instance.LoadMap(defaultMap);
		//ObjectManager.Instance.SaveMap("level_01.xml");
		ObjectManager.Instance.LoadMap(defaultLevelObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
