using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PmoveScript : MonoBehaviour
    {
    public float moveDistance = 1.0f; // 1�}�X���̈ړ�����
    public float moveDuration = 0.2f; // �ړ��ɂ����鎞��
    private Rigidbody2D rb;
    private bool isMoving = false; // ���݈ړ������ǂ����������t���O

    // Start is called before the first frame update
    void Start()
        {
        rb = GetComponent<Rigidbody2D>();
        }

    // Update is called once per frame
    void Update()
        {
        if (isMoving) return; // �ړ����Ȃ�V�������͂��󂯕t���Ȃ�

        Vector3 move = Vector3.zero;

        // ���L�[�̓��͂��m�F���Ĉړ��ʂ�ݒ�
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

        // �ړ����ݒ肳��Ă�����
        if (move != Vector3.zero)
            {
            Vector3 targetPosition = transform.position + move;

            // �����蔻����`�F�b�N
            Collider2D hitCollider = Physics2D.OverlapPoint(targetPosition);
            if (hitCollider != null && hitCollider.gameObject.CompareTag("Wall"))
                {
                Debug.Log("Hit a wall: " + hitCollider.gameObject.name);
                }
            else
                {
                isMoving = true; // �ړ��t���O�𗧂Ă�

                // DoTween���g���Ĉړ�����
                transform.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear).OnComplete(() =>
                {
                    Debug.Log("Moved to: " + targetPosition);

                    // �ŏI�ʒu�ł̓����蔻����`�F�b�N
                    Collider2D finalHitCollider = Physics2D.OverlapPoint(targetPosition);
                    if (finalHitCollider != null)
                        {
                        Debug.Log("Hit: " + finalHitCollider.gameObject.name);
                        }
                    else
                        {
                        Debug.Log("No collision at target position");
                        }

                    isMoving = false; // �ړ�������������t���O�����Z�b�g
                });
                }
            }
        }
    }
