using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Slider _sensSlider;
    [SerializeField]
    private Text _sensText;
    [SerializeField]
    private GameObject _camera;
    private Mouse mouse;

    private void Start()
    {
        mouse = _camera.GetComponent<Mouse>();
        _sensSlider.onValueChanged.AddListener(delegate { SensetivityChange(); });
    }

    public void SensetivityChange()
    {
        _sensText.text = _sensSlider.value.ToString();
        mouse.sensetivity = _sensSlider.value;
    }




}
