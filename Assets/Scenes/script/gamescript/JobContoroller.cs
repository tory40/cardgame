using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JobContoroller : MonoBehaviour
{
    JobEntity jobEntity;
    public JobView jobview;
    public UnityAction<JobEntity> OnClickAction;
    JobCondition jobCondition;
    public bool mine;
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
        }
        else
        {
            gameManager.enemycondition.SetActive(true);
        }
    }
    public void ChangeColor()
    {
        
    }
}
