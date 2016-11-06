using UnityEngine;
using System.Collections;

public class TextManager : MonoBehaviour {

	public string clue;

	void Start()
	{
		if (clue != "")
		{
			CreateText(clue);
		}
	}

	// Use this for initialization
	void CreateText(string textData)
	{
		GameObject textObject = new GameObject("textHolder");
		textObject.transform.parent = this.gameObject.transform;

		textObject.AddComponent<TextMesh>();
		TextMesh textMesh = textObject.GetComponent<TextMesh>();

		textMesh.text = textData;
		Font arcologyFont = Resources.Load("Fonts/Arcology") as Font;
		textMesh.font = arcologyFont;
		textMesh.anchor = TextAnchor.MiddleCenter;

		MeshRenderer rend = textObject.GetComponentInChildren<MeshRenderer>();
		rend.material = textMesh.font.material;

		textMesh.characterSize = 0.01f;
		textMesh.color = new Color(57/255f, 77/255f, 88/255f);

		textObject.AddComponent<TextParallax>();
	}
}
