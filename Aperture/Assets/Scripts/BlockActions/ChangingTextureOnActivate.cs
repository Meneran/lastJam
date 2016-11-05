using UnityEngine;
using System.Collections;

public class ChangingTextureOnActivate : DefaultBlock {

    [SerializeField]
    private Sprite sprite1_whenActivated;

    [SerializeField]
    private Sprite sprite2_whenDesactivated;

    [SerializeField]
    private int XposOfBlockToActivate;

    [SerializeField]
    private int YposOfBlockToActivate;

    [SerializeField]
    private bool activateOtherBlock;

    [SerializeField]
    private bool isActive;

	// Use this for initialization
	void Start () {
        if (isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activate() {
        if (!isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
            isActive = true;
            if (activateOtherBlock)
            {
                //MapManager.Instance.GetTile(XposOfBlockToActivate, YposOfBlockToActivate).getComponent<DefaultBlock>().activate();
            }
        }
    }

    public override void desactivate()
    {
        if(isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
            isActive = false;
            if (activateOtherBlock)
            {
                //MapManager.Instance.GetTile(XposOfBlockToActivate, YposOfBlockToActivate).getComponent<DefaultBlock>().desactivate();
            }
        }
    }

    public override void changeState()
    {
        if (isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
            isActive = false;
            if (activateOtherBlock)
            {
                //MapManager.Instance.GetTile(XposOfBlockToActivate, YposOfBlockToActivate).getComponent<DefaultBlock>().desactivate();
            }
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
            isActive = true;
            if(activateOtherBlock)
            {
                //MapManager.Instance.GetTile(XposOfBlockToActivate, YposOfBlockToActivate).getComponent<DefaultBlock>().activate();
            }
        }
    }

    public override void activateOnWalk()
    {
        changeState();
    }
}
