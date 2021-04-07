using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI
{
    

    public void ShowUI(GameObject UI)
    {
        UI.SetActive(!UI.activeSelf);
        if (UI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    }


    
    
}
