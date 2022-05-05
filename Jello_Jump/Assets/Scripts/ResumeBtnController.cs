using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtnController : MonoBehaviour
{
    GameController controller;
    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }

    private void OnMouseDown()
    {
        controller.CloseSettingBoard();
    }
}