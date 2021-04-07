using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float rotationX = 0f;
    
    [SerializeField]
    private Transform _playerTransoform;

    public float currenySensitivity;

    public float sensetivity
    {
        get { return currenySensitivity; } set { currenySensitivity = value; }
    }


    private PhotonView _photonView;

    private void Start()
    {
        currenySensitivity = 500f;
        _photonView = GetComponentInParent<PhotonView>();
        if (!_photonView.IsMine)
        {
            transform.GetComponent<Camera>().enabled = false;
        }
        Cursor.lockState = CursorLockMode.Locked;
      
    }

    

    void Awake()
    {
        
    }
     
    void Update()
    {
        if (_photonView.IsMine && Cursor.lockState == CursorLockMode.Locked) // is current user ->
        {
            mouseX = Input.GetAxis("Mouse X") * currenySensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * currenySensitivity * Time.deltaTime;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            _playerTransoform.Rotate(Vector3.up * mouseX);

        }
        
       
                                //not current user ->
    }


    
    




}
