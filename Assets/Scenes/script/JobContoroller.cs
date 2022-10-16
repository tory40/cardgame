using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobContoroller : MonoBehaviour
{
    public JobModel jobmodel;
    public JobView jobview;
    void Start()
    {
        
    }

    private void Awake()
    {
        jobview = GetComponent<JobView>();
    }
    public void Init(string JobID)
    {
        jobmodel = new JobModel(JobID);
        jobview.Show(jobmodel);
    }
}
