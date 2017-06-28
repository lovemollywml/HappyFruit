using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public Player map;
    public void SetMapInfo()
    {
        SpriteRenderer render = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer[] star = new SpriteRenderer[3];
        star[0] = transform.GetChild(2).GetComponent<SpriteRenderer>();
        star[1] = transform.GetChild(3).GetComponent<SpriteRenderer>();
        star[2] = transform.GetChild(4).GetComponent<SpriteRenderer>();

        if (map.Locked)
        {
            render.sprite = DataLoader.Data.MapSprite[0];
            star[0].sprite = null;
            star[1].sprite = null;
            star[2].sprite = null;
            transform.GetComponent<Collider2D>().enabled = false;
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else if (map.Stars == 0)
        {
            render.sprite = DataLoader.Data.MapSprite[1];
            star[0].sprite = DataLoader.Data.MapSprite[4];
            star[1].sprite = DataLoader.Data.MapSprite[4];
            star[2].sprite = DataLoader.Data.MapSprite[4];
        }
        else
        {
            render.sprite = DataLoader.Data.MapSprite[2];
            star[0].sprite = DataLoader.Data.MapSprite[4];
            star[1].sprite = DataLoader.Data.MapSprite[4];
            star[2].sprite = DataLoader.Data.MapSprite[4];
            for (int i = 0; i < map.Stars; i++)
            {
                star[i].sprite = DataLoader.Data.MapSprite[3];
            }
        }
    }
}
