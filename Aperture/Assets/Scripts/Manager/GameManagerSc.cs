using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


using System.Collections.Generic;       //Allows us to use Lists. 
using System.Threading;

public class GameManagerSc : Singleton<GameManagerSc>
{
    static public GameManagerSc instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    public int level = 0;
    public bool sound = true;
	public SceneUnity currentScene;
	public bool overlay;

	public string[] levelScene;

	private Object overlayObject;

    public enum SceneUnity
    {
        ManagerScene,
        MenuScene,
        LevelScene,
        MeneranScene
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitGameManager();
    }

	void Update()
	{
		if ((Input.GetKeyDown(KeyCode.Escape)) && (currentScene != SceneUnity.MenuScene))
		{
			overlay = !overlay;
			LoadOverlay(overlay);
		}
	}

    //Initializes the game for each level.
    void InitGameManager()
    {
        Debug.Log("GameManager initialized");
        InitFirstScene();
    }

    void InitFirstScene()
    {
        LoadSceneUnity(SceneUnity.MenuScene);
    }

	public static void LoadOverlay(bool overlay)
	{
		if (overlay)
		{
			Debug.Log("Display overlay");
			GameManagerSc.Instance.overlayObject = Instantiate(Resources.Load("generic/Overlay"));
		}
		else
		{
			Destroy(GameManagerSc.Instance.overlayObject);
		}
	}

    public void LoadSceneUnity(SceneUnity newScene)
    {
		overlay = false;
        switch (newScene)
        {
            case SceneUnity.LevelScene :
				currentScene = newScene;

				if (level < levelScene.Length)
				{
					if (levelScene[level] != "")
					{
						SceneManager.LoadScene(levelScene[level]);
						break;
					}
				}

                SceneManager.LoadScene("main");
                break;

            case SceneUnity.MenuScene :
				currentScene = newScene;
                SceneManager.LoadScene("intro");
                break;

            case SceneUnity.ManagerScene:
				currentScene = newScene;
                SceneManager.LoadScene("ManagerScene");
                break;
            case SceneUnity.MeneranScene:
				currentScene = newScene;
                SceneManager.LoadScene("Meneran");
                break;
        }
    }

}