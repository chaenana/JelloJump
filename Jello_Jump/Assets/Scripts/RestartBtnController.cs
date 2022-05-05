using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestartBtnController : MonoBehaviour
{
    public GameController controller;
    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }


    private void OnMouseDown()
    {
        controller.Restart();
    }
}