using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class IconView : MonoBehaviour
{
    [SerializeField] Image iconimage;
    [SerializeField] Text iconname;
    [SerializeField] Text time;
    [SerializeField] GameObject panel;
    [SerializeField] Text counttime;
    [SerializeField] Slider slider;

    bool isDown;

    public UnityAction OnEndAction;
    private void Update()
    {
        if(isDown)
        {
            slider.value -= Time.deltaTime;
            counttime.text = slider.value.ToString("0.00");
            if(slider.value <= 0)
            {
                slider.value = 0;
                isDown = false;
                OnEndAction?.Invoke();
            }
        }
    }
    public void Show(IconModel iconmodel)
    {
        iconimage.sprite = iconmodel.icon;
        iconname.text = iconmodel.commandname;
    }
    public void SetTime(float time)
    {
        slider.maxValue = time;
        slider.value = slider.maxValue;
        panel.SetActive(true);
        isDown = true;
    }
}
