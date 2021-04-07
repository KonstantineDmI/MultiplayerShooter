using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private GameObject _playerEntity;
    private PhotonView _photonView;
    private GameObject _hitedPlayer;
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip _shotSound;
    [SerializeField]
    private GameObject _gun;
    private Animator animation;

    private void Start()
    {
        _photonView = _playerEntity.GetComponent<PhotonView>();
        _camera = GetComponent<Camera>();
        _audioSource = _camera.GetComponentInChildren<AudioSource>();
        animation = _gun.GetComponent<Animator>();
        
       
    }

    private void Update()
    {

        if (!_photonView.IsMine) return;

        
            RaycastHit hit;
            Ray ray;
            ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));


        if (Physics.Raycast(ray, out hit))
        {
            ShowNickName(hit);
            if (Input.GetMouseButtonDown(0))
            {
                //animation.SetBool("IsReloading", true);
                _audioSource.PlayOneShot(_shotSound, 0.4f);
                if (hit.transform.GetComponent<PlayerEntity>() != null)
                {
                    PlayerEntity hitedPlayer = hit.transform.GetComponent<PlayerEntity>();
                    PlayerEntity shootedPlayer = _playerEntity.GetComponent<PlayerEntity>();
                    StartCoroutine(HitMark());
                    //Health hitedPlayerHealth = hit.transform.GetComponent<Health>();
                    Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                    MapController.instance.HittedPlayer(hitedPlayer, shootedPlayer);
                    //hitedPlayerHealth.TakeDamage(hitedPlayer._photonView.ViewID);
                }


                   
            }
               
               
                

        }
        

    }



    private void ShowNickName(RaycastHit hit)
    {
        if(hit.transform.GetComponent<PlayerEntity>() != null)
        {
            _hitedPlayer = hit.transform.gameObject;
            _hitedPlayer.GetComponent<PlayerEntity>().nickName.enabled = true;
        }
        else if (hit.transform.GetComponent<PlayerEntity>() == null && _hitedPlayer != null)
        {
            _hitedPlayer.GetComponent<PlayerEntity>().nickName.enabled = false;
        }
        
    }

    private IEnumerator HitMark() 
    {
        _playerEntity.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _playerEntity.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);


    }



}


