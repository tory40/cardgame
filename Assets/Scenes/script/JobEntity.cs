using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Job", menuName = "create new job")]
public class JobEntity : ScriptableObject
{
    public Sprite icon;
    public float hplevel;
    public int needstr;
    public int needint;
    public int needdex;
    public string[] commandlist;
}
