using UnityEngine;
using System.Collections;

public class TextParallax : MonoBehaviour {

	private float startTime;
	public float multiplier = 5f;

	// Use this for initialization
	void Start ()
	{
		startTime = Time.time;
		this.gameObject.transform.position = new Vector3(4, 1, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float transition = ((Time.time - startTime) / multiplier + 1f);

		this.gameObject.transform.position = new Vector3(6 - 8 * sinTransition(transition), 0.1f, -0.5f);

		if (Mathf.Floor(transition) % 2 == 0)
		{
			float transparency = Mathf.Pow(Mathf.Max(sinTransition(2 * transition) * 2f - 1f, 0), 2);
			this.gameObject.GetComponent<TextMesh>().color = new Color(57 / 255f, 77 / 255f, 88 / 255f, transparency * 0.75f);
		}
		else
		{
			this.gameObject.GetComponent<TextMesh>().color = new Color(0,0,0,0); ;
		}
	}

	float sinTransition(float x)
	{
		return 0.5f - 0.5f * Mathf.Cos(x * Mathf.PI);
	}
}
