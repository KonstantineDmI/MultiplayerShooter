using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour, IPunObservable
{
    public int health;
    private int maxHealth = 100;
    private PhotonView _photonView;
    [SerializeField]
    private PhotonTransformView _pTransform;
    [SerializeField]
    private Text hpUI;
    

    private void Start()
    {
         health = maxHealth;
        _photonView = GetComponent<PhotonView>();
        _pTransform = GetComponent<PhotonTransformView>();
      
       

    }

    private void Update()
    {
        HealthUI();
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

    public void TakeDamage()
    {
        _photonView.RPC("RPCTakeDamage", RpcTarget.All);
    }

    [PunRPC]
    public void RPCTakeDamage()
    {
        
        health -= 10;

        if (health <= 0)
        {
            health = 0;
            gameObject.GetComponent<PlayerEntity>().isDead = true;
        }
       
    }


   

    public int GetHealt()
    {
        return health;
    }

    public void Heal()
    {
        _photonView.RPC("RPCHeal", RpcTarget.All);
    }

    [PunRPC]
    public void RPCHeal()
    {
        health = maxHealth;
        gameObject.GetComponent<PlayerEntity>().isDead = false;
    }

    public void Respawn(Vector3 spawnPoint)
    {
        _photonView.RPC("RPCRespawn", RpcTarget.All, spawnPoint);
    }

    [PunRPC]

    public void RPCRespawn(Vector3 spawnPoint)
    {
        _pTransform.transform.position = spawnPoint;

    }
   

    public void HealthUI()
    {
        if (_photonView.IsMine)
        {
            hpUI.text = "HP: " + health;
        }
        
    }

    

}
