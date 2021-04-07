using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance = null;
    public List<PlayerEntity> players = new List<PlayerEntity>();
    [SerializeField]
    private Score _score;
    [SerializeField]
    private GameObject[] _spawnPoints;

    void Awake()
    {

        if (instance == null)
            instance = this;


        else if (instance != this)
            Destroy(gameObject);
    }


    private float _lastTickTime;

    public void AddPlayer(PlayerEntity player)
    {
        players.Add(player);
    }

    private void Update()
    {
        _score.ScoreAdding(players);

    }

    public void HittedPlayer(PlayerEntity hittedPlayer, PlayerEntity shootedPlayer)
    {
        
        Health hittedPlayerHealth = hittedPlayer.GetComponent<Health>();
        hittedPlayerHealth.TakeDamage();

        if (hittedPlayer.isDead)
        {
            shootedPlayer.ScoreAdding();
            RespawnPlayer(hittedPlayer);
        }
    }


    [PunRPC]
    private void RespawnPlayer(PlayerEntity hittedPlayer)
    {
        Vector3 spawnPoint = _spawnPoints[Random.Range(0, 6)].transform.position;
        hittedPlayer.GetComponent<Health>().Respawn(spawnPoint);
        hittedPlayer.GetComponent<Health>().Heal();

        
        
    }

    


















}
