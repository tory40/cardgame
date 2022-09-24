using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconModel
{
    public string commandname;
    public bool myact;
    public bool open;
    public Sprite icon;
    public int time;
    public int strtime;
    public int inteltime;
    public int dextime;
    public int hp;
    public int str;
    public int intel;
    public int dex;
    public int power;
    public int magic;
    public int speed;
    public int deffence;
    public float criticalhit;
    public float criticalpower;
    public float bighit;
    public float bigpower;
    public float normalhit;
    public float normalpower;
    public float smallhit;
    public float smallpower;
    public int hit;
    public int additionalhit;
    public float healfixed;
    public int healpower;
    public float barrierfixed;
    public int barrierpower;
    public float drain;
    public IconModel(string iconID)
    {
        IconEntity iconEntity = Resources.Load<IconEntity>("CommandList/"+iconID);
        commandname = iconID;
        icon = iconEntity.icon;
        time = iconEntity.time;
        strtime = iconEntity.strtime;
        inteltime = iconEntity.inteltime;
        dextime = iconEntity.dextime;
        hp = iconEntity.hp;
        str = iconEntity.str;
        intel = iconEntity.intel;
        dex = iconEntity.dex;
        power = iconEntity.power;
        magic = iconEntity.magic;
        speed = iconEntity.speed;
        deffence = iconEntity.deffence;
        criticalhit = iconEntity.criticalhit;
        criticalpower = iconEntity.criticalpower;
        bighit = iconEntity.bighit;
        bigpower = iconEntity.bigpower;
        normalhit = iconEntity.normalhit;
        normalpower = iconEntity.normalpower;
        smallhit = iconEntity.smallhit;
        smallpower = iconEntity.smallpower;
        hit = iconEntity.hit;
        additionalhit = iconEntity.additionalhit;
        healfixed = iconEntity.healfixed;
        healpower = iconEntity.healpower;
        barrierfixed = iconEntity.barrierfixed;
        barrierpower = iconEntity.barrierpower;
        drain = iconEntity.drain;
        open = false;
        myact = false;
    }
}
