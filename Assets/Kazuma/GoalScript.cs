using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
    {
    // Start is called before the first frame update
    void Start()
        {
        // �����ݒ�Ȃǂ��K�v�Ȃ炱���ɏ���
        }

    // Update is called once per frame
    void Update()
        {
        // Update���ɓ��ɏ����͂Ȃ��̂ŁA���̂܂܂ɂ��Ă���
        }

    // 2D�g���K�[�ɏՓ˂����ۂ̏���
    void OnTriggerEnter2D(Collider2D other)
        {
        // �Փ˂����I�u�W�F�N�g�̃^�O��"Player"�Ȃ�
        if (other.gameObject.tag == "Player")
            {
            // TestScene�ɐ؂�ւ�
            SceneManager.LoadScene("TestScene");
            }
        }
    }
