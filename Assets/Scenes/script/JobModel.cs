using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobModel
{
    public Sprite icon;
    public float hplevel;
    public int needstr;
    public int needint;
    public int needdex;
    public List<string> commandList;
    public JobModel(string JobID)
    {
        JobEntity jobEntity = Resources.Load<JobEntity>("JobList/" + JobID);
        icon = jobEntity.icon;
        hplevel = jobEntity.hplevel;
        needstr = jobEntity.needstr;
        needint = jobEntity.needint;
        needdex = jobEntity.needdex;
        commandList = new List<string>(jobEntity.commandlist);
    }
}
