using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 背景音乐
/// </summary>
public class MusicController : MonoBehaviour {

    public static MusicController Music;
    public AudioClip[] clips;
    public AudioSource audio_source;

    void Awake()
    {
        if (Music == null)
        {
            DontDestroyOnLoad(gameObject);
            Music = this;
        }
        else if (Music != this)
        {
            Destroy(gameObject);
        }
    }
    public void MusicON()
    {
        audio_source.mute = false;
    }
    public void MusicOFF()
    {
        audio_source.mute = true;
    }
    public void BG_menu()
    {
        audio_source.clip = clips[0];
        audio_source.Play();
    }
    public void BG_play()
    {
        audio_source.clip = clips[1];
        audio_source.Play();
    }

}
