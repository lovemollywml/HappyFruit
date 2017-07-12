using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUpdate : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Timer.timer.Tick();
	}
}
