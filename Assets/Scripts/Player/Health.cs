using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Health : MonoBehaviour, IPunObservable
{
    private Renderer _visual;
    public int health = 100;
    private PhotonView _photonView;
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _gameZone;

    public MapController MapController;
    public List<PlayerEntity> players = new List<PlayerEntity>();
    [SerializeField]
    private Score _score;
    private PlayerEntity _currentPlayer;
    private PhotonTransformView _pTransform;
    private GameObject[] _spawnPoints;
    [SerializeField]
    private GameObject _gameManager;
    

    private void Start()
    {
        //players = MapController.players;
        _photonView = GetComponent<PhotonView>();
        _currentPlayer = GetComponent<PlayerEntity>();
        _visual = GetComponentInChildren<Renderer>();
        _pTransform = GetComponent<PhotonTransformView>();
        _spawnPoints = _gameManager.GetComponent<GameManager>()._spawnPoint;

    }
   

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else if(stream.IsReading)
        {
            health = (int)stream.ReceiveNext();
        }
    }

    public void TakeDamage(int viewId)
    {
        _photonView.RPC("Damage", RpcTarget.All, viewId);
    }

    [PunRPC]
    public void Damage(int viewId)
    {
        health -= 10;
        HealthUI(viewId);
        if(health <= 0 && _currentPlayer.isDead == false)
        {
     
            _score.ScoreAdding(viewId);
            health = 0;
            _currentPlayer.isDead = true;
            StartCoroutine(RespawnPlayer(viewId));
        }
    }
    
    IEnumerator RespawnPlayer(int viewId)
    {
        health = 100;
        HealthUI(viewId);
        _currentPlayer.isDead = false;
        _pTransform.transform.position = _spawnPoints[Random.Range(0,6)].transform.position;
        yield return null;

    }

   

    public void HealthUI(int viewId)
    {
        PlayerEntity player = MapController.instance.players.First(p => p._photonView.ViewID == viewId);
        player.hpUI.text = "HP: " + health;
    }

    

}
