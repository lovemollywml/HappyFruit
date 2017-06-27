using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public int Level;
    public string Name;
    public bool Locked;
    public int Stars;
    public int HightScore;
    public int Background;
    public string ToSaveString()
    {
        string s = Locked + "," + Stars + "," + HightScore + "," + Background + ",";
        return s;
    }
}
