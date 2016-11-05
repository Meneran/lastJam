using UnityEngine;
using System.Collections;

public class InputManagerSc : Singleton<InputManagerSc> {

    public static InputManagerSc instance = null;              //Static instance of InputManager which allows it to be accessed by any other script.

    // accès via par exemple InputManagerSc.Instance.start

    public bool start = false;

    public bool upP1 = false;
    public bool rightP1 = false;
    public bool leftP1 = false;
    public bool downP1 = false;

    public bool upP2 = false;
    public bool rightP2 = false;
    public bool leftP2 = false;
    public bool downP2 = false;

    public bool act1P1 = false;
    public bool act2P1 = false;
    public bool act3P1 = false;
    public bool act4P1 = false;

    public bool act1P2 = false;
    public bool act2P2 = false;
    public bool act3P2 = false;
    public bool act4P2 = false;

    

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
        if (upP1)
            SoundManagerSc.Instance.PlaySound(SoundManagerSc.Sound.Bip1);
        UpdateInput();
    }

    void UpdateInput()
    {

        rightP1 = Input.GetAxis("XAxis1") > 0;
        leftP1 = Input.GetAxis("XAxis1") < 0;
        upP1 = Input.GetAxis("YAxis1") > 0;
        downP1 = Input.GetAxis("YAxis1") < 0;

        rightP2 = Input.GetAxis("XAxis2") > 0;
        leftP2 = Input.GetAxis("XAxis2") < 0;
        upP2 = Input.GetAxis("YAxis2") < 0;
        downP2 = Input.GetAxis("YAxis2") > 0;
    }
}

