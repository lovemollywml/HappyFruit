using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour{
    public static CameraMovement mcamera;
    public static int StarPointMoveIndex;
    public RectTransform container;
    public GameObject PopUp;
    public GameObject StarPoint;
    public Sprite[] star;
    public GameObject fade;
    float distance = 90.8f / 8680f;
    public static bool movement;
    public static bool setstate;
    public bool isPopup;

    private Player map;

    void Awake()
    {
        mcamera = this;
    }
    void Start()
    {
        SetLastPos();
        SetPoint();
    }
    void SetLastPos()
    {
        float lastp = PlayerPrefs.GetFloat("LASTPOS", 0);
        if (lastp < 0) lastp = 0;
        else if (lastp > 90.8000f) lastp = 90.8f;
        transform.position += new Vector3(0, lastp);
        container.anchoredPosition = new Vector2(container.anchoredPosition.x, -lastp / distance + 4740f);
    }
    void SetPoint()
    {
        float x = PlayerPrefs.GetFloat("LASTPOSX", -0.0045f);
        float y = PlayerPrefs.GetFloat("LASTPOSY", -3.587f);
        StarPoint.transform.position = new Vector3(x, y, StarPoint.transform.position.z);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPopup)
        {
            UnfreezeMap();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonActionController.Click.HomeScene();
        }
    }
    public void UnfreezeMap()
    {
        SoundController.Sound.Click();
        PopUp.SetActive(false);
        isPopup = false;
        DataLoader.enableclick = true;
        fade.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void PopUpShow(Player _map)
    {
        isPopup = true;
        CameraMovement.mcamera.FreezeMap();
        map = _map;
        Image[] stars = new Image[3];
        stars[0] = PopUp.transform.GetChild(1).GetComponent<Image>();
        stars[1] = PopUp.transform.GetChild(2).GetComponent<Image>();
        stars[2] = PopUp.transform.GetChild(3).GetComponent<Image>();

        for (int i = 0; i < 3; i++)
        {
            if (i < _map.Stars)
            {
                stars[i].sprite = star[0];
            }
            else
            {
                stars[i].sprite = star[1];
            }
        }
        PopUp.transform.GetChild(4).GetComponent<Text>().text = _map.HightScore.ToString();
        PopUp.transform.GetChild(6).GetComponent<Text>().text = _map.Level.ToString("00");
        Animation am = PopUp.GetComponent<Animation>();
        am.enabled = true;
        PopUp.SetActive(true);
    }
    public void FreezeMap()
    {
        DataLoader.enableclick = false;
        fade.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void CameraPosUpdate()
    {
        transform.position = new Vector3(transform.position.x, -(container.anchoredPosition.y - 4740f) * distance, transform.position.z);
        if (setstate)
            movement = true;
    }
}
