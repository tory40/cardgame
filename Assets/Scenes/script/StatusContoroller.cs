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
    public void Init()
    {
        statusmodel = new StatusModel();
        statusview.Show(statusmodel);
    }
    void ChangeMaxHP(int change)
    {
        statusmodel.HPper = statusmodel.restHp / statusmodel.maxHp;
        statusmodel.maxHp += change;
        statusmodel.restHp = statusmodel.maxHp * statusmodel.HPper;
        statusview.Show(statusmodel);
    }
    void ChangeDamage(int change)
    {
        statusmodel.restHp -= change;
        statusview.Show(statusmodel);
    }
    void ChangeSTR(int change)
    {
        statusmodel.sTR += change;
        statusview.Show(statusmodel);
    }
    void ChangeINT(int change)
    {
        statusmodel.iNT += change;
        statusview.Show(statusmodel);
    }
    void ChangeDEX(int change)
    {
        statusmodel.dEX += change;
        statusview.Show(statusmodel);
    }
}
