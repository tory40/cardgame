using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Command",menuName ="create new command")]
public class IconEntity : ScriptableObject

{
    public Sprite icon;
    //使用時間
    public int time;
    public int strtime;
    public int inteltime;
    public int dextime;
    //ステータスの上昇
    public int hp;
    public int str;
    public int intel;
    public int dex;
    //ステータスを基にした攻撃
    public int power;
    public int magic;
    public int speed;
    //相手の防御力を参照
    public int deffence;
    //攻撃判定の確率と倍率
    public float criticalhit;
    public float criticalpower;
    public float bighit;
    public float bigpower;
    public float normalhit;
    public float normalpower;
    public float smallhit;
    public float smallpower;
    //ヒット数
    public int hit;
    //追加攻撃数
    public int additionalhit;
    //魔法職の回復、バリア
    public float healfixed;
    public int healpower;
    public float barrierfixed;
    public int barrierpower;
    //ドレイン割合
    public float drain;
}
