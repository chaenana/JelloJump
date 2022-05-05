using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_InfiniteScrollHandler : MonoBehaviour
{

    [SerializeField][Range(0f, 20f)] float speed = 3f;
    [SerializeField] float posValue;
    public Vector2 startPos;
    float newPos;
    public GameController controller;
    public bool init;
    public GameObject[] Coins;
    
    void Start()
    {
        transform.position = Vector3.zero;
        newPos = 0;
        startPos = transform.position;
        controller = FindObjectOfType<GameController>();
        init = true;
    }

    void Update()
    {

        if (!controller._isGameOver && init && !controller._isResume)
        {
            newPos = Mathf.Repeat(Time.timeSinceLevelLoad * speed, posValue);
            transform.position = startPos + Vector2.left * newPos;

            if (transform.position.x >= -0.05f)
            {
                print("다시 시작");
                for (int i = 0; i < Coins.Length; i++)
                {
                    Coins[i].SetActive(true);
                }
            }
        }
    }
}
