using UnityEngine;
using System.Collections;

public class DefaultBlock : MonoBehaviour {

    [SerializeField]
    private bool allowToPass;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void enablePassing()
    {
        allowToPass = true;
    }

    public void disablePassing()
    {
        allowToPass = false;
    }

    public bool getPassing()
    {
        return allowToPass;
    }
}
