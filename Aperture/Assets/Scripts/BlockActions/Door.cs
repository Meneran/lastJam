using UnityEngine;
using System.Collections;

public class Door : DefaultBlock {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<DefaultBlock>().allowToPass = gameObject.GetComponent<ChangingTextureOnActivate>().isActive;
    }

    //public override void activateOnWalk(GameObject player)
    //{
        //change scene
    //}
}
