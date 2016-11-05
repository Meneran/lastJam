using UnityEngine;
using System.Collections;

/*@Brief Teleport entered object to target location, need trigger to work*/

public class TeleportTo : DefaultBlock {

    [SerializeField]
    private Vector2 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activateOnWalk(GameObject player)
    {
        player.GetComponent<Player>().position = target;
        player.GetComponent<Transform>().position = target * 0.16f;
        player.GetComponent<Player>().newPos = target;
    }
}
