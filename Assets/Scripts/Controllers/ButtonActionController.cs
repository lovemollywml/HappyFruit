using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActionController : MonoBehaviour {

    public static ButtonActionController Click;
    public Sprite[] sprites;
    void Awake()
    {
        if (Click == null)
        {
            DontDestroyOnLoad(gameObject);
            Click = this;
        }
        else if (Click != this)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// More 按钮点击
    /// </summary>
    public void More()
    {
        Debug.Log("More，敬请期待");
    }
    public void Rate()
    {
        Debug.Log("暂时没什么卵用");
    }
    public void SelectMap(int mode)
    {
        SoundController.Sound.Click();
        if (mode == 1)
        {
            SceneManager.LoadScene("Map");
        }
        else
        {
            HomeScene();
        }

    }
    public void HomeScene()
    {
        SoundController.Sound.Click();
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
    public void ClassicScene(int level)
    {
        SoundController.Sound.Click();
        Time.timeScale = 1;
        PlayerInfo.MODE = 0;
        PlayerInfo.MapPlayer = new Player();
        PlayerInfo.MapPlayer.Level = level;
        PlayerInfo.MapPlayer.HightScore = PlayerPrefs.GetInt(PlayerInfo.KEY_CLASSIC_HISCORE, 0);
        SceneManager.LoadScene("Play");
    }
    public void ArcadeScene(Player player)
    {
        SoundController.Sound.Click();
        Time.timeScale = 1;
        PlayerInfo.MODE = 1;
        PlayerInfo.MapPlayer = player;
        StartCoroutine(GotoScreen("Play"));
    }
    IEnumerator GotoScreen(string screen)
    {
        yield return new WaitForSeconds(0);
        SceneManager.LoadScene(screen);
    }
}
