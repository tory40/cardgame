using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconView : MonoBehaviour
{
    [SerializeField] Image iconimage;
    [SerializeField] Text iconname;
    public void Show(IconModel iconmodel)
    {
        iconimage.sprite = iconmodel.icon;
        iconname.text = iconmodel.commandname;
    }
}
