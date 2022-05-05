using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TutorialMode : MonoBehaviour
{

    [SerializeField] GameObject road, tutorial1, tutorial2, Hand, point;
    bool istutorialover;
    float duration = 1;
    void Start()
    {
    }

    [SerializeField] PlayerController PlayerController;

    private void OnMouseDown()
    {
        if (!istutorialover)
        {
            PlayerController.Jump();
            road.transform.DOMoveX(-11f, duration).OnComplete(() =>
            {
                tutorial1.SetActive(false);
                tutorial2.SetActive(true);
                Hand.SetActive(false);
                point.SetActive(false);
                istutorialover = true;
            });
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }

}
