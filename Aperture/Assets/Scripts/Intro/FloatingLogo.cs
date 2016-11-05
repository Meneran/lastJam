using UnityEngine;
using System.Collections;

public class FloatingLogo : MonoBehaviour {

	public Vector3 startPosition;
	public float floatingSpeed;
	public float floatingDelta;

	// Use this for initialization
	void Start () {
		startPosition = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * floatingSpeed;
		this.gameObject.transform.position = startPosition + new Vector3(0, Mathf.Cos(offset) * floatingDelta, 0);
	}
}
