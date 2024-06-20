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
    private bool isMoving = false; // �ړ������ǂ����̃t���O

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ���͂��󂯕t���������ݒ肷��
        if (!isMoving)
        {
            // ���͂��擾
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

            // �ړ������̌���
            if (moveX != 0 || moveY != 0)
            {
                // �ڕW�ʒu�̌v�Z
                Vector2 movementDirection = new Vector2(moveX, moveY);
                Vector2 targetPosition = rb.position + movementDirection * gridSize;

                // �ړ��̊J�n
                MovePlayer(movementDirection);
            }
        }
    }

    // �ړ����\�b�h
    void MovePlayer(Vector2 direction)
    {
        isMoving = true;
        Vector2 start = rb.position;
        Vector2 end = start + direction * gridSize;

        StartCoroutine(MoveCoroutine(start, end));
    }

    // �ړ��R���[�`��
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
