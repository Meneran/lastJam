using UnityEngine;
using System.Collections;
using System.IO;

public class MapLoader : MonoBehaviour {
	
	public Texture2D defaultMap;
	public TextAsset defaultLevelObject;

	void Start ()
	{
		if (GameManagerSc.instance.level > 0)
		{
			defaultMap = new Texture2D(1, 1);
			defaultLevelObject = new TextAsset();

			LoadMap(GameManagerSc.instance.level);
		}
		else if (defaultMap != null)
		{
			MapManager.Instance.LoadMap(defaultMap);

			ObjectManager.Instance.InitMatrix();
			ObjectManager.Instance.LoadSprite();
		}

		//ObjectManager.Instance.SaveMap("level_01.xml");
		//ObjectManager.Instance.LoadMap(defaultLevelObject);
	}
	
	void LoadMap (int level)
	{
		byte[] texData;
		texData = File.ReadAllBytes(Application.dataPath + "/Resources/Save/level_" + level + ".png");
		Debug.Log("Loading Map - " + Application.dataPath + "/Resources/Save/level_" + level + ".png");
		defaultMap.LoadImage(texData);

		MapManager.Instance.LoadMap(defaultMap);

		defaultLevelObject = Resources.Load("Save/level_" + level ) as TextAsset;
		Debug.Log("Loading Objects - " + "Save/level_" + level );

		ObjectManager.Instance.LoadMap(defaultLevelObject);
	}
}
