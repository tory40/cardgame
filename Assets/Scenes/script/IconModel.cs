using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconModel
{
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
    public int criticalhit;
    public int criticalpower;
    public int bighit;
    public int bigpower;
    public int normalhit;
    public int normalpower;
    public int smallhit;
    public int smallpower;
    public int misshit;
    public int hit;
    public int additionalhit;
    public int healfixed;
    public int healpower;
    public int barrierfixed;
    public int barrierpower;
    public int drain;
    public IconModel(string iconID)
    {
        IconEntity iconEntity = Resources.Load<IconEntity>("CommandList/"+iconID);
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
        misshit = iconEntity.misshit;
        hit = iconEntity.hit;
        additionalhit = iconEntity.additionalhit;
        healfixed = iconEntity.healfixed;
        healpower = iconEntity.healpower;
        barrierfixed = iconEntity.barrierfixed;
        barrierpower = iconEntity.barrierpower;
        drain = iconEntity.drain;
    }
}
