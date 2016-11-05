using UnityEngine;
using System.Collections;

/*@Brief Teleport entered object to target location, need trigger to work*/

public class TeleportTo : DefaultBlock {

    [SerializeField]
    private Vector3 target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activateOnWalk()
    {
<<<<<<< HEAD
        gameObject.transform.position = target;
=======
>>>>>>> parent of 111e127... Action Script Added
        other.GetComponent<Transform>().position = target.GetComponent<Transform>().position;
    }
}
