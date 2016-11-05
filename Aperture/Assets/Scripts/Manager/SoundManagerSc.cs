using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManagerSc : Singleton<SoundManagerSc>
{

    public static SoundManagerSc instance = null;              //Static instance of SoundManager which allows it to be accessed by any other script.
    public AudioClip music;
    public AudioClip[] fSound = new AudioClip[13];

    AudioSource sourceMusic;
    public List<GameObject> sources;
    
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

    void Update()
    {
        KillDeadChannel();
    }

    //Initializes the sound.
    void InitSound()
    {
        InitMusicBg();
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
                AddChannelForPlay(fSound[10]);
                break;
            case Sound.Bip2:
                AddChannelForPlay(fSound[11]);
                break;
            case Sound.Bip3:
                AddChannelForPlay(fSound[12]);
                break;
        }
    }

    /// LINK GAME OBJECT SOUND et CHARGE MUSIC DE BASE
    void InitMusicBg()
    {
        sourceMusic = gameObject.GetComponent<AudioSource>();
        LoadMusic(music);
        MusicBg(true);
    }

    // CHARGE MUSIQUE
    void LoadMusic(AudioClip audio)
    {
        sourceMusic.clip = audio;
    }

    // LANCE MUSIQUE DE BG
    void MusicBg(bool musBool) // on off
    {
        if (musBool)
            sourceMusic.Play();
        else
            sourceMusic.Stop();
    }

    // CREE CHANNEL ET LANCE LE SON ASSOCIE
    void AddChannelForPlay(AudioClip audio)
    {
        GameObject go= new GameObject();
        sources.Add(go);
        AudioSource buff;
        buff = go.AddComponent<AudioSource>();
        buff.clip = audio;
        buff.Play();
    }

    // TUE LES CHANNELS DES QUE LE SON EST FINI
    void KillDeadChannel()
    {
        int i;
        if (sources.Count >= 1)
        {
            for (i=0; i<sources.Count; i++)
            {
                if (!sources[i].GetComponent<AudioSource>().isPlaying)
                {
                    Destroy(sources[i]);
                    sources.RemoveAt(i);
                    break;
                }
            }
        }
    }



}
