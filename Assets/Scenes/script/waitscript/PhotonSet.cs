using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class PhotonSet : MonoBehaviourPunCallbacks
{
    string roomtype;
    bool firstInit=false;
    bool firstPlayer;
    bool firstRoom = true;
    public void Wait(string type)
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
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
    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        // �ޏo���ɂ��Ă΂��
        if (firstRoom)
        {
            firstInit = false;
            firstRoom = false;
            PhotonNetwork.JoinOrCreateRoom(roomtype, new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
        }
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
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
            Debug.Log("�l���ݒ�G���["+ PhotonNetwork.CountOfPlayers.ToString());
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
