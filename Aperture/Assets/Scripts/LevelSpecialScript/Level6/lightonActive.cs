using UnityEngine;
using System.Collections;

public class lightonActive : MonoBehaviour {

    GameObject go;
    //GameObject.GetComponent<>();
    void Start()
    {
        //Debug.Log("test");
        go = Instantiate(Resources.Load("obscur")) as GameObject;
    }
    void Update()
    {
        OnOffShadow();
    }
    void OnOffShadow()
    {
        if (gameObject.GetComponent<ChangingTextureOnActivate>().isActive != go.activeSelf )
        {
            go.SetActive(gameObject.GetComponent<ChangingTextureOnActivate>().isActive);
        }
    }
}
