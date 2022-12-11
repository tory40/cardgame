using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changepanel : MonoBehaviour
{
    [SerializeField] GameObject panela;
    [SerializeField] GameObject panelb;
    public bool panel =true;
    public void Change()
    {
        if(panel)
        {
            panela.gameObject.SetActive(true);
            panelb.gameObject.SetActive(false);
        }
        else
        {
            panela.gameObject.SetActive(false);
            panelb.gameObject.SetActive(true);
        }
        panel = !panel;
    }

}
