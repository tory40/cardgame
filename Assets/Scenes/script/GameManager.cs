using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform myfield;
    [SerializeField] Transform enemyfield;
    [SerializeField] IconContoroller actprefab;
    List<IconContoroller> acts = new List<IconContoroller>();
    List<IconContoroller> enemyacts = new List<IconContoroller>();
    // Start is called before the first frame update
    public void Start()
    {
        MyInstance(myfield);
        EnemyInstance(enemyfield);
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
    public void MyInstance()
    {
        acts[0].Init("punch");
    }
    [PunRPC]
    public void EnemyInstance()
    {
        enemyacts[0].Init("punch");
    }
    public void MyInstance(Transform set)
    {
        IconContoroller act = Instantiate(actprefab, set, false);
        acts.Add(act);
    }
    public void EnemyInstance(Transform set)
    {
        IconContoroller act = Instantiate(actprefab, set, false);
        enemyacts.Add(act);
    }
}
