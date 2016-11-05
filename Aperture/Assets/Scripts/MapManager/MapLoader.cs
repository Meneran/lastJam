using UnityEngine;
using System.Collections;
using System.IO;

public class MapLoader : MonoBehaviour {
	
	public Texture2D defaultMap;
	public TextAsset defaultLevelObject;

	void Start () {
		MapManager.Instance.LoadMap(defaultMap);
        //ObjectManager.Instance.SaveMap("level_01.xml");
        //ObjectManager.Instance.LoadMap(defaultLevelObject);

        ObjectManager.Instance.InitMatrix();
        ObjectManager.Instance.LoadSprite();
    }
	
	void LoadMap (int level)
	{
		byte[] texData;
		texData = File.ReadAllBytes(Application.dataPath + "/Save/level_" + level + ".png");
		defaultMap.LoadImage(texData);

		defaultLevelObject = Resources.Load(Application.dataPath + "/Save/level_" + level + ".xml") as TextAsset;
		ObjectManager.Instance.LoadMap(defaultLevelObject);
	}
}
