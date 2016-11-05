using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManagerSc : Singleton<SoundManagerSc>
{

    public static SoundManagerSc instance = null;              //Static instance of SoundManager which allows it to be accessed by any other script.
    public AudioSource sourceMusic;
    public List<AudioSource> sources;
    public AudioClip[] fSound = new AudioClip[13];
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

    public void PlaySound(Sound sIndex)
    {
        switch (sIndex)
        {
            case Sound.Laser:
                AddChannelForPlay(fSound[0]);
                break;
            case Sound.Door:
                AddChannelForPlay(fSound[1]);
                break;
            case Sound.RollingStair:
                AddChannelForPlay(fSound[2]);
                break;
            case Sound.ClickOn:
                AddChannelForPlay(fSound[3]);
                break;
            case Sound.ClickOff:
                AddChannelForPlay(fSound[4]);
                break;
            case Sound.Push:
                AddChannelForPlay(fSound[5]);
                break;
            case Sound.Footsteps:
                AddChannelForPlay(fSound[6]);
                break;
            case Sound.Break:
                AddChannelForPlay(fSound[7]);
                break;
            case Sound.Fail:
                AddChannelForPlay(fSound[8]);
                break;
            case Sound.R2D2talk:
                AddChannelForPlay(fSound[9]);
                break;
            case Sound.Bip1:
                AddChannelForPlay(fSound[0]);
                break;
            case Sound.Bip2:
                AddChannelForPlay(fSound[1]);
                break;
            case Sound.Bip3:
                AddChannelForPlay(fSound[2]);
                break;
        }
    }

    void PlayMusicBg(AudioClip music)
    {
        sourceMusic.clip = music;
        sourceMusic.Play();
    }

    void PauseMusicBg()
    {
        sourceMusic.Stop();
    }

    void AddChannelForPlay(AudioClip audio)
    {
        sourceMusic = gameObject.AddComponent<AudioSource>();
        sourceMusic.clip = audio;
        sourceMusic.Play();

        Debug.Log("Channel Add");
    }

    void KillDeadChannel()
    {
        int i;
        for (i = 0; i < sources.Count; i++)
        {
            if (!sources[i].isPlaying)
            {
                sources.RemoveAt(i);
                Debug.Log("Channel Kill");
                break;
            }
        }
    }

    void Update()
    {
       // KillDeadChannel();
    }



}
