using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PhotonSet : MonoBehaviourPunCallbacks
{
    string roomtype;
    bool firstInit=false;
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
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        if(PhotonNetwork.CountOfPlayers==1)
        {
            firstPlayer = true;
            Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
        }
        else if (PhotonNetwork.CountOfPlayers == 2)
        {
            firstPlayer = false;
            Debug.Log(PhotonNetwork.CountOfPlayers.ToString());
        }
        else
        {
            Debug.Log("人数設定エラー"+ PhotonNetwork.CountOfPlayers.ToString());
        }
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
                PhotonNetwork.JoinOrCreateRoom(roomtype + random.ToString(), new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
                SceneManager.LoadScene("SampleScene");
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
            PhotonNetwork.JoinOrCreateRoom(roomtype + random.ToString(), new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
            SceneManager.LoadScene("SampleScene");
        }
        catch
        {
            firstRoom = true;
            PhotonNetwork.LeaveRoom();
        }
    }
}
