using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContlloer : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度
    public float gridSize = 1f;  // 一マスのサイズ
    public Sprite rightSprite;   // 右向きのスプライト
    public Sprite leftSprite;    // 左向きのスプライト
    public Sprite upSprite;      // 上向きのスプライト
    public Sprite downSprite;    // 下向きのスプライト

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isMoving = false; // 移動中かどうかのフラグ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 入力を受け付ける条件を設定する
        if (!isMoving)
        {
            // 入力を取得
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moveX = 1f;
                spriteRenderer.sprite = rightSprite;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moveX = -1f;
                spriteRenderer.sprite = leftSprite;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveY = 1f;
                spriteRenderer.sprite = upSprite;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moveY = -1f;
                spriteRenderer.sprite = downSprite;
            }

            // 移動方向の決定
            if (moveX != 0 || moveY != 0)
            {
                // 目標位置の計算
                Vector2 movementDirection = new Vector2(moveX, moveY);
                Vector2 targetPosition = rb.position + movementDirection * gridSize;

                // 移動の開始
                MovePlayer(movementDirection);
            }
        }
    }

    // 移動メソッド
    void MovePlayer(Vector2 direction)
    {
        isMoving = true;
        Vector2 start = rb.position;
        Vector2 end = start + direction * gridSize;

        StartCoroutine(MoveCoroutine(start, end));
    }

    // 移動コルーチン
    IEnumerator MoveCoroutine(Vector2 start, Vector2 end)
    {
        float sqrRemainingDistance = (rb.position - end).sqrMagnitude;

        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, end, moveSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);
            sqrRemainingDistance = (rb.position - end).sqrMagnitude;
            yield return null;
        }

        isMoving = false;
    }
}
