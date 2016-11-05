using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManagerSc : Singleton<SoundManagerSc>
{

    public static SoundManagerSc instance = null;              //Static instance of SoundManager which allows it to be accessed by any other script.
    AudioSource sourceMusic;
    List<AudioSource> sources;
    public AudioClip[] fSound = new AudioClip[10];
    public enum Sound { Laser, Door, RollingStair, ClickOn, ClickOff, Push, Footsteps, Break, Fail, R2D2talk, Bip1, Bip2, Bip3 };

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a SoundManagerSc.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Call the InitGame function to initialize the first level 
        InitSound();
    }

    //Initializes the game for each level.
    void InitSound()
    {
        // sources = new List<AudioSource>();
        //source = GetComponent<AudioSource>();
        Debug.Log("SoundManager initialized");
    }

    void PlaySound(Sound sIndex)
    {
        switch (sIndex)
        {
            case Sound.Laser:
                PlayMusicBg(fSound[0]);
                break;
            case Sound.Door:
                break;
            case Sound.RollingStair:
                break;
            case Sound.ClickOn:
                break;
            case Sound.ClickOff:
                break;
            case Sound.Push:
                break;
            case Sound.Footsteps:
                break;
            case Sound.Break:
                break;
            case Sound.Fail:
                break;
            case Sound.R2D2talk:
                break;
            case Sound.Bip1:
                break;
            case Sound.Bip2:
                break;
            case Sound.Bip3:
                break;
        }
    }

    void PlayMusicBg(AudioClip music)
    {
        sourceMusic.clip = music;
        sourceMusic.Play();
    }

    void FactorySound(AudioClip audio)
    {
        int i;
        if (sources.Count < 5)
        {
            for (i = 0; i < sources.Count; i++)
            {

            }
        }
    }



}
