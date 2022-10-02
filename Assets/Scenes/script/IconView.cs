using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconView : MonoBehaviour
{
    [SerializeField] Image iconimage;
    [SerializeField] Text iconname;
    [SerializeField] Text time;
    [SerializeField] GameObject panel;
    [SerializeField] Text counttime;
    public void Show(IconModel iconmodel)
    {
        iconimage.sprite = iconmodel.icon;
        iconname.text = iconmodel.commandname;
    }
    public void SetTime(float time)
    {
        panel.SetActive(true);
    }
}
