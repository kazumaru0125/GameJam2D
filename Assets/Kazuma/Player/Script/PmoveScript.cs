using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PmoveScript : MonoBehaviour
    {
    public float moveDistance = 1.0f; // 1マス分の移動距離
    public float moveDuration = 0.2f; // 移動にかかる時間
    private Rigidbody2D rb;
    private bool isMoving = false; // 現在移動中かどうかを示すフラグ

    // Start is called before the first frame update
    void Start()
        {
        rb = GetComponent<Rigidbody2D>();
        }

    // Update is called once per frame
    void Update()
        {
        if (isMoving) return; // 移動中なら新しい入力を受け付けない

        Vector3 move = Vector3.zero;

        // 矢印キーの入力を確認して移動量を設定
        switch (Input.inputString)
            {
            case "w": // UpArrow key
                move = Vector3.up * moveDistance;
                break;
            case "s": // DownArrow key
                move = Vector3.down * moveDistance;
                break;
            case "a": // LeftArrow key
                move = Vector3.left * moveDistance;
                break;
            case "d": // RightArrow key
                move = Vector3.right * moveDistance;
                break;
            }

        // 移動が設定されていたら
        if (move != Vector3.zero)
            {
            Vector3 targetPosition = transform.position + move;

            // 当たり判定をチェック
            Collider2D hitCollider = Physics2D.OverlapPoint(targetPosition);
            if (hitCollider != null && hitCollider.gameObject.CompareTag("Wall"))
                {
                Debug.Log("Hit a wall: " + hitCollider.gameObject.name);
                }
            else
                {
                isMoving = true; // 移動フラグを立てる

                // DoTweenを使って移動する
                transform.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("Moved to: " + targetPosition);

                    // 最終位置での当たり判定をチェック
                    Collider2D finalHitCollider = Physics2D.OverlapPoint(targetPosition);
                    if (finalHitCollider != null)
                        {
                        Debug.Log("Hit: " + finalHitCollider.gameObject.name);
                        }
                    else
                        {
                        Debug.Log("No collision at target position");
                        }

                    isMoving = false; // 移動が完了したらフラグをリセット
                });
                }
            }
        }
    }
