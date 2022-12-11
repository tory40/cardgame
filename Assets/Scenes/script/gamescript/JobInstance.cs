using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInstance : MonoBehaviour
{
    [SerializeField] JobCondition jobCondition;
    [SerializeField] JobContoroller serectjobprefab;
    [SerializeField] Transform parent;
    [SerializeField] List<JobEntity> jobentitys;
    List<JobContoroller> jobEntityLists = new List<JobContoroller>();
    public bool mine;
    public StatusContoroller status;
    private void Start()
    {
        if(mine)
        {
            status = GameObject.Find("GameManager").GetComponent<GameManager>().mystatus;
        }
        else
        {
            status = GameObject.Find("GameManager").GetComponent<GameManager>().enemystatus;
        }
        foreach(var jobEntity in jobentitys)
        {
            Spawn(jobEntity);
        }
    }
    public JobContoroller Spawn(JobEntity jobentity)
    {
        JobContoroller jobs = Instantiate(serectjobprefab, parent);
        jobs.mine = mine;
        jobs.Set(jobentity);
        jobs.ChangeColor();
        jobEntityLists.Add(jobs);
        jobs.OnClickAction = jobCondition.UpdateUI;
        return jobs;
    }
}
