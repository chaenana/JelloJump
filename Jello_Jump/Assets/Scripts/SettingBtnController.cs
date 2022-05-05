using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtnController : MonoBehaviour
{
    public GameController controller;
    bool _isShow;
    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }


    private void OnMouseDown()
    {
        controller._isSettingBtn_Active = true;
        if (!_isShow)
        {
            controller.OpenSettingBoard();
            _isShow = true;
        }
        else
        {
            controller.CloseSettingBoard();
            _isShow = false;
        }
    }
}