using UnityEngine;
using System.Collections;

public class MirrorBlock : DefaultBlock {

    [SerializeField]
    private Direction direction1;
    [SerializeField]
    private Direction direction2;
    [SerializeField]
    private bool rotate;

    private Direction direction1_opposite;
    private Direction direction2_opposite;

    private GameObject lazerBeam;

	// Use this for initialization
	void Start () {
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 0, 1), 90);
        }
        lazerBeam = null;
        switch (direction1)
        {
            case Direction.UP :
                direction1_opposite = Direction.DOWN;
                break;
            case Direction.DOWN :
                direction1_opposite = Direction.UP;
                break;
            case Direction.RIGHT:
                direction1_opposite = Direction.LEFT;
                break;
            case Direction.LEFT:
                direction1_opposite = Direction.RIGHT;
                break;
        }
        switch (direction2)
        {
            case Direction.UP:
                direction2_opposite = Direction.DOWN;
                break;
            case Direction.DOWN:
                direction2_opposite = Direction.UP;
                break;
            case Direction.RIGHT:
                direction2_opposite = Direction.LEFT;
                break;
            case Direction.LEFT:
                direction2_opposite = Direction.RIGHT;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activateMirror(GameObject beam)
    {
        lazerBeam = beam;
        Beam beamComponent = beam.GetComponent<Beam>();
        if(beamComponent.getLazerDirection() == direction1_opposite)
        {
            beamComponent.reflect(direction2);
        }
        else if(beamComponent.getLazerDirection() == direction2_opposite)
        {
            beamComponent.reflect(direction1);
        }
        else if(beamComponent.getLazerDirection() == direction1)
        {
            beamComponent.reflect(direction2_opposite);
        }
        else if(beamComponent.getLazerDirection() == direction2)
        {
            beamComponent.reflect(direction1_opposite);
        }
    }

    public override void activate()
    {
        if(lazerBeam != null)
        {
            lazerBeam.GetComponent<Beam>().reset();
            lazerBeam = null;
        }
    }
}
