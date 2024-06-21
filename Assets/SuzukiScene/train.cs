using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train : MonoBehaviour
{
    private bool isMoving = false;  // �I�u�W�F�N�g���������ǂ������m�F����
    public float speed = 5.0f;  // �I�u�W�F�N�g���E�ɓ������x
    private Camera mainCamera;  // ���C���J�����̎Q��
    public AudioClip bgmClip;  // BGM�N���b�v�̎Q��
    private AudioSource audioSource;  // AudioSource�R���|�[�l���g�̎Q��

    // Start�͍ŏ��̃t���[���̑O�ɌĂяo�����
    void Start()
    {
        mainCamera = Camera.main;  // �J�����Q�Ƃ�������
        audioSource = GetComponent<AudioSource>();  // AudioSource�R���|�[�l���g��������
        if (audioSource == null)
        {
            // AudioSource�R���|�[�l���g�����݂��Ȃ��ꍇ�͒ǉ�
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update�͖��t���[���Ăяo�����
    void Update()
    {
        if (isMoving)
        {
            // �I�u�W�F�N�g���E�ɓ�����
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // �I�u�W�F�N�g����ʊO�ɏo�����ǂ������`�F�b�N
            Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
            if (screenPosition.x > 1.0f)  // �I�u�W�F�N�g����ʂ̉E���ɏo���ꍇ
            {
                // �V�[����ύX
                SceneManager.LoadScene("TestScene");  // �V�[������K�؂ɕύX
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O��"Player"�̏ꍇ
        if (other.gameObject.tag == "Player")
        {
            // BGM���Đ�
            if (bgmClip != null)
            {
                audioSource.clip = bgmClip;
                audioSource.Play();
            }
            // 10�b��ɃI�u�W�F�N�g�𓮂����n�߂�R���[�`�����J�n
            StartCoroutine(StartMovingAfterDelay(10f));
        }
    }

    // �w�肳�ꂽ�x����ɃI�u�W�F�N�g�𓮂����n�߂�R���[�`��
    private IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;  // �I�u�W�F�N�g�𓮂����n�߂�
    }
}
