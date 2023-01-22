using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobChangeContoroller : MonoBehaviour
{
    public bool mine;
    public bool command=false;
    public JobEntity sersctjob;
    [SerializeField] Image iconimage;
    [SerializeField] public Text iconname;
    [SerializeField] GameObject panel;
    [SerializeField] Text counttime;
    [SerializeField] Slider slider;
    public bool isDown;
    public void Click()
    {
        if (!command)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().JobClick(mine);
        }
        else
        {

        }
    }
    public void JobChange()
    {
        slider.maxValue = sersctjob.time;
        slider.value = slider.maxValue;
        panel.SetActive(true);
        isDown = true;
    }
    private void Update()
    {
        if (isDown)
        {
            slider.value -= Time.deltaTime;
            counttime.text = slider.value.ToString("0.00");
            if (slider.value <= 0)
            {
                slider.value = 0;
                isDown = false;
                GameObject.Find("GameManager").GetComponent<GameManager>().initjob = sersctjob;
                if (mine)
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().ActMycommand();
                }
                else
                {
                    GameObject.Find("GameManager").GetComponent<GameManager>().ActEnemycommand();
                }
            }
        }
    }
}
