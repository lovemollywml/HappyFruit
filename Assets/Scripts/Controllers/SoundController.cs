using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 音效
/// </summary>
public class SoundController : MonoBehaviour {

    public static SoundController Sound;
    public AudioClip[] clips;
    public AudioSource audio_source;
    void Awake()
    {
        if (Sound == null)
        {
            DontDestroyOnLoad(gameObject);
            Sound = this;
        }
        else if (Sound != this)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 开启sound
    /// </summary>
    public void SoundON()
    {
        audio_source.mute = false;
    }
    /// <summary>
    /// 关闭sound
    /// </summary>
    public void SoundOFF()
    {
        audio_source.mute = true;
    }

    #region 各种声音效果
    public void Click()
    {
        audio_source.PlayOneShot(clips[0]);
    }
    public void JewelCrash()
    {
        audio_source.PlayOneShot(clips[1]);
    }
    public void LockCrash()
    {
        audio_source.PlayOneShot(clips[2]);
    }
    public void IceCrash()
    {
        audio_source.PlayOneShot(clips[3]);
    }
    public void Win()
    {
        audio_source.PlayOneShot(clips[4]);
    }
    public void Lose()
    {
        audio_source.PlayOneShot(clips[5]);
    }
    public void StarIn()
    {
        audio_source.PlayOneShot(clips[6]);
    }
    public void Fire()
    {
        audio_source.PlayOneShot(clips[7]);
    }
    public void Gun()
    {
        audio_source.PlayOneShot(clips[8]);
    }
    public void Boom()
    {
        audio_source.PlayOneShot(clips[9]);
    }
#endregion
}
