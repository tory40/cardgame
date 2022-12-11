using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PhotonSet : MonoBehaviourPunCallbacks
{
    string roomtype;
    public void Wait(string type)
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        roomtype = type;
        PhotonNetwork.ConnectUsingSettings();
    }
        private void Update()
        {

        }
    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        // 退出時にも呼ばれる
        PhotonNetwork.JoinOrCreateRoom(roomtype, new RoomOptions(), TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
