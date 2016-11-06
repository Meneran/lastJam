using UnityEngine;
using System.Collections;

/*@Brief Teleport entered object to target location, need trigger to work*/

public class TeleportTo : DefaultBlock {

    public bool canTP;
    [SerializeField]
    private Vector2 target;

	// Use this for initialization
	void Start () {
        canTP = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activateOnWalk(GameObject player)
    {
        //canTP = true;
        //for (int i = 0; i < PlayerManager.Instance.playerArray.Length; ++i)
        //{
        //    if (PlayerManager.Instance.getPlayerCoord(i) == target)
        //        canTP = false;
        //}
        if (canTP)
        {
            player.GetComponent<Player>().position = target;
            player.GetComponent<Transform>().position = target * 0.16f + new Vector2(0, player.GetComponent<Player>().offset);
            player.GetComponent<Player>().newPos = target;
        }

    }

    public override void desactivate()
    {

        canTP = false;
    }

    public override void activate()
    {
        canTP = true;
    }
}
