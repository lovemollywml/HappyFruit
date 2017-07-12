using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass : MonoBehaviour {

    public Animator amin;

    /// <summary>
    /// disable animator
    /// </summary>
    public void DisableAnimator()
    {
        amin.enabled = false;
    }
}
