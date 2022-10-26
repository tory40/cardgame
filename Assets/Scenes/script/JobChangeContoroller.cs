using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobChangeContoroller : MonoBehaviour
{
    public bool mine;
    public void Click()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().JobClick(mine);
    }
}
