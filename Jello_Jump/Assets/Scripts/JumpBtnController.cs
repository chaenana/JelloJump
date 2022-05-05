using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpBtnController : MonoBehaviour
{
    [SerializeField] PlayerController PlayerController;

    private void OnMouseDown()
    {
        PlayerController.Jump();
    }


}