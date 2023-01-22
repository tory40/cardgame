using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform mystatusfield;
    [SerializeField] Transform enemystatusfield;
    [SerializeField] StatusContoroller statussample;
    [SerializeField] Transform myfield;
    [SerializeField] Transform enemyfield;
    [SerializeField] Transform mycommand;
    [SerializeField] Transform enemycommand;
    [SerializeField] IconContoroller actprefab;
    [SerializeField] JobChangeContoroller jobChangeprefab;
    List<IconContoroller> acts = new List<IconContoroller>();
    List<IconContoroller> enemyacts = new List<IconContoroller>();
    List<IconContoroller> actscommand = new List<IconContoroller>();
    List<IconContoroller> enemyactscommand = new List<IconContoroller>();
    List<JobChangeContoroller> jobsInstance = new List<JobChangeContoroller>();
    List<JobChangeContoroller> enemyjobsInstance = new List<JobChangeContoroller>();
    List<bool> actsjob = new List<bool>();
    List<bool> enemyactsjob = new List<bool>();
    string sendact;
    [SerializeField] Text[] intpower;
    [SerializeField] Text[] inteasy;
    [SerializeField] GameObject initbutton;
    [SerializeField] GameObject status;
    float randomper;
    float criticalper;
    float bigper;
    float normalper;
    float smallper;
    float missper;
    public StatusContoroller mystatus;
    public StatusContoroller enemystatus;
    [SerializeField] Image playercolor;
    [SerializeField] Text myjobname;
    [SerializeField] Text enemyjobname;
    JobEntity changejob;
    JobChangeContoroller myjobChange;
    JobChangeContoroller enemyjobChange;
    public void Start()
    {
        mystatus = Instantiate(statussample, mystatusfield, false);
        mystatus.Init(true);
        enemystatus = Instantiate(statussample, enemystatusfield, false);
        enemystatus.Init(false);
        StartGame();
    }
    public void ChangeWork()
    {
        for (int i = 0; i < changejob.commandlist.Length; ++i)
        {
            MyInstance(changejob.commandlist[i]);
            photonView.RPC(nameof(EnemyInstance), RpcTarget.Others, changejob.commandlist[i]);
        }
        MyJobInstance();
        photonView.RPC(nameof(EnemyJobInstance), RpcTarget.Others);
    }
    public void MyJobInstance()
    {
        myjobChange = Instantiate(jobChangeprefab, myfield, false);
        myjobChange.mine = true;
    }
    [PunRPC]
    public void EnemyJobInstance()
    {
        enemyjobChange = Instantiate(jobChangeprefab, enemyfield, false);
        enemyjobChange.mine = false;
    }
    [PunRPC]
    public void EnemyJobName(string jobname)
    {
        enemyjobname.text = jobname;
    }
    public void StartGame()
    {
        photonView.RPC(nameof(StartJob), RpcTarget.Others, "ñ`åØé“");
    }
    [PunRPC]
    public void StartJob(string job)
    {
        ChangeJob(job);
        photonView.RPC(nameof(ChangeJob), RpcTarget.Others, job);
    }
    public void Serectjob(JobEntity setjob)
    {
        if (actsjob.Count<3)
        {
            JobChangeContoroller job = Instantiate(jobChangeprefab, mycommand, false);
            job.mine = true;
            job.command = true;
            job.iconname.text = setjob.name;
            job.sersctjob = setjob;
            jobsInstance.Add(job);
            actsjob.Add(false);
            if (actsjob.Count == 1)
            {
                MyCommandView();
            }
            photonView.RPC(nameof(EnemySerectJob), RpcTarget.Others, setjob.name);
        }
        else
        {
            Debug.Log("ÉRÉ}ÉìÉhÇÕéOÇ¬Ç‹Ç≈!");
        }
    }
    [PunRPC]
    public void EnemySerectJob(string setjob)
    {
        JobChangeContoroller job = Instantiate(jobChangeprefab, enemycommand, false);
        job.mine = false;
        job.sersctjob = Resources.Load<JobEntity>("JobList/" + setjob);
        enemyjobsInstance.Add(job);
        enemyactsjob.Add(false);
        if (enemyactsjob.Count == 1)
        {
            EnemyCommandView();
        }
    }
    [PunRPC]
    public void ChangeJob(string job)
    {
        foreach (Transform child in myfield)
        {
            Destroy(child.gameObject);
        }
        photonView.RPC(nameof(BBB), RpcTarget.Others);
        changejob = Resources.Load<JobEntity>("JobList/" + job);
        myjobname.text = changejob.jobname;
        photonView.RPC(nameof(EnemyJobName), RpcTarget.Others, changejob.jobname);
        ChangeWork();
    }
    [PunRPC]
    public void BBB()
    {
        foreach (Transform child in enemyfield)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MyInstance(string command)
    {
            IconContoroller act = Instantiate(actprefab, myfield, false);
            act.Init(command);
            act.Open();
            acts.Add(act);
    }
    [PunRPC]
    public void EnemyInstance(string command)
    {
            IconContoroller act = Instantiate(actprefab, enemyfield, false);
            act.Init(command);
            enemyacts.Add(act);
    }
    [SerializeField] GameObject myopen;
    [SerializeField] GameObject myclose;
    [SerializeField] GameObject enemyopen;
    [SerializeField] GameObject enemyclose;
    [SerializeField] public GameObject minecondition;
    [SerializeField] public GameObject enemycondition;
    public void JobClick(bool mine)
    {
        if (mine)
        {
            myopen.SetActive(true);
            myclose.SetActive(false);
            minecondition.SetActive(false);
            GameObject.Find("MyJobCheck").GetComponent<JobInstance>().StatusUpdate(mystatus);
        }
        else
        {
            enemyopen.SetActive(true);
            enemyclose.SetActive(false);
            enemycondition.SetActive(false);
            GameObject.Find("EnemyJobCheck").GetComponent<JobInstance>().StatusUpdate(enemystatus);
        }
    }
    public void JobClose()
    {
            myopen.SetActive(false);
            myclose.SetActive(true);
    }
    public void SetCommand(IconModel model)
    {
        sendact = model.commandname;
        if(model.open)
        {
            initbutton.gameObject.SetActive(true);
        }
        else
        {
            initbutton.gameObject.SetActive(false);
        }
        SetRule(model);
        if (model.myact)
        {
            SetRule2(model,mystatus.statusmodel,enemystatus.statusmodel);
        }
        else
        {
            SetRule2(model,enemystatus.statusmodel, mystatus.statusmodel);
        }
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
        intpower[8].text = model.healfixed.ToString("0.0");
        intpower[9].text = model.healpower.ToString();
        intpower[10].text = model.barrierfixed.ToString("0.0");
        intpower[11].text = model.barrierpower.ToString();
        intpower[12].text = model.power.ToString();
        intpower[13].text = model.magic.ToString();
        intpower[14].text = model.speed.ToString();
        intpower[15].text = model.deffence.ToString();
        intpower[16].text = model.criticalhit.ToString();
        intpower[17].text = model.criticalpower.ToString("0.0");
        intpower[18].text = model.bighit.ToString();
        intpower[19].text = model.bigpower.ToString("0.0");
        intpower[20].text = model.normalhit.ToString();
        intpower[21].text = model.normalpower.ToString("0.0");
        intpower[22].text = model.smallhit.ToString();
        intpower[23].text = model.smallpower.ToString("0.0");
        intpower[24].text = model.hit.ToString();
        intpower[25].text = model.additionalhit.ToString();
        intpower[26].text = model.drain.ToString("0.00");
    }
    int phy;
    float additional;
    public void SetRule2(IconModel model,StatusModel statusA,StatusModel statusB)
    {
        playercolor.color = statusA.color;
        inteasy[0].text = model.commandname;
        inteasy[1].text = ((model.time) + ((model.strtime) / (statusA.sTR)) + ((model.inteltime) / (statusA.iNT)) + ((model.dextime) / (statusA.dEX))).ToString("0.0")+"sec";
        inteasy[2].text = model.hp.ToString();
        inteasy[3].text = model.str.ToString();
        inteasy[4].text = model.intel.ToString();
        inteasy[5].text = model.dex.ToString();
        inteasy[6].text = (((model.healfixed) * (statusA.maxHp)) + ((model.healpower) * (statusA.iNT))).ToString();
        inteasy[7].text = (((model.barrierfixed) * (statusA.maxHp)) + ((model.barrierpower) * (statusA.iNT))).ToString();
        if((model.power+model.speed)==0)
        {
            phy = 0;
        }
        else if (((model.power) * (statusA.sTR)) + ((model.speed) * (statusA.dEX)) - ((model.deffence) * (statusB.sTR))<1)
        {
            phy = 1;
        }
        else
        {
            phy = ((model.power) * (statusA.sTR)) + ((model.speed) * (statusA.dEX)) - ((model.deffence) * (statusB.sTR));
        }
        inteasy[8].text = (phy + ((model.magic) * (statusA.iNT))).ToString();
        inteasy[9].text = "Å~"+model.criticalpower.ToString("0.0");
        if (model.smallhit != 0) 
        {
            randomper = (((float)statusB.dEX / statusA.dEX) * 100);
            Debug.Log(randomper);
            if (randomper < model.criticalhit)
            {
                criticalper = 100f;
            }
            else
            {
                criticalper = (model.criticalhit / randomper) * 100;
            }
            inteasy[10].text = criticalper.ToString("0.0") + "%";
            inteasy[11].text = "Å~" + model.bigpower.ToString("0.0");
            if (randomper < model.criticalhit)
            {
                bigper = 0f;
            }
            else if (randomper > model.bighit)
            {
                bigper = ((model.bighit - model.criticalhit) / randomper * 100);
            }
            else
            {
                bigper = ((randomper - model.criticalhit) / randomper * 100);
            }
            inteasy[12].text = bigper.ToString("0.0") + "%";
            inteasy[13].text = "Å~" + model.normalpower.ToString("0.0");
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
            inteasy[14].text = normalper.ToString("0.0") + "%";
            inteasy[15].text = "Å~" + model.smallpower.ToString("0.0");
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
            inteasy[16].text = smallper.ToString("0.0") + "%";
            if (model.smallhit == 0)
            {
                missper = 0f;
            }
            else if (randomper < model.smallhit)
            {
                missper = 0f;
            }
            else
            {
                missper = ((randomper - model.smallhit) / randomper * 100);
            }
            inteasy[17].text = missper.ToString("0.0") + "%";
            if (model.additionalhit != 0)
            {
                additional = statusA.dEX / model.additionalhit;
            }
            else
            {
                additional = 0;
            }
            inteasy[18].text = (model.hit + additional).ToString("0.00");
            inteasy[19].text = "Å~0.0";
        }
        else
        {
            inteasy[9].text = "--";
            inteasy[10].text = "--";
            inteasy[11].text = "--";
            inteasy[12].text = "--";
            inteasy[13].text = "--";
            inteasy[14].text = "--";
            inteasy[15].text = "--";
            inteasy[16].text = "--";
            inteasy[17].text = "--";
            inteasy[19].text = "--";
        }
    }
    public void CommandAttack()
    {
        if (actsjob.Count<3) 
        {
            MyInstance2(sendact);
            photonView.RPC(nameof(EnemyInstance2), RpcTarget.Others, sendact);
        }
        else
        {
            Debug.Log("ÉRÉ}ÉìÉhÇÕéOÇ¬Ç‹Ç≈!");
        }
    }

    public void MyInstance2(string command)
    {
        IconContoroller act = Instantiate(actprefab, mycommand, false);
        act.Init(command);
        act.Mine();
        actscommand.Add(act);
        actsjob.Add(true);
        if(actsjob.Count ==1)
        {
            MyCommandView();
        }
    }
    [PunRPC]
    public void EnemyInstance2(string command)
    {
        IconContoroller act = Instantiate(actprefab, enemycommand, false);
        act.Init(command);
        enemyactscommand.Add(act);
        enemyactsjob.Add(true);
        if (enemyactsjob.Count == 1)
        {
            EnemyCommandView();
        }
    }
    public void MyCommandView()
    {
        if (!(enemystatus.statusmodel.restHp <= 0)&& !(mystatus.statusmodel.restHp <= 0))
        {
            if (actsjob[0])
            {
                IconModel model = actscommand[0].GetComponent<IconContoroller>().model;
                float time = model.time + (model.strtime / mystatus.statusmodel.sTR) + (model.inteltime / mystatus.statusmodel.iNT) + (model.dextime / mystatus.statusmodel.dEX);
                actscommand[0].SetStart(time);
            }
            else
            {
                jobsInstance[0].JobChange();
            }
        }
    }
    public void EnemyCommandView()
    {
        if (!(enemystatus.statusmodel.restHp <= 0) && !(mystatus.statusmodel.restHp <= 0))
        {
            if (enemyactsjob[0])
            {
                IconModel model = enemyactscommand[0].GetComponent<IconContoroller>().model;
                float time = model.time + (model.strtime / enemystatus.statusmodel.sTR) + (model.inteltime / enemystatus.statusmodel.iNT) + (model.dextime / enemystatus.statusmodel.dEX);
                enemyactscommand[0].SetStart(time);
            }
            else
            {
                enemyjobsInstance[0].JobChange();
            }
        }
    }
    public IconModel initmodel;
    public JobEntity initjob;
    public void ActMycommand()
    {
        if (actsjob[0])
        {
            Destroy(actscommand[0].gameObject);
            actscommand.RemoveAt(0);
            actsjob.RemoveAt(0);
            Actprocess(mystatus,initmodel);
        }
        else
        {
            Destroy(jobsInstance[0].gameObject);
            jobsInstance.RemoveAt(0);
            actsjob.RemoveAt(0);
            Jobprocess(true,initjob);
        }
        if (actsjob.Count > 0)
        {
            if (actsjob[0])
            {
                IconModel nextmodel = actscommand[0].GetComponent<IconContoroller>().model;
                float time = nextmodel.time + (nextmodel.strtime / mystatus.statusmodel.sTR) + (nextmodel.inteltime / mystatus.statusmodel.iNT) + (nextmodel.dextime / mystatus.statusmodel.dEX);
                actscommand[0].SetStart(time);
            }
            else
            {
                jobsInstance[0].JobChange();
            }
        }
    }
    public void ActEnemycommand()
    {
        if (enemyactsjob[0])
        {
            Destroy(enemyactscommand[0].gameObject);
            enemyactscommand.RemoveAt(0);
            enemyactsjob.RemoveAt(0);
            Actprocess(enemystatus, initmodel);
        }
        else
        {
            Destroy(enemyjobsInstance[0].gameObject);
            enemyjobsInstance.RemoveAt(0);
            enemyactsjob.RemoveAt(0);
            Jobprocess(false, initjob);
        }
        if (enemyactsjob.Count > 0)
        {
            if (enemyactsjob[0])
            {
                IconModel nextmodel = enemyactscommand[0].GetComponent<IconContoroller>().model;
                float time = nextmodel.time + (nextmodel.strtime / enemystatus.statusmodel.sTR) + (nextmodel.inteltime / enemystatus.statusmodel.iNT) + (nextmodel.dextime / enemystatus.statusmodel.dEX);
                enemyactscommand[0].SetStart(time);
            }
            else
            {
                enemyjobsInstance[0].JobChange();
            }
        }
    }
    public void Jobprocess(bool mine,JobEntity jobentity)
    {
        if(mine)
        {
            ChangeJob(jobentity.name);
        }
    }
    float hitinit;
    int hitcount;
    float randomserect;
    float damage;
    float hitrange;
    public void Actprocess(StatusContoroller statusA, IconModel model)
    {
        statusA.ChangeMaxHP(model.hp);
        statusA.ChangeSTR(model.str);
        statusA.ChangeINT(model.intel);
        statusA.ChangeDEX(model.dex);
        statusA.ChangeHeal((int)((model.healpower * statusA.statusmodel.iNT) + (model.healfixed * statusA.statusmodel.maxHp)));
        statusA.ChangeBarrier((int)((model.barrierpower * statusA.statusmodel.iNT) + (model.barrierfixed * statusA.statusmodel.maxHp)));
        if(model.myact)
        {
            Mydamage(model);
        }
    }
    public void Mydamage(IconModel model)
    {
        if (model.additionalhit == 0)
        {
            hitinit = model.hit;
        }
        else
        {
            hitinit = model.hit + (mystatus.statusmodel.dEX / model.additionalhit);
        }
        hitcount = (int)hitinit;
        randomserect = Random.Range(0.00f, 1.00f);
        if (randomserect < hitinit % 1)
        {
            hitcount++;
        }
        damage = (model.power * mystatus.statusmodel.sTR) + (model.speed * mystatus.statusmodel.dEX) - (model.deffence * enemystatus.statusmodel.sTR);
        if (model.power == 0 && model.speed == 0)
        {
            damage = 0;
        }
        else if (((model.power * mystatus.statusmodel.sTR) + (model.speed * mystatus.statusmodel.dEX) - (model.deffence * enemystatus.statusmodel.sTR)) < 1)
        {
            damage = 1;
        }
        damage = damage + (model.magic * mystatus.statusmodel.iNT);
        for (int i = 0; i < hitcount; ++i)
        {
            hitrange = Random.Range(0.00f, (100 * enemystatus.statusmodel.dEX / mystatus.statusmodel.dEX));
            if (hitrange < model.criticalhit)
            {
                enemystatus.ChangeDamage((int)(damage * model.criticalpower));
                if (model.drain != 0)
                {
                    mystatus.ChangeHeal((int)(model.drain * damage * model.criticalpower));
                }
            }
            else if (hitrange < model.bighit)
            {
                enemystatus.ChangeDamage((int)(damage * model.bigpower));
                if (model.drain != 0)
                {
                    mystatus.ChangeHeal((int)(model.drain * damage * model.bigpower));
                }
            }
            else if (hitrange < model.normalhit)
            {
                enemystatus.ChangeDamage((int)(damage * model.normalpower));
                if (model.drain != 0)
                {
                    mystatus.ChangeHeal((int)(model.drain * damage * model.normalpower));
                }
            }
            else if (hitrange < model.smallhit)
            {
                enemystatus.ChangeDamage((int)(damage * model.smallpower));
                if (model.drain != 0)
                {
                    mystatus.ChangeHeal((int)(model.drain * damage * model.smallpower));
                }
            }
            else
            {
                enemystatus.ChangeDamage(0);
                if (model.drain != 0)
                {
                    mystatus.ChangeHeal(0);
                }
            }
            photonView.RPC(nameof(Enemydamage), RpcTarget.Others, model.commandname,hitrange,damage);
            if(enemystatus.statusmodel.restHp<=0)
            {
                Debug.Log("You Win");
                if (actsjob.Count == 0)
                {

                }
                else if (actsjob[0])
                {
                    actscommand[0].view.isDown = false;
                }
                else
                {
                    jobsInstance[0].isDown = false;
                }
                if (enemyactsjob.Count == 0)
                {

                }
                else if (enemyactsjob[0])
                {
                    enemyactscommand[0].view.isDown = false;
                }
                else
                {
                    enemyjobsInstance[0].isDown = false;
                }
            }
        }
    }
    [PunRPC]
    public void Enemydamage(string acter,float hitrange,float actdamage)
    {
        IconEntity iconEntity = Resources.Load<IconEntity>("CommandList/" + acter);
        if (hitrange < iconEntity.criticalhit)
        {
            mystatus.ChangeDamage((int)(actdamage * iconEntity.criticalpower));
            if (iconEntity.drain != 0)
            {
                enemystatus.ChangeHeal((int)(iconEntity.drain * actdamage * iconEntity.criticalpower));
            }
        }
        else if (hitrange < iconEntity.bighit)
        {
            mystatus.ChangeDamage((int)(actdamage * iconEntity.bigpower));
            if (iconEntity.drain != 0)
            {
                enemystatus.ChangeHeal((int)(iconEntity.drain * actdamage * iconEntity.bigpower));
            }
        }
        else if (hitrange < iconEntity.normalhit)
        {
            mystatus.ChangeDamage((int)(actdamage * iconEntity.normalpower));
            if (iconEntity.drain != 0)
            {
                enemystatus.ChangeHeal((int)(iconEntity.drain * actdamage * iconEntity.normalpower));
            }
        }
        else if (hitrange < iconEntity.smallhit)
        {
            mystatus.ChangeDamage((int)(actdamage * iconEntity.smallpower));
            if (iconEntity.drain != 0)
            {
                enemystatus.ChangeHeal((int)(iconEntity.drain * actdamage * iconEntity.smallpower));
            }
        }
        else
        {
            mystatus.ChangeDamage(0);
            if (iconEntity.drain != 0)
            {
                enemystatus.ChangeHeal(0);
            }
        }
        if (mystatus.statusmodel.restHp <= 0)
        {
            Debug.Log("You Lose");
            if(actsjob.Count==0)
            {

            }
            else if(actsjob[0])
            {
                actscommand[0].view.isDown = false;
            }
            else
            {
                jobsInstance[0].isDown = false;
            }
            if (enemyactsjob.Count == 0)
            {

            }
            else if (enemyactsjob[0])
            {
                enemyactscommand[0].view.isDown = false;
            }
            else
            {
                enemyjobsInstance[0].isDown = false;
            }

        }
    }
}
