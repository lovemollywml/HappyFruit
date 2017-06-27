using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicController.Music.BG_menu();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitOK();
        }
	}
    private void ExitOK()
    {
        Application.Quit();
    }
}
