using UnityEngine;
using System.Collections;

public class RollingStairBlocks : DefaultBlock {

    [SerializeField]
    private Direction direction;

    private bool isActive;

	// Use this for initialization
	void Start () {
        Vector3 Zaxis = new Vector3(0, 0, 1);
        switch (direction)
        {
            case Direction.UP:
                transform.Rotate(Zaxis, -90);
                break;
            case Direction.DOWN:
                transform.Rotate(Zaxis, 90);
                break;
            case Direction.LEFT:
                transform.Rotate(Zaxis, 0f);
                break;
            case Direction.RIGHT:
                transform.Rotate(Zaxis, 180);
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void activateOnWalk(GameObject player)
    {
        if (player.CompareTag("player1"))
        {
            switch (direction)
            {
                case Direction.UP:
                    InputManagerSc.instance.upP1 = true;
                    break;
                case Direction.DOWN:
                    InputManagerSc.instance.downP1 = true;
                    break;
                case Direction.RIGHT:
                    InputManagerSc.instance.rightP1 = true;
                    break;
                case Direction.LEFT:
                    InputManagerSc.instance.leftP1 = true;
                    break;
            }
        }
        else if (player.CompareTag("player2"))
        {
            switch (direction)
            {
                case Direction.UP:
                    InputManagerSc.instance.upP2 = true;
                    break;
                case Direction.DOWN:
                    InputManagerSc.instance.downP2 = true;
                    break;
                case Direction.RIGHT:
                    InputManagerSc.instance.rightP2 = true;
                    break;
                case Direction.LEFT:
                    InputManagerSc.instance.leftP2 = true;
                    break;
            }
        }
    }

    public override void activate()
    {
        GetComponent<Animator>().SetBool("activated", true);
        isActive = true;
    }

    public override void desactivate()
    {
        GetComponent<Animator>().SetBool("activated", true);
        isActive = false;
    }

    public override void changeState()
    {
        if (isActive)
        {
            activate();
        } else
        {
            desactivate();
        }
    }
}
