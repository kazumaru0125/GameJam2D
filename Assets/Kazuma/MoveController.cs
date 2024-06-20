using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;  // DOTween�̖��O��Ԃ�ǉ�

public class MoveController : MonoBehaviour
    {
    // �ړ����鋗�����w�� (1�}�X��)
    public float moveDistance = 1.0f;
    // �ړ��ɂ����鎞��
    public float moveDuration = 0.5f;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
        {
    
        }

    // Update is called once per frame
    void Update()
        {
        // �I�u�W�F�N�g���ړ����łȂ��ꍇ�ɂ̂ݖ��L�[�̓��͂��`�F�b�N����
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
        // DOTween���g���ăI�u�W�F�N�g���X���[�Y�Ɉړ�������
        isMoving = true;
        transform.DOMove(transform.position + moveVector, moveDuration).OnComplete(() => isMoving = false);
        }

    }
