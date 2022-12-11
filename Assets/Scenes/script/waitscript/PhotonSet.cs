using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class PhotonSet : MonoBehaviourPunCallbacks
{
    public int input;
    GameManager gameManager;
    public void Wait()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
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
        switch(input)
        {
            case 1:
                PhotonNetwork.JoinOrCreateRoom("Free", new RoomOptions(), TypedLobby.Default);
                break;
            case 2:
                PhotonNetwork.JoinOrCreateRoom("Rank", new RoomOptions(), TypedLobby.Default);
                break;
            case 3:
                PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
                break;
            default:
                return;

        }
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
