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
    public void ScoreAdding(int viewId)
    {
        PlayerEntity player = MapController.instance.players.First(p => p._photonView.ViewID == viewId);
        player.score++;
        
    }

    private void ScoreInterface()
    {
        PlayerEntity[] top = MapController.instance.players.OrderBy(p => p.score).Take(4).ToArray();
        for (int i = 0; i < top.Length; i++)
        {
            transform.GetChild(i).GetComponent<Text>().text = i + ". " + top[i]._photonView.Controller.NickName + " - " + top[i].score;
        }
    }


}
