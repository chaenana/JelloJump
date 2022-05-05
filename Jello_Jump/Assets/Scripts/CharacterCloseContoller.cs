using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCloseContoller : MonoBehaviour
{
    public GameController controller;
    private void OnMouseDown()
    {
        controller.CloseCharacterBoard();
    }
}