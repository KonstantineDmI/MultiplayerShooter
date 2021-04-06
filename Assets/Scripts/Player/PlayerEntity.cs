using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEntity : MonoBehaviour
{
    [HideInInspector]
    public PhotonView _photonView;
    public Material enemyMaterial;
    private MeshRenderer _meshRenderer;

    public int score = 0;

    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private GameObject settingsPanel;

    public UI userInterfase;

    public TextMeshPro nickName;
    public bool isDead;
    public Text hpUI;







    private void Start()
    {

        _photonView = GetComponent<PhotonView>();
        _meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        userInterfase = new UI();
        

        if (!_photonView.IsMine)
        {
            _meshRenderer.material = enemyMaterial;
            nickName.color = Color.red;
            hpUI.enabled = false;
        }
        else if(_photonView.IsMine)
        {
            _meshRenderer.enabled = false;
            hpUI.enabled = true;
        }

        nickName.enabled = false;
        nickName.SetText(_photonView.Owner.NickName);

        FindObjectOfType<MapController>().AddPlayer(this);



    }

    private void Update()
    {
        if (!_photonView.IsMine) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            userInterfase.ShowUI(menuPanel);
        }
    }

    


    

    
}


