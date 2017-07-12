using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackground : MonoBehaviour {

    public Sprite[] Background;     // array background

    void Start()
    {
        // set background image by PLayerInfo.BACKGROUND
        GetComponent<SpriteRenderer>().sprite = Background[PlayerInfo.BACKGROUND];
    }
}
