using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private GameObject _menuPanel;
    public void PanelActive()
    {
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
        _menuPanel.SetActive(!_menuPanel.activeSelf);
    }
}
