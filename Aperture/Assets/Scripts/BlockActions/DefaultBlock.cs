using UnityEngine;
using System.Collections;

public class DefaultBlock : MonoBehaviour {

    [SerializeField]
    public bool allowToPass;
    //[SerializeField]
    //protected bool isActive;

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

    public virtual void activate()
    {

    }

    public virtual void desactivate()
    {

    }

    public virtual void changeState()
    {

    }

    public virtual void activateOnWalk(GameObject player)
    {

    }

    public virtual void activateByPlayer(Direction direction)
    {

    }
}
