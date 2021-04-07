using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{ 
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    public GameObject [] _spawnPoint;
    //public GameObject [] _spawnPoint;

    //public GameObject[] getSpawnPoints { get { return _spawnPoint; } private set { } }

    private void Start()
    {
        

        PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(_spawnPoint[Random.Range(0, 6)].transform.position.x, _spawnPoint[Random.Range(0, 6)].transform.position.y, _spawnPoint[Random.Range(0, 6)].transform.position.z), Quaternion.identity); 
    }

    public override void OnLeftRoom()
    {
        // current player left the room

        SceneManager.LoadScene(1);
    }
    
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered the room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
    }

}
