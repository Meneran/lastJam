using UnityEngine;
using System.Collections;

public class ChangingTextureOnActivate : MonoBehaviour {

    [SerializeField]
    private Sprite sprite1_whenActivated;

    [SerializeField]
    private Sprite sprite2_whenDesactivated;

    private bool isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activate() {
        if (!isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
        }
    }

    public void desactivate()
    {
        if(isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
        }
    }

    public void changeState()
    {
        if (isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
        }
    }
}
