using UnityEngine;
using System.Collections;

public class EnnemyBlock : DefaultBlock {

    [SerializeField]
    private int X_target;
    [SerializeField]
    private int Y_target;

    private Vector2 origin;
    private Vector2 target;

	// Use this for initialization
	void Start () {
        origin = MapManager.Instance.GetTileCoord((Vector2)transform.position);
        target = new Vector2(X_target, Y_target);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void killArround()
    {

    }
}
