using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlayer : GridObject
{

    //player variables (from MoveController)
    // �ړ����鋗�����w�� (1�}�X��)
    public float moveDistance = 1.0f;
    // �ړ��ɂ����鎞��
    public float moveDuration = 0.5f;
    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && gmCallback.AttemptPush(xCoord, yCoord - 1, GridDirection.UP))
            {
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                yCoord--;
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                MoveObject(new Vector3(0, moveDistance, 0));
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && gmCallback.AttemptPush(xCoord, yCoord + 1, GridDirection.DOWN))
            {
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                yCoord++;
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                MoveObject(new Vector3(0, -moveDistance, 0));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && gmCallback.AttemptPush(xCoord - 1, yCoord, GridDirection.LEFT))
            {
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                xCoord--;
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                MoveObject(new Vector3(-moveDistance, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && gmCallback.AttemptPush(xCoord + 1, yCoord, GridDirection.RIGHT))
            {
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, null);
                xCoord++;
                gmCallback.SetObjectAtCoordinate(xCoord, yCoord, this);

                MoveObject(new Vector3(moveDistance, 0, 0));
            }
        }

        void MoveObject(Vector3 moveVector)
        {
            // DOTween���g���ăI�u�W�F�N�g���X���[�Y�Ɉړ�������
            isMoving = true;
            transform.DOMove(transform.position + moveVector, moveDuration).OnComplete(() => isMoving = false);
        }
    }
}


/*
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
*/