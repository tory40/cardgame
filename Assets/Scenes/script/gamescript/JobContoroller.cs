using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class JobContoroller : MonoBehaviour
{
    JobEntity jobEntity;
    public JobView jobview;
    public UnityAction<JobEntity> OnClickAction;
    JobCondition jobCondition;
    public bool mine;
    public bool canchange =false;
    Text changebuttontext;
    GameObject change;
    void Start()
    {
       
    }
    public void Set(JobEntity jobEntity)
    {
        this.jobEntity = jobEntity;
        jobview.Show(jobEntity);
    }

    private void Awake()
    {
        jobview = GetComponent<JobView>();
    }
    public void Click()
    {
        OnClickAction?.Invoke(jobEntity);
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(mine)
        {
            gameManager.minecondition.SetActive(true);
            change = GameObject.Find("JobChanger");
            changebuttontext = change.GetComponentInChildren<Text>();
            if (canchange)
            {
                changebuttontext.text = "転生する";
                GameObject.Find("Condition").GetComponent<JobCondition>().canchange=true;
                GameObject.Find("Condition").GetComponent<JobCondition>().Change(true,jobEntity);
            }
            else
            {
                changebuttontext.text = "ステータスが足りません";
                GameObject.Find("Condition").GetComponent<JobCondition>().canchange = false;
                GameObject.Find("Condition").GetComponent<JobCondition>().Change(true,jobEntity);
            }
        }
        else
        {
            gameManager.enemycondition.SetActive(true);
            GameObject.Find("EnemyCondition").GetComponent<JobCondition>().Change(false,jobEntity);
        }
    }
    public void ChangeColor(StatusContoroller status)
    {
        if (jobEntity.needstr>status.statusmodel.sTR|| jobEntity.needdex > status.statusmodel.dEX|| jobEntity.needint > status.statusmodel.iNT)
        {
            jobview.ColorChange(Color.gray);
            canchange = false;
        }
        else
        {
            jobview.ColorChange(Color.white);
            canchange = true;
        }
    }
}
