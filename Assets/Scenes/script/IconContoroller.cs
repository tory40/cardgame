using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconContoroller : MonoBehaviour
{
    public IconModel model;
    public IconView view;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        view.OnEndAction = OnEndAction;
    }

    void OnEndAction()
    {
        gameManager.Actcommand(model);
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
    public void Mine()
    {
        model.myact = true;
    }
    public void Click()
    {
        gameManager.SetCommand(model);
    }
    public void SetStart(float time)
    {
        view.SetTime(time);
    }
}
