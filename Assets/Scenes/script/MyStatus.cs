using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyStatus : MonoBehaviour
{
    public int maxHp;
    public float restHp;
    public int sTR;
    public int iNT;
    public int dEX;
    public float HPper;
    [SerializeField] Text maxHptext;
    [SerializeField] Text restHptext;
    [SerializeField] Text sTRtext;
    [SerializeField] Text iNTtext;
    [SerializeField] Text dEXtext;

    void Start()
    {
        maxHp = 100;
        restHp = 100;
        ChangeMaxHP(0);
        ChangeSTR(10);
        ChangeINT(10);
        ChangeDEX(10);
    }
    void Update()
    {
        
    }
    void ChangeMaxHP(int change)
    {
        HPper = restHp / maxHp;
        maxHp += change;
        maxHptext.text = maxHp.ToString();
        restHp = maxHp * HPper;
        restHptext.text = restHp.ToString();
    }
    void ChangeDamage(int change)
    {
        restHp -= change;
        restHptext.text = restHp.ToString();
    }
    void ChangeSTR(int change)
    {
        sTR += change;
        sTRtext.text = sTR.ToString();
    }
    void ChangeINT(int change)
    {
        iNT += change;
        iNTtext.text = iNT.ToString();
    }
    void ChangeDEX(int change)
    {
        dEX += change;
        dEXtext.text = dEX.ToString();
    }
}
