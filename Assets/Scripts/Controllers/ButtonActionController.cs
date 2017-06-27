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
}
