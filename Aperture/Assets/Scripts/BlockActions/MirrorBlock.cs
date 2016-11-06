using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MirrorBlock : DefaultBlock {

    [SerializeField]
    private float timer;
    private float resetTimer;
    [SerializeField]
    private Direction direction1;
    [SerializeField]
    private Direction direction2;
    [SerializeField]
    private bool rotate;

    private Direction direction1_opposite;
    private Direction direction2_opposite;

    private List<GameObject> lazerBeam = new List<GameObject>();
    //private GameObject[] lazerBeam = new GameObject[2];

	// Use this for initialization
	void Start () {
        resetTimer = timer;
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 0, 1), 90);
        }
        
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
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            lazerBeam.Clear();
            for (int k = 0; k < 30; ++k)
            {
                for (int l = 0; l < 30; ++l)
                {
                    if (ObjectManager.Instance.GetGameObject(k, l) != null)
                    {
                        if (ObjectManager.Instance.objectMatrix[k, l].type == ObjectType.Beam1 || ObjectManager.Instance.objectMatrix[k, l].type == ObjectType.Beam2)
                        {
                            lazerBeam.Add(ObjectManager.Instance.objectMatrix[k, l].gameObject);
                        }
                    }
                }
            }
            timer = resetTimer;
        }
        
    }

    public override void activateMirror(GameObject beam)
    {
        //lazerBeam.Add(beam);
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
        if(lazerBeam.Count > 0)
        {
            for (int i = 0; i < lazerBeam.Count; ++i)
                lazerBeam[i].GetComponent<Beam>().reset();
            lazerBeam.Clear();
        }
    }
}
