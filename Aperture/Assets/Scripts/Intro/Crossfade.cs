using UnityEngine;
using System.Collections;

public class Crossfade : MonoBehaviour
{
	public float timer;
	private float clock;

	public bool exitState;

	// Use this for initialization
	void Start ()
	{
		clock = timer;
		exitState = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (clock > 0)
		{
			clock -= Time.deltaTime;
		}
		else
		{
			clock = 0;
		}

		if (exitState)
		{
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - sinTransition(clock / timer));
		}
		else
		{
			this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, sinTransition(clock/timer));
		}
	}

	public void changeState()
	{
		exitState = true;
		float clock = timer;
	}

	float sinTransition(float x)
	{
		return 0.5f - 0.5f * Mathf.Cos(x * Mathf.PI);
	}
}
