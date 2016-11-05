using UnityEngine;
using System.Collections;

public class Door : DefaultBlock {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<DefaultBlock>().allowToPass = gameObject.GetComponent<ChangingTextureOnActivate>().isActive;
        for (int i = 0; i < PlayerManager.Instance.playerArray.Length; ++i)
        {
            if (gameObject.GetComponent<ChangingTextureOnActivate>().isActive)
                if (new Vector2(transform.position.x, transform.position.y) / 0.16f == PlayerManager.Instance.getPlayerCoord(i))
                    Debug.Log("Gagne");
        }
    }
}
