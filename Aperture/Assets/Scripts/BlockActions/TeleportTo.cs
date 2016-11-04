using UnityEngine;
using System.Collections;

/*@Brief Teleport entered object to target location, need trigger to work*/

public class TeleportTo : MonoBehaviour {

    [SerializeField]
    private GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Transform>().position = target.GetComponent<Transform>().position;
    }
}
