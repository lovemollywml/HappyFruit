using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMusicButtonController : MonoBehaviour {

    public Image Sound;
    public Image Music;
	// Use this for initialization
	void Start () {
        SetButtonState();
	}
    void SetButtonState()
    {
        if (PlayerPrefs.GetInt("MUSIC", 0) != 1)
        {
            Music.sprite = ButtonActionController.Click.sprites[0];
            MusicController.Music.MusicON();
        }
        else
        {
            Music.sprite = ButtonActionController.Click.sprites[1];
            MusicController.Music.MusicOFF();
        }

        if (PlayerPrefs.GetInt("SOUND", 0) != 1)
        {
            Sound.overrideSprite = ButtonActionController.Click.sprites[2];
            SoundController.Sound.SoundON();
        }

    }
    /// <summary>
    /// Set and change state of music in game
    /// </summary>
    public void BMusic()
    {
        if (PlayerPrefs.GetInt("MUSIC", 0) != 1)
        {
            Music.sprite = ButtonActionController.Click.sprites[1];
            PlayerPrefs.SetInt("MUSIC", 1);
            Debug.Log("MUSIC OFF");
            MusicController.Music.MusicOFF();
        }
        else
        {
            Music.sprite = ButtonActionController.Click.sprites[0];
            PlayerPrefs.SetInt("MUSIC", 0);
            Debug.Log("MUSIC ON");
            MusicController.Music.MusicON();
        }
        SoundController.Sound.Click();
    }

    /// <summary>
    /// Set and change state of sound background in game
    /// </summary>
    public void BSound()
    {

        if (PlayerPrefs.GetInt("SOUND", 0) != 1)
        {
            PlayerPrefs.SetInt("SOUND", 1);
            Sound.overrideSprite = ButtonActionController.Click.sprites[3];
            SoundController.Sound.SoundOFF();
        }
        else
        {
            PlayerPrefs.SetInt("SOUND", 0);
            Sound.overrideSprite = ButtonActionController.Click.sprites[2];
            SoundController.Sound.SoundON();
        }
        SoundController.Sound.Click();
    }
}
