using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // �Ȃ�AudioClip�z��
    private AudioSource audioSource;
    private int currentClipIndex = 0; // ���݂̋Ȃ̃C���f�b�N�X

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        // �^�C�g����ʂ̋Ȃ��Đ�
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        // �X�y�[�X�L�[�������ꂽ��Q�[�����̋Ȃɐ؂�ւ�
        if(Input.GetMouseButton(0))
        {
            // ���݂̋Ȃ̎��̋Ȃ̃C���f�b�N�X���v�Z
            currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
            // �Ȃ��Đ�
            PlayMusic(currentClipIndex);
        }
    }

    void PlayMusic(int index)
    {
        // AudioSource�̍Đ����̋Ȃ��~
        audioSource.Stop();
        // �V�����Ȃ�ݒ肵�čĐ�
        audioSource.clip = musicClips[index];
        audioSource.Play();
    }
}


