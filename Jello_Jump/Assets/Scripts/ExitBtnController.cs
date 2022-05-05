using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExitBtnController : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("Quit");
        Application.Quit();
    }
}