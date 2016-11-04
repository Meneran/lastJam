using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Vector3 stop = new Vector3(0, 0, 0);
    private bool horizontal, vertical;
    [SerializeField]
    private float tileSize;
    [SerializeField]
    private float saveTimer;
    private float timer;
    // Use this for initialization
    void Start () {
        timer = saveTimer;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = saveTimer;
            if (Input.GetButton("Right"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, 0));
                transform.position += new Vector3(1, 0, 0);
            }
            if (Input.GetButton("Left"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, 180));
                transform.position += new Vector3(-1, 0, 0);
            }
            if (Input.GetButton("Up"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, 90));
                transform.position += new Vector3(0, 1, 0);
            }
            if (Input.GetButton("Down"))
            {
                transform.localEulerAngles = (new Vector3(0, 0, -90));
                transform.position += new Vector3(0, -1, 0);
            }
        }

    }
}
