using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoad : MonoBehaviour
{
    public void ToLobby()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToGame()
    {
        SceneManager.LoadScene(2);
    }
}
