using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PhotonSet : MonoBehaviourPunCallbacks
{
    string roomtype;
    bool firstInit=true;
    bool firstPlayer;
    bool firstRoom = true;
    public void Wait(string type)
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        roomtype = type;
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
        {
        if (!firstInit)
        {
            Debug.Log(PhotonNetwork.CountOfPlayers);
            if (PhotonNetwork.CountOfPlayers >= 2)
            {
                Debug.Log("a");
                firstInit = true;
                RandomRoom();
            }
        }
        }
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        // 退出時にも呼ばれる
        try
        {
            if (firstRoom)
            {
                firstInit = false;
                firstRoom = false;
                PhotonNetwork.JoinOrCreateRoom(roomtype, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
            }
        }
        catch
        {
            Debug.Log("ルームが満員です");
        }
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.CountOfPlayers==1)
        {
            firstPlayer = false;
            Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
        }
        else if (PhotonNetwork.CountOfPlayers == 2)
        {
            firstPlayer = true;
            Debug.Log("abc");
            Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
        }
        else
        {
            Debug.Log("人数設定エラー"+ PhotonNetwork.CountOfPlayers.ToString());
        }
        firstInit = false;
    }
    public void RandomRoom()
    {
        if(firstPlayer)
        {
            Debug.Log("i");
            int random =Random.Range(0, 10000);
            photonView.RPC(nameof(RanDomRoom2), RpcTarget.Others,random);
            try
            {
                Debug.Log("u");
                PhotonNetwork.LeaveRoom();
                StartCoroutine(OnJoinRoom(random));
            }
            catch
            {
                firstRoom = true;
                PhotonNetwork.LeaveRoom();
            }
        }
    }
    [PunRPC]
    public void RanDomRoom2(int random)
    {
        try
        {
            PhotonNetwork.LeaveRoom();
            StartCoroutine(OnJoinRoom(random));
        }
        catch
        {
            firstRoom = true;
            PhotonNetwork.LeaveRoom();
        }
    }
    IEnumerator OnJoinRoom(int random)
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.JoinOrCreateRoom(roomtype+random.ToString(), new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        SceneManager.LoadScene("SampleScene");
    }
}
