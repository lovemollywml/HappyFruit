using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour {

    private const float count = 100f; //模拟进度条加载比例
    public Image load_bar; //进度条
    IEnumerator Start()
    {
        for (int i = 1; i <= count; i++)
        {
            load_bar.fillAmount += 1 / count;
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Loading Over!");
        //加载主场景
        SceneManager.LoadScene("Home");
    }
}
