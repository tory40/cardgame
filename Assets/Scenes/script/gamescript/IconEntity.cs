using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Command",menuName ="create new command")]
public class IconEntity : ScriptableObject

{
    public Sprite icon;
    //�g�p����
    public int time;
    public int strtime;
    public int inteltime;
    public int dextime;
    //�X�e�[�^�X�̏㏸
    public int hp;
    public int str;
    public int intel;
    public int dex;
    //�X�e�[�^�X����ɂ����U��
    public int power;
    public int magic;
    public int speed;
    //����̖h��͂��Q��
    public int deffence;
    //�U������̊m���Ɣ{��
    public float criticalhit;
    public float criticalpower;
    public float bighit;
    public float bigpower;
    public float normalhit;
    public float normalpower;
    public float smallhit;
    public float smallpower;
    //�q�b�g��
    public int hit;
    //�ǉ��U����
    public int additionalhit;
    //���@�E�̉񕜁A�o���A
    public float healfixed;
    public int healpower;
    public float barrierfixed;
    public int barrierpower;
    //�h���C������
    public float drain;
}
