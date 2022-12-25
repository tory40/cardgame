using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class PhotonSet : MonoBehaviourPunCallbacks
{
    string roomtype;
    bool firstInit=true;
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
            Debug.Log(PhotonNetwork.CountOfPlayers);
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
            Debug.Log("���[���������ł�");
        }
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
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
            Debug.Log("�l���ݒ�G���["+ PhotonNetwork.CountOfPlayers.ToString());
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
