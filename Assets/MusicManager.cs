using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicClips; // 曲のAudioClip配列
    private AudioSource audioSource;
    private int currentClipIndex = 0; // 現在の曲のインデックス

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        // タイトル画面の曲を再生
        PlayMusic(0);
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたらゲーム中の曲に切り替え
        if(Input.GetMouseButton(0))
        {
            // 現在の曲の次の曲のインデックスを計算
            currentClipIndex = (currentClipIndex + 1) % musicClips.Length;
            // 曲を再生
            PlayMusic(currentClipIndex);
        }
    }

    void PlayMusic(int index)
    {
        // AudioSourceの再生中の曲を停止
        audioSource.Stop();
        // 新しい曲を設定して再生
        audioSource.clip = musicClips[index];
        audioSource.Play();
    }
}


