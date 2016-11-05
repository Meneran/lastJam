using UnityEngine;
using System.Collections;

public class InputManagerSc : Singleton<InputManagerSc> {

    public static InputManagerSc instance = null;              //Static instance of InputManager which allows it to be accessed by any other script.

    private float horizontal;
    private float vertical;

    private bool a = false;
    private bool b = false;
    private bool x = false;
    private bool y = false;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a InputManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitInput();
    }

    //Initializes the game for each level.
    void InitInput()
    {
       // = this.gameObject.GetComponent<>();
        Debug.Log("InputManager initialized");
    }

    //Update is called every frame.
    void Update()
    {
        UpdateInput();

        this.gameObject.transform.position = (new Vector2(horizontal, vertical));

      /*  rend.material.SetColor("_Color", Color.black);

        if (a)
            rend.material.SetColor("_Color", Color.green);
        if (b)
            rend.material.SetColor("_Color", Color.red);
        if (x)
            rend.material.SetColor("_Color", Color.blue);
        if (y)
            rend.material.SetColor("_Color", Color.yellow);
        */

    }

    void UpdateInput()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        a = Input.GetKey("joystick button 0");
        b = Input.GetKey("joystick button 1");
        x = Input.GetKey("joystick button 2");
        y = Input.GetKey("joystick button 3");
    }
}

