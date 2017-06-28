using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    public static void MoveTo(GameObject obj, Vector2 newPos, float duration, float z)
    {
        var startPos=new Vector2(obj.transform.localPosition.x,obj.transform.localPosition.y);
        MoveTo(obj, startPos, newPos, duration, z);
    }
    public static void MoveTo(GameObject obj, Vector2 startpos, Vector2 newPos, float duration, float z)
    {
        Animation anim = obj.GetComponent<Animation>();
        anim.enabled = true;
        AnimationClip animclip = new AnimationClip();
#if UNITY_5
        animclip.legacy=true;
#endif
        AnimationCurve curvex = AnimationCurve.Linear(0, startpos.x, duration, newPos.x);
        AnimationCurve curvey = AnimationCurve.Linear(0, startpos.y, duration, newPos.y);
        AnimationCurve curvez = AnimationCurve.Linear(0, z, duration, z);
        AnimationCurve curvenable = AnimationCurve.Linear(0, 1, duration, 0);

        animclip.SetCurve("", typeof(Transform), "localPosition.x", curvex);
        animclip.SetCurve("", typeof(Transform), "localPosition.y", curvey);
        animclip.SetCurve("", typeof(Transform), "localPosition.z", curvez);
        animclip.SetCurve("", typeof(Animation), "m_Enabled", curvenable);

        anim.AddClip(animclip, "Moveto");
        anim.Play("Moveto");
        Destroy(animclip, duration);
    }
}
