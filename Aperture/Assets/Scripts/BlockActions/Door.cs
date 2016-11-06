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
            {
                if (new Vector2(transform.position.x, transform.position.y - 0.16f) / 0.16f == PlayerManager.Instance.getPlayerCoord(i))
                {
                    if (PlayerManager.Instance.playerArray[i].GetComponent<Player>().direction == Direction.UP)
                    {
                        //PlayerManager.Instance.playerArray[i].GetComponent<Player>()
                        GameManagerSc.Instance.level++;
                        GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
                    }
                }
                if (new Vector2(transform.position.x, transform.position.y + 0.16f) / 0.16f == PlayerManager.Instance.getPlayerCoord(i))
                {
                    if (PlayerManager.Instance.playerArray[i].GetComponent<Player>().direction == Direction.DOWN)
                    {
                        //PlayerManager.Instance.playerArray[i].GetComponent<Player>()
                        GameManagerSc.Instance.level++;
                        GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
                    }
                }
                if (new Vector2(transform.position.x - 0.16f, transform.position.y) / 0.16f == PlayerManager.Instance.getPlayerCoord(i))
                {
                    if (PlayerManager.Instance.playerArray[i].GetComponent<Player>().direction == Direction.RIGHT)
                    {
                        //PlayerManager.Instance.playerArray[i].GetComponent<Player>()
                        GameManagerSc.Instance.level++;
                        GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
                    }
                }
                if (new Vector2(transform.position.x + 0.16f, transform.position.y) / 0.16f == PlayerManager.Instance.getPlayerCoord(i))
                {
                    if (PlayerManager.Instance.playerArray[i].GetComponent<Player>().direction == Direction.LEFT)
                    {
                        //PlayerManager.Instance.playerArray[i].GetComponent<Player>()
                        GameManagerSc.Instance.level++;
                        GameManagerSc.Instance.LoadSceneUnity(GameManagerSc.SceneUnity.LevelScene);
                    }
                }

            }
        }
    }
}
