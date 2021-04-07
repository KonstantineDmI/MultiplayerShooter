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
    public PhotonView photonView;
    public PhotonTransformView photonTransformView;
    public Material enemyMaterial;
    private MeshRenderer _meshRenderer;

    public int score;

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
        score = 0;
        photonView = GetComponent<PhotonView>();
        photonTransformView = GetComponent<PhotonTransformView>();
        _meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        userInterfase = new UI();
        

        if (!photonView.IsMine)
        {
            _meshRenderer.material = enemyMaterial;
            nickName.color = Color.red;
            hpUI.enabled = false;
        }
        else if(photonView.IsMine)
        {
            //_meshRenderer.enabled = false;
            hpUI.enabled = true;
        }

        nickName.enabled = false;
        nickName.SetText(photonView.Owner.NickName);

        FindObjectOfType<MapController>().AddPlayer(this);



    }

    public void ScoreAdding()
    {
        photonView.RPC("RPCScoreAdding", RpcTarget.All);
    }

    [PunRPC]
    private void RPCScoreAdding()
    {
        score++;
    }





    

    private void Update()
    {
        if (!photonView.IsMine) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            userInterfase.ShowUI(menuPanel);
        }
    }

    
}


