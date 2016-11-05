using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour {

	public float scrollSpeed;
	public MeshRenderer background;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		float offset = Time.time * scrollSpeed;
		//Debug.Log(offset);
		background.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
	}
}
