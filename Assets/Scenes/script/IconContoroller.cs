using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconContoroller : MonoBehaviour
{
   IconModel model;
    IconView view;
    private void Awake()
    {
        view = GetComponent<IconView>();
    }
    public void Init(string iconID)
    {
        model = new IconModel(iconID);
        view.Show(model);
    }
}
