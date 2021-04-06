using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerEntity;

public class Movement : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private float _speed = 10f;
    private float _jumpForce = 10f;
    private float _rotateX;
    private float _rotateZ;
    private float _gravity = -9.81f;
    private float _groundDistance = 0.4f;

    [Header ("Ground variables")]
    [SerializeField]
    private Transform _groundChecker;

    [SerializeField]
    private LayerMask _groundLayer;

    private bool _isGrounded;


    [Header("GameObjects for player")]
    

    [SerializeField]
    private Text playerLabel;

    [SerializeField]
    private CharacterController _chController;


    private Rigidbody _rb;

    private Vector3 _velocity;
    private Vector3 _move;



    private PhotonView _photonView;





    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _rb = transform.GetComponent<Rigidbody>();

        
    }

    void Awake()
    {
        

    }

    private void FixedUpdate()
    {
        
        
                                   // not current user ->
  
    }

    private void Update()
    {
        if (_photonView.IsMine) //is current user ->
        {

            _isGrounded = Physics.CheckSphere(_groundChecker.position, _groundDistance, _groundLayer);
            
            

            if (_isGrounded && _velocity.y < 0) // in case if player in air  -  transform him to the ground with -2 speed.
            {
                _velocity.y = -0.5f;
            }

            _rotateX = Input.GetAxis("Horizontal");
            _rotateZ = Input.GetAxis("Vertical");

            _move = transform.right * _rotateX + transform.forward * _rotateZ; //movement->
            _chController.Move(_move * _speed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2 * _gravity);
            }

            _velocity.y += _gravity * Time.deltaTime;       //gravity ->
            _chController.Move(_velocity * Time.deltaTime);


            if (Input.GetKey(KeyCode.LeftShift))
            {
                _speed = 20f; 
                
            }
            else
            {
                _speed = 10f;
            }


        }
        // not current user ->

    }
    

    

    


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
