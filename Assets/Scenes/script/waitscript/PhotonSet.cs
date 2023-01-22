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
    bool joinroom =false;
    int random;
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
        if (firstRoom)
        {
             firstInit = false;
             firstRoom = false;
             PhotonNetwork.JoinOrCreateRoom(roomtype, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
         }
         else
         {
             PhotonNetwork.JoinOrCreateRoom(roomtype + random.ToString(), new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
         }
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        firstInit = true;
        firstRoom = true;
        joinroom = false;
        OnConnectedToMaster();

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
        if (!joinroom)
        {
            firstInit = false;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void RandomRoom()
    {
        if(firstPlayer)
        {
            Debug.Log("i");
            random =Random.Range(0, 10000);
            photonView.RPC(nameof(RanDomRoom2), RpcTarget.Others,random);
            joinroom = true;
            Debug.Log("u");
            PhotonNetwork.LeaveRoom();
        }
    }
    [PunRPC]
    public void RanDomRoom2(int randomint)
    {
        random = randomint;
        joinroom = true;
        PhotonNetwork.LeaveRoom();
    }
}
