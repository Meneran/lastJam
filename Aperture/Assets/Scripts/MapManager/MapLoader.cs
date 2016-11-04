using UnityEngine;
using System.Collections;

public class MapLoader : MonoBehaviour {

	public Texture2D defaultMap;

	// Use this for initialization
	void Start () {
		MapManager.Instance.LoadMap(defaultMap);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
