using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] Sprite[] avatar;
    [SerializeField] SpriteRenderer Render;
    [SerializeField] int index;
    private void OnMouseDown()
    {
        Render.sprite = avatar[index];
    }
    
}