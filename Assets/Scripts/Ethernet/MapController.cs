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
        
        
    }
    

    


    

    










}
