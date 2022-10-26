using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobCondition : MonoBehaviour
{
    JobEntity setjob;
    [SerializeField] Text nameText;
    [SerializeField] Text hpperText;
    [SerializeField] Text timeText;
    [SerializeField] Text strText;
    [SerializeField] Text intText;
    [SerializeField] Text dexText;

    public void UpdateUI(JobEntity jobEntity)
    {
        setjob = jobEntity;
        nameText.text = jobEntity.jobname;
        hpperText.text = "Å~"+jobEntity.hplevel.ToString("0.0");
        timeText.text = jobEntity.time.ToString("0.0")+"sec";
        strText.text = jobEntity.needstr.ToString();
        intText.text = jobEntity.needint.ToString();
        dexText.text = jobEntity.needdex.ToString();
    }

    public void JobChange()
    {

    }
}
