using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconContoroller : MonoBehaviour
{
    IconModel model;
    IconView view;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Awake()
    {
        view = GetComponent<IconView>();
    }
    public void Init(string iconID)
    {
        model = new IconModel(iconID);
        view.Show(model);
    }
    public void Open()
    {
        model.open = true;
        model.myact = true;
    }
    public void Click()
    {
        gameManager.SetCommand(this,model);
    }
}
