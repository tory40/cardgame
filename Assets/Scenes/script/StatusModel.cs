using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModel
{
    public int maxHp;
    public int restHp;
    public int sTR;
    public int iNT;
    public int dEX;
    public float HPper;
    public Color color;
    public int barrier;
    public StatusModel(bool mine)
    {
        maxHp = 100;
        restHp = 100;
        sTR = 10;
        iNT = 10;
        dEX = 10;
        HPper = 0;
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
