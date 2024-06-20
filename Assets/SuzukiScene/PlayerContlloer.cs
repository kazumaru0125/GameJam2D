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
    private Vector2 targetPosition;
    private bool isMoving = false;
    private bool canMove = true; // 一度の移動を許可するフラグ

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = rb.position;
    }

    void Update()
    {
        // 入力を取得
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 移動方向の決定
        if (!isMoving && canMove && (moveX != 0 || moveY != 0))
        {
            // 斜め移動を無効にするための処理
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                moveY = 0;
            }
            else
            {
                moveX = 0;
            }

            // 目標位置の計算
            targetPosition = rb.position + new Vector2(moveX * gridSize, moveY * gridSize);
            isMoving = true;
            canMove = false; // 移動フラグをfalseに設定

            // スプライトの切り替え
            if (moveX > 0)
            {
                spriteRenderer.sprite = rightSprite;
            }
            else if (moveX < 0)
            {
                spriteRenderer.sprite = leftSprite;
            }
            else if (moveY > 0)
            {
                spriteRenderer.sprite = upSprite;
            }
            else if (moveY < 0)
            {
                spriteRenderer.sprite = downSprite;
            }
        }
    }

    void FixedUpdate()
    {
        // 移動処理
        if (isMoving)
        {
            Vector2 currentPosition = rb.position;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            // 移動完了
            if ((Vector2)rb.position == targetPosition)
            {
                isMoving = false;
                canMove = true; // 移動フラグをtrueに戻す
            }
        }
    }
}
