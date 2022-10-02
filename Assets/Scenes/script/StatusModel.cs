using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModel
{
    public int maxHp;
    public float restHp;
    public int sTR;
    public int iNT;
    public int dEX;
    public float HPper;
    public StatusModel()
    {
        maxHp = 100;
        restHp = 100;
        sTR = 10;
        iNT = 10;
        dEX = 10;
        HPper = 0;
    }
}
