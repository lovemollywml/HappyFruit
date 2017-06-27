using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo Info;  //玩家信息
    public static Player MapPlayer;  //玩家对象
    public static byte MODE;     //mode：Arcade or Classic
    public static int BACKGROUND;

    public int Score;
    public const string KEY_CLASSIC_HISCORE = "classichightscore";
    public TextMesh textlv;
    void Awake()
    {
        Info = this;
        BACKGROUND = MapPlayer.Background;
    }
    void Start()
    {
        Score = 0;
        textlv.text = MapPlayer.Level.ToString();
    }
}
