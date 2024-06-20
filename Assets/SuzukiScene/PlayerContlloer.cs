using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContlloer : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float gridSize = 1f;  // ��}�X�̃T�C�Y
    public Sprite rightSprite;   // �E�����̃X�v���C�g
    public Sprite leftSprite;    // �������̃X�v���C�g
    public Sprite upSprite;      // ������̃X�v���C�g
    public Sprite downSprite;    // �������̃X�v���C�g

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 targetPosition;
    private bool isMoving = false;
    private bool canMove = true; // ��x�̈ړ���������t���O

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetPosition = rb.position;
    }

    void Update()
    {
        // ���͂��擾
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // �ړ������̌���
        if (!isMoving && canMove && (moveX != 0 || moveY != 0))
        {
            // �΂߈ړ��𖳌��ɂ��邽�߂̏���
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY))
            {
                moveY = 0;
            }
            else
            {
                moveX = 0;
            }

            // �ڕW�ʒu�̌v�Z
            targetPosition = rb.position + new Vector2(moveX * gridSize, moveY * gridSize);
            isMoving = true;
            canMove = false; // �ړ��t���O��false�ɐݒ�

            // �X�v���C�g�̐؂�ւ�
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
        // �ړ�����
        if (isMoving)
        {
            Vector2 currentPosition = rb.position;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);

            // �ړ�����
            if ((Vector2)rb.position == targetPosition)
            {
                isMoving = false;
                canMove = true; // �ړ��t���O��true�ɖ߂�
            }
        }
    }
}
