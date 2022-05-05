using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_restartBtnController : MonoBehaviour
{
    public GameController controller;
    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }


    private void OnMouseDown()
    {
        controller._isReBtn_Active = true;
        controller.Restart();
    }

}