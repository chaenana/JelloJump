using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBtnCotroller : MonoBehaviour
{
    public GameController controller;
    private void OnMouseDown()
    {
        controller.OpenCharacterBoard();
    }

}