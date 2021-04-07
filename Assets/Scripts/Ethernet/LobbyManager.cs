using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text logText;
    public InputField usersNickName;
    private void Start()
    {

    }
    
    public void JoinLobby()
    {
        if (!string.IsNullOrEmpty(usersNickName.text))
        {
            PhotonNetwork.NickName = usersNickName.text;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "1";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Log("Вы зашли в лобби!");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 4 });
    }
    
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Загрузка....");

        PhotonNetwork.LoadLevel("PoligoneScene");
    }

    

    


    private void Log(string message)
    {
        logText.text += "\n";
        logText.text += message;
    }
}

