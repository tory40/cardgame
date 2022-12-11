using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModel
{
    public float Hplevel;
    public int normalHp;
    public float maxHp;
    public float restHp;
    public int sTR;
    public int iNT;
    public int dEX;
    public float HPper;
    public Color color;
    public int barrier;
    public StatusModel(bool mine)
    {
        normalHp = 1000;
        Hplevel = 1;
        maxHp = 1000;
        restHp = 1000;
        sTR = 10;
        iNT = 10;
        dEX = 10;
        HPper = 1;
        if(mine)
        {
            color = new Color(0f, 0f, 1f, 0.5f);
        }
        else
        {
            color = new Color(1f, 0f, 0f, 0.5f);
        }
    }
}
