using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconView : MonoBehaviour
{
    [SerializeField] Image iconimage;
    public void Show(IconModel iconmodel)
    {
        iconimage.sprite = iconmodel.icon;
    }
}
