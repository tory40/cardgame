using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobView : MonoBehaviour
{
    [SerializeField] Text jobname;
    public void Show(JobEntity jobEntity)
    {
        jobname.text = jobEntity.jobname;
    }
}
