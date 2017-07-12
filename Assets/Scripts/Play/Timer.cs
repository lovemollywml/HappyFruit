using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static Timer timer;
    public float GameTime = 270;
    public UnityEngine.UI.Image Timebar;
    public Texture2D timebarTexture;
    public TimerUpdate update;
    public GameObject NoSelect;
    public GameObject PauseUI;
    public GameObject WinUI;

    public GameObject LoseUI;

    public GameObject Nomove;

    private float _time;

    private const int ClassicBaseScore = 5000;

    private int ClassicTargetScore;

    public int ScoreStack = 0;

    private bool startplus;

    public bool isreq;

    public enum GameState
    {
        PLAYING = 0,
        PAUSE = 1,
        WIN = 2,
        LOST = 3,
    }
    void Awake() {
        timer = this;
    }
    void Start()
    {
        _time = GameTime;
        Timebar.fillAmount = 0;
    }
    public void TimeTick(bool b)
    {
        if (b && PlayerInfo.MODE == 1)
        {
            update.enabled = true;
        }
        else
        {
            update.enabled = false;
        }
    }
    void timebarprocess(float time)
    {
        float fillamount = time / _time;
        Timebar.fillAmount = fillamount;
    }
    public void ScoreBarProcess(int score)
    {
        ScoreStack += score;
        if (!startplus)
        {
            startplus = true;
            StartCoroutine(IEScoreBarProcess());
        }


    }
    IEnumerator IEScoreBarProcess()
    {
        while (ScoreStack > 0 && GameController.action.GameState == (int)GameState.PLAYING)
        {
            ScoreStack -= 10;
            if (PlayerInfo.Info.Score + 10 < 5000 * PlayerInfo.MapPlayer.Level)
            { PlayerInfo.Info.Score += 10; }
            else
            {
                PlayerInfo.Info.Score = 5000 * PlayerInfo.MapPlayer.Level;
                break;
            }
            float fillamount = PlayerInfo.Info.Score / (5000f * PlayerInfo.MapPlayer.Level);
            Timebar.fillAmount = fillamount;
            yield return null;
        }

        startplus = false;
    }
    public void Tick()
    {
        if (GameTime > 0 && GameController.action.GameState == (int)GameState.PLAYING)
        {
            GameTime -= Time.deltaTime;
            timebarprocess(GameTime);
        }
        else if (GameController.action.GameState == (int)GameState.PLAYING)
        {
            GameController.action.GameState = (int)GameState.LOST;
            GameTime = 0;
            Lost();
            update.enabled = false;
        }
    }
    public void Win()
    {
        GameController.action.GameState = (int)GameState.WIN;
        NoSelect.SetActive(true);
        StartCoroutine(IEWin());
        Debug.Log("WIN");
    }
    public void Lost()
    {
        GameController.action.GameState = (int)GameState.LOST;
        NoSelect.SetActive(true);
        EffectSpawner.effect.SetScore(PlayerInfo.Info.Score);
        StartCoroutine(DisableAll());
        SoundController.Sound.Lose();
        Debug.Log("LOSE");
    }
    public void Pause()
    {
        SoundController.Sound.Click();
        if (GameController.action.GameState == (int)GameState.PLAYING)
        {
            GameController.action.GameState = (int)GameState.PAUSE;
            NoSelect.SetActive(true);
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        SoundController.Sound.Click();
        if (GameController.action.GameState == (int)GameState.PAUSE)
        {
            GameController.action.GameState = (int)GameState.PLAYING;
            Time.timeScale = 1;
            NoSelect.SetActive(false);
            PauseUI.SetActive(false);
        }
    }
    public void Restart()
    {
        if (PlayerInfo.MODE == 1)
        {
            PlayerInfo.Info.Score = 0;
            ButtonActionController.Click.ArcadeScene(PlayerInfo.MapPlayer);
        }
        else
        {
            ButtonActionController.Click.ClassicScene(1);
        }
    }
    public void Home()
    {
        ButtonActionController.Click.SelectMap(PlayerInfo.MODE);
    }
    public void Next()
    {
        ButtonActionController.Click.SelectMap(1);
        if (PlayerInfo.MapPlayer.Level < 297)
            CameraMovement.StarPointMoveIndex = PlayerInfo.MapPlayer.Level;
        else
            CameraMovement.StarPointMoveIndex = -1;
    }

    public void Music(UnityEngine.UI.Button button)
    {
      //  ButtonActionController.Click.bM(button);
    }
    public void Sound(UnityEngine.UI.Button button)
    {

    }
    public void ClassicLvUp()
    {
        GameController.action.GameState = (int)GameState.WIN;
        NoSelect.SetActive(true);
        StartCoroutine(UpLevel());

    }
    IEnumerator DisableAll()
    {
        DisableJewel(false);
        yield return new WaitForSeconds(0.75f);
        LoseUI.SetActive(true);
    }
    IEnumerator IEWin()
    {
        DisableJewel(true);
        EffectSpawner.effect.StarWinEffect(GameController.action.JewelStar.gameObject.transform.position);
        SoundController.Sound.Win();
        GameController.action.JewelStar.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        WinUI.SetActive(true);
    }

    IEnumerator UpLevel()
    {
        DisableJewel(true);
        yield return new WaitForSeconds(1f);
        ButtonActionController.Click.ClassicScene(PlayerInfo.MapPlayer.Level + 1);
    }

    public void DisableJewel(bool b)
    {
        for (int x = 0; x < 7; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                if (!b)
                {
                    if (JewelSpawner.spawn.JewelGribScript[x, y] != null)
                        JewelSpawner.spawn.JewelGribScript[x, y].JewelDisable();
                }
                else
                {
                    if (JewelSpawner.spawn.JewelGribScript[x, y] != null && JewelSpawner.spawn.JewelGribScript[x, y] != GameController.action.JewelStar)
                        JewelSpawner.spawn.JewelGribScript[x, y].JewelDisable();
                }
            }
        }
    }
}
