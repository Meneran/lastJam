using UnityEngine;
using System.Collections;

public class Conveyor : DefaultBlock {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activateOnWalk(GameObject player)
    {

       // direction = player.GetComponent<Player>().direction;
        //id = player.GetTag()
    }
}
