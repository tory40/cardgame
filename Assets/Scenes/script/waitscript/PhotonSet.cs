using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class PhotonSet : MonoBehaviourPunCallbacks
{
    public int input;
    GameManager gameManager;
    public void Wait()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
    {
    }
    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        // �ޏo���ɂ��Ă΂��
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

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
