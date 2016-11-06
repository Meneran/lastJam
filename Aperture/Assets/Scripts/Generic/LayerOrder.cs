using UnityEngine;
using System.Collections;

public class LayerOrder : MonoBehaviour {

	public int order = 0;

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().sortingOrder = order;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
