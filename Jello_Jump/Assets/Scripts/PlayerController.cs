using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    [SerializeField] float jumpForce = 8;
    bool isLongJump = false;

    //바닥을 감지 하여 땅에 닿았을때, max jump count까지만 점프가 가능하도록 함
    [SerializeField] LayerMask groundlayer;
    private PolygonCollider2D _collider;
    private bool _isGrounded;
    private Vector3 footPos;
    [SerializeField] int maxJumpCount = 2;
    int currentJumpCount = 0;


    public GameController controller;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<PolygonCollider2D>();
    }

    public void Jump()
    {
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }
    }

    private void FixedUpdate()
    {
        //바닥에 플레이어가 닿았는지의 여부를 확인하고 땅에 닿고나서 max까지만 점프 할 수 있도록 연속 점프를 제어함
        Bounds bounds = _collider.bounds;
        footPos = new Vector2(bounds.center.x, bounds.min.y);
        _isGrounded = Physics2D.OverlapCircle(footPos, 0.1f, groundlayer);
        //땅에 닿았을때 점프 카운트를 리셋
        if (_isGrounded && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }
        //오랫동안 점프했을때와 짧게 점프했을때의 중력의 힘을 다르게 주어서 땅에 떨어질때를 조절함
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
        //땅 아래로 떨어졌을때 게임오버
        if (rigid2D.velocity.y < -20f)
        {
            if (!controller._isGameOver)
            {
                Debug.Log("GameOver");
                controller._isGameOver = true;
            }
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space)) //space bar를 오랫동안 누르고 있을때
        {
            isLongJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }
    }


    void OnMouseDown()
    {
        Jump();
    }

}
