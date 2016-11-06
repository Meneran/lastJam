using UnityEngine;
using System.Collections;

public class PlayerManager : Singleton<PlayerManager>
{
	public GameObject[] playerArray;
	
	public void SetPlayerPos(int i, int x, int y)
	{
		if (playerArray.Length > i)
		{
			//playerArray[i].transform.position = new Vector3(x * 0.16f, y * 0.16f, -0.2f);
		}
	}

	public Vector2 getPlayerCoord(int i)
	{
		if (2 > i)
		{
			return new Vector2(Mathf.Round(playerArray[i].transform.position.x/0.16f), Mathf.Round(playerArray[i].transform.position.y/0.16f));
		}
		else
		{
			return new Vector2(-1, -1);
		}
	}
}
