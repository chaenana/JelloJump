using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Score._ScoreAmount += 1;
        gameObject.SetActive(false);
    }
}