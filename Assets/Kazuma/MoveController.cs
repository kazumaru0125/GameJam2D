using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  // DOTweenの名前空間を追加

public class MoveController : MonoBehaviour
    {
    // 移動する距離を指定 (1マス分)
    public float moveDistance = 1.0f;
    // 移動にかかる時間
    public float moveDuration = 0.5f;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
        {
    
        }

    // Update is called once per frame
    void Update()
        {
        // オブジェクトが移動中でない場合にのみ矢印キーの入力をチェックする
        if (!isMoving)
            {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                MoveObject(new Vector3(0, moveDistance, 0));
                }
            if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                MoveObject(new Vector3(0, -moveDistance, 0));
                }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                MoveObject(new Vector3(-moveDistance, 0, 0));
                }
            if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                MoveObject(new Vector3(moveDistance, 0, 0));
                }
            }
        }

    private void OnCollisionEnter2D(Collision2D collision)
        {

            Debug.Log("isHit");
            
        }

    void MoveObject(Vector3 moveVector)
        {
        // DOTweenを使ってオブジェクトをスムーズに移動させる
        isMoving = true;
        transform.DOMove(transform.position + moveVector, moveDuration).OnComplete(() => isMoving = false);
        }

    }
