using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{ 

    private void Start()
    {
        foreach(Text text in GetComponentsInChildren<Text>())
        {
            text.text = "";
        }
    }
    public void ScoreAdding(List<PlayerEntity> players)
    {
        PlayerEntity[] top = players.OrderByDescending(p => p.score).Take(4).ToArray();
        for (int i = 0; i < top.Length; i++)
        {
            transform.GetChild(i).GetComponent<Text>().text = (i+1) + ". " + top[i].photonView.Controller.NickName + " - " + top[i].score;
        }  
    }

    private void ScoreInterface()
    {
        
    }


}
