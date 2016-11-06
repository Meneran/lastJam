using UnityEngine;
using System.Collections;

public class Level7 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MapManager.Instance.UpdateTile(22, 9, TileType.Floor);
	}
	
	// Update is called once per frame
	void Update () {
		MapManager.Instance.UpdateTile(22, 9, TileType.Floor);
	}
}
