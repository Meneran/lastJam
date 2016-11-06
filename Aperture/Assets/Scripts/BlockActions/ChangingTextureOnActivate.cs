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

    //[SerializeField]
    //public bool allowToPass;
    [SerializeField]
    public bool isActive;
    public bool allowToPassOnActivate;


    // Use this for initialization
    void Start () {
        transform.Rotate(new Vector3(0, 0, 1), rotate);
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
        VerifyActiveandAllowPass();
	}

    void VerifyActiveandAllowPass()
    {
        if (allowToPassOnActivate)
        {
            this.allowToPass = isActive;
        }
    }
    public override void activate() {
        if (!isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
            isActive = true;
            if (activateOtherBlock)
            {
                if (ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate) != null)
                    ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate).GetComponent<DefaultBlock>().activate();
            }

        }
    }
    
    public override void desactivate()
    {
        if (isActive)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2_whenDesactivated;
            isActive = false;
            if (activateOtherBlock)
            {
                if (ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate) != null)
                    ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate).GetComponent<DefaultBlock>().desactivate();
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
                if (ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate) != null)
                    ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate).GetComponent<DefaultBlock>().changeState();
            }
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1_whenActivated;
            isActive = true;
            if(activateOtherBlock)
            {
                if (ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate) != null)
                    ObjectManager.Instance.GetGameObject(XposOfBlockToActivate, YposOfBlockToActivate).GetComponent<DefaultBlock>().changeState();
            }
        }
    }

    public override void activateOnWalk(GameObject player)
    {
        if(!allowToPassOnActivate)
        changeState();
    }
}
