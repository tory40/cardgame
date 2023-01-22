using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobView : MonoBehaviour
{
    [SerializeField] Text jobname;
    [SerializeField] Image colordisplay;
    public void Show(JobEntity jobEntity)
    {
        jobname.text = jobEntity.jobname;
    }
    public void ColorChange(Color color)
    {
        colordisplay.color = color;
    }
}
