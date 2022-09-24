using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform myfield;
    [SerializeField] Transform enemyfield;
    [SerializeField] Transform mycommand;
    [SerializeField] Transform enemycommand;
    [SerializeField] IconContoroller actprefab;
    List<IconContoroller> acts = new List<IconContoroller>();
    List<IconContoroller> enemyacts = new List<IconContoroller>();
    List<IconContoroller> actscommand = new List<IconContoroller>();
    List<IconContoroller> enemyactscommand = new List<IconContoroller>();
    IconContoroller sendact;
    [SerializeField] Text[] intpower;
    [SerializeField] Text[] inteasy;
    [SerializeField] GameObject initbutton;
    [SerializeField] GameObject status;
    MyStatus myStatus;
    float randomper;
    float criticalper;
    float bigper;
    float normalper;
    float smallper;
    float missper;
    EnemyStatus enemyStatus;
    // Start is called before the first frame update
    public void Start()
    {
        myStatus = status.gameObject.GetComponent<MyStatus>();
        enemyStatus = status.gameObject.GetComponent<EnemyStatus>();
    }
    public void AAA()
    {
        MyInstance();
        photonView.RPC(nameof(EnemyInstance), RpcTarget.Others);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [PunRPC]
    public void MyInstance()
    {
            IconContoroller act = Instantiate(actprefab, myfield, false);
            act.Init("punch");
            act.Open();
            acts.Add(act);
    }
    [PunRPC]
    public void EnemyInstance()
    {
            IconContoroller act = Instantiate(actprefab, enemyfield, false);
            act.Init("punch");
            enemyacts.Add(act);
    }
    public void Debu(IconContoroller icon)
    {
        IconContoroller act = Instantiate(icon, mycommand, false);
        actscommand.Add(act);
    }
    
    public void SetCommand(IconContoroller act,IconModel model)
    {
        sendact = act;
        if(model.open)
        {
            initbutton.gameObject.SetActive(true);
        }
        else
        {
            initbutton.gameObject.SetActive(false);
        }
        SetRule(model);
        SetRule2(model);
    }
    public void SetRule(IconModel model)
    {
        intpower[0].text = model.time.ToString();
        intpower[1].text = model.strtime.ToString();
        intpower[2].text = model.inteltime.ToString();
        intpower[3].text = model.dextime.ToString();
        intpower[4].text = model.hp.ToString();
        intpower[5].text = model.str.ToString();
        intpower[6].text = model.intel.ToString();
        intpower[7].text = model.dex.ToString();
        intpower[8].text = model.healfixed.ToString();
        intpower[9].text = model.healpower.ToString();
        intpower[10].text = model.barrierfixed.ToString();
        intpower[11].text = model.barrierpower.ToString();
        intpower[12].text = model.power.ToString();
        intpower[13].text = model.magic.ToString();
        intpower[14].text = model.speed.ToString();
        intpower[15].text = model.deffence.ToString();
        intpower[16].text = model.criticalhit.ToString();
        intpower[17].text = model.criticalpower.ToString();
        intpower[18].text = model.bighit.ToString();
        intpower[19].text = model.bigpower.ToString();
        intpower[20].text = model.normalhit.ToString();
        intpower[21].text = model.normalpower.ToString();
        intpower[22].text = model.smallhit.ToString();
        intpower[23].text = model.smallpower.ToString();
        intpower[24].text = model.hit.ToString();
        intpower[25].text = model.additionalhit.ToString();
        intpower[26].text = model.drain.ToString();
    }
    int phy;
    public void SetRule2(IconModel model)
    {
        if(model.myact)
        {
            MyStatus statusA = myStatus;
            EnemyStatus statusB = enemyStatus;
        }
        else
        {
            MyStatus statusB = myStatus;
            EnemyStatus statusA = enemyStatus;
        }
        inteasy[0].text = model.commandname;
        inteasy[1].text = ((model.time) + ((model.strtime) / (myStatus.sTR)) + ((model.inteltime) / (myStatus.iNT)) + ((model.dextime) / (myStatus.dEX))).ToString()+"sec";
        inteasy[2].text = model.hp.ToString();
        inteasy[3].text = model.str.ToString();
        inteasy[4].text = model.intel.ToString();
        inteasy[5].text = model.dex.ToString();
        inteasy[6].text = (((model.healfixed) * (myStatus.maxHp)) + ((model.healpower) * (myStatus.iNT))).ToString();
        inteasy[7].text = (((model.barrierfixed) * (myStatus.maxHp)) + ((model.barrierpower) * (myStatus.iNT))).ToString();
        if((model.power+model.speed)==0)
        {
            phy = 0;
        }
        else if (((model.power) * (myStatus.sTR)) + ((model.speed) * (myStatus.dEX)) - ((model.deffence) * (enemyStatus.sTR))<1)
        {
            phy = 1;
        }
        else
        {
            phy = ((model.power) * (myStatus.sTR)) + ((model.speed) * (myStatus.dEX)) - ((model.deffence) * (enemyStatus.sTR));
        }
        inteasy[8].text = (phy + ((model.magic) * (myStatus.iNT))).ToString();
        inteasy[9].text = "Å~"+model.criticalpower.ToString();
        randomper = (enemyStatus.dEX) / (myStatus.dEX) * 100;
        if (randomper<model.criticalhit)
        {
            criticalper = 100f;
        }
        else
        {
            criticalper = (model.criticalhit / randomper) * 100;
        }
        inteasy[10].text = criticalper.ToString();
        inteasy[11].text = "Å~" + model.bigpower.ToString();
        if (randomper < model.criticalhit)
        {
            bigper = 0f;
        }
        else if(randomper > model.bighit)
        {
            bigper = ((model.bighit - model.criticalhit) / randomper * 100);
        }
        else
        {
            bigper = ((randomper - model.criticalhit) / randomper * 100);
        }
        inteasy[12].text = bigper.ToString();
        inteasy[13].text = "Å~" + model.normalpower.ToString();
        if (randomper < model.bighit)
        {
            normalper = 0f;
        }
        else if (randomper > model.normalhit)
        {
            normalper = ((model.normalhit - model.bighit) / randomper * 100);
        }
        else
        {
            normalper = ((randomper - model.bighit) / randomper * 100);
        }
        inteasy[14].text = normalper.ToString();
        inteasy[15].text = "Å~" + model.smallpower.ToString();
        if (randomper < model.normalhit)
        {
            smallper = 0f;
        }
        else if (randomper > model.smallhit)
        {
            smallper = ((model.smallhit - model.normalhit) / randomper * 100);
        }
        else
        {
            smallper = ((randomper - model.normalhit) / randomper * 100);
        }
        inteasy[16].text = smallper.ToString();
        if (randomper < model.smallhit)
        {
            missper = 0f;
        }
        else
        {
            missper = ((randomper - model.smallhit) / randomper * 100);
        }
        inteasy[17].text = missper.ToString();
        inteasy[18].text = (model.hit + (myStatus.dEX / model.additionalhit)).ToString();
    }
}
