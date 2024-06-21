using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class train : MonoBehaviour
{
    private bool isMoving = false;  // オブジェクトが動くかどうかを確認する
    public float speed = 5.0f;  // オブジェクトが右に動く速度
    private Camera mainCamera;  // メインカメラの参照
    public AudioClip bgmClip;  // BGMクリップの参照
    private AudioSource audioSource;  // AudioSourceコンポーネントの参照

    // Startは最初のフレームの前に呼び出される
    void Start()
    {
        mainCamera = Camera.main;  // カメラ参照を初期化
        audioSource = GetComponent<AudioSource>();  // AudioSourceコンポーネントを初期化
        if (audioSource == null)
        {
            // AudioSourceコンポーネントが存在しない場合は追加
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Updateは毎フレーム呼び出される
    void Update()
    {
        if (isMoving)
        {
            // オブジェクトを右に動かす
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // オブジェクトが画面外に出たかどうかをチェック
            Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
            if (screenPosition.x > 1.0f)  // オブジェクトが画面の右側に出た場合
            {
                // シーンを変更
                SceneManager.LoadScene("TestScene");  // シーン名を適切に変更
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトのタグが"Player"の場合
        if (other.gameObject.tag == "Player")
        {
            // BGMを再生
            if (bgmClip != null)
            {
                audioSource.clip = bgmClip;
                audioSource.Play();
            }
            // 10秒後にオブジェクトを動かし始めるコルーチンを開始
            StartCoroutine(StartMovingAfterDelay(10f));
        }
    }

    // 指定された遅延後にオブジェクトを動かし始めるコルーチン
    private IEnumerator StartMovingAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;  // オブジェクトを動かし始める
    }
}
