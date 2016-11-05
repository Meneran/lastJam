using UnityEngine;
using System.Collections;

public class Action : MonoBehaviour {

    private Direction direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        direction = GetComponent<Player>().getDirection();
	}
}
