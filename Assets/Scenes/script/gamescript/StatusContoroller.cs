using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusContoroller : MonoBehaviour
{
    public StatusModel statusmodel;
    public StatusView statusview;
    private void Awake()
    {
        statusview = GetComponent<StatusView>();
    }
    void Update()
    {

    }
    public void Init(bool mine)
    {
        statusmodel = new StatusModel(mine);
        statusview.Show(statusmodel);
        if(mine)
        {
            gameObject.name = "Mystatus";
        }
        else
        {
            gameObject.name = "Enemystatus";
        }
    }
    public void ChangeMaxHP(int change)
    {
        statusmodel.HPper = statusmodel.restHp / statusmodel.maxHp;
        statusmodel.normalHp += change;
        statusmodel.maxHp = statusmodel.normalHp * statusmodel.Hplevel;
        statusmodel.restHp = statusmodel.maxHp * statusmodel.HPper;
        statusview.Show(statusmodel);
    }
    public void ChangeDamage(int change)
    {
        statusmodel.restHp -= change;
        if(statusmodel.restHp<0)
        {
            statusmodel.restHp = 0;
        }
        statusview.Show(statusmodel);
    }
    public void ChangeHeal(int change)
    {
        statusmodel.restHp += change;
        if(statusmodel.restHp>statusmodel.maxHp)
        {
            statusmodel.restHp = statusmodel.maxHp;
        }
        statusview.Show(statusmodel);
    }
    public void ChangeBarrier(int change)
    {
        statusmodel.barrier += change;
        statusview.Show(statusmodel);
    }
    public void ChangeSTR(int change)
    {
        statusmodel.sTR += change;
        statusview.Show(statusmodel);
    }
    public void ChangeINT(int change)
    {
        statusmodel.iNT += change;
        statusview.Show(statusmodel);
    }
    public void ChangeDEX(int change)
    {
        statusmodel.dEX += change;
        statusview.Show(statusmodel);
    }
}
