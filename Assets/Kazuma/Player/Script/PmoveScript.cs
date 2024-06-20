using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PmoveScript : MonoBehaviour
    {
    public float moveDistance = 1.0f; // 1マス分の移動距離
    public float moveDuration = 0.2f; // 移動にかかる時間
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
        {
        rb = GetComponent<Rigidbody2D>();
        }

    // Update is called once per frame
    void Update()
        {
        Vector3 move = Vector3.zero;

        // 矢印キーの入力を確認して移動量を設定
        if (Input.GetKeyDown(KeyCode.UpArrow))
            {
            move = Vector3.up * moveDistance;
            }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
            move = Vector3.down * moveDistance;
            }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
            move = Vector3.left * moveDistance;
            }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
            move = Vector3.right * moveDistance;
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
                });
                }
            }
        }
    }
