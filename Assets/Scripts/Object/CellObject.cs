using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour {

    public int CellCode;
    public Cell cell;
    public void SetSpriteEvent()
    {
        SetSprite(cell.CellType - 1);
    }
    public void SetSprite(int type)
    {
        this.GetComponent<SpriteRenderer>().sprite = GribManager.cell.CellSprite[type];
        SetChilEffectSprite(cell.CellEffect);
    }
    void SetChilEffectSprite(int celleffect)
    {
        if (celleffect > 0)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = GribManager.cell.CellSprite[celleffect];
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    public void RemoveEffect()
    {
        if (cell.CellEffect > 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            if (cell.CellEffect == 5)
            {
                EffectSpawner.effect.IceCrash(cell.CellPosition);
                SoundController.Sound.IceCrash();
            }
            else if (cell.CellEffect == 4)
            {
                EffectSpawner.effect.LockCrash(cell.CellPosition);
                SoundController.Sound.LockCrash();
            }
            cell.CellEffect = 0;
            if (JewelSpawner.spawn.JewelGribScript[(int)cell.CellPosition.x, (int)cell.CellPosition.y] != null)
                JewelSpawner.spawn.JewelGribScript[(int)cell.CellPosition.x, (int)cell.CellPosition.y].RuleChecker();
        }
    }
    public void CellTypeProcess()
    {
        if (cell.CellType > 1)
        {
            cell.CellType--;
            runAnim();
            if (cell.CellType == 1)
            {
                GameController.action.CellNotEmpty--;
                if (GameController.action.CellNotEmpty == 0)
                {
                    GameController.action.isShowStar = true;
                }
            }
        }
    }
    void runAnim()
    {
        Animation anim = GetComponent<Animation>();
        anim.enabled = true;
        anim.Play("CellChangeSprite");
    }
}
