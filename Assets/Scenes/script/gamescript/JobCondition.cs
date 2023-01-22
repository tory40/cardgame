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
    public bool canchange =false;
    StatusContoroller status;

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
        if (canchange)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().JobClose();
            GameObject.Find("GameManager").GetComponent<GameManager>().Serectjob(setjob);
        }
    }
    public void Change(bool mine,JobEntity job)
    {
        if(mine)
        {
            status = GameObject.Find("Mystatus").GetComponent<StatusContoroller>();
            if(status.statusmodel.sTR<job.needstr)
            {
                strText.color = Color.red;
            }
            else
            {
                strText.color = Color.black;
            }
            if (status.statusmodel.dEX < job.needdex)
            {
                dexText.color = Color.red;
            }
            else
            {
                dexText.color = Color.black;
            }
            if (status.statusmodel.iNT < job.needint)
            {
                intText.color = Color.red;
            }
            else
            {
                intText.color = Color.black;
            }
        }
        else
        {
            status = GameObject.Find("Enemystatus").GetComponent<StatusContoroller>();
            if (status.statusmodel.sTR < job.needstr)
            {
                strText.color = Color.red;
            }
            else
            {
                strText.color = Color.black;
            }
            if (status.statusmodel.dEX < job.needdex)
            {
                dexText.color = Color.red;
            }
            else
            {
                dexText.color = Color.black;
            }
            if (status.statusmodel.iNT < job.needint)
            {
                intText.color = Color.red;
            }
            else
            {
                intText.color = Color.black;
            }
        }
    }
}
