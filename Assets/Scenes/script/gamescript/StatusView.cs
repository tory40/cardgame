using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusView : MonoBehaviour
{
    [SerializeField] Text maxHptext;
    [SerializeField] Text restHptext;
    [SerializeField] Text sTRtext;
    [SerializeField] Text iNTtext;
    [SerializeField] Text dEXtext;
    [SerializeField] Image color;
    public void Show(StatusModel model)
    {
        maxHptext.text = model.maxHp.ToString("0.");
        restHptext.text = model.restHp.ToString("0.");
        sTRtext.text = model.sTR.ToString();
        iNTtext.text = model.iNT.ToString();
        dEXtext.text = model.dEX.ToString();
        color.color = model.color;
    }
}
