using UnityEngine;
using System.Collections;

public class Beam : MonoBehaviour {

    [SerializeField]
    private Direction direction;

    private float transitionX;
    private float transitionY;
    private int X_BeamPosition;
    private int Y_BeamPosition;

	// Use this for initialization
	void Start () {
        GetComponent<LineRenderer>().SetPosition(0,transform.position);
        //X_BeamPosition = Mathf.RoundToInt(X_BeamPosition * 6.25);
        //Y_BeamPosition = Mathf.RoundToInt(Y_BeamPosition * 6.25);

    }
	
	// Update is called once per frame
	void Update () {
        /*switch (direction) {
            case Direction.UP :
                if(MapManager.Instance.GetTile(, Mathf.RoundToInt(Y_BeamPosition*6.25)).type == TileType.Floor)
                {

                }
                break;
        }*/
	}
}
