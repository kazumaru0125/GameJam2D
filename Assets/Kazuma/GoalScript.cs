using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
    {
    // Start is called before the first frame update
    void Start()
        {
        // 初期設定などが必要ならここに書く
        }

    // Update is called once per frame
    void Update()
        {
        // Update内に特に処理はないので、このままにしておく
        }

    // 2Dトリガーに衝突した際の処理
    void OnTriggerEnter2D(Collider2D other)
        {
        // 衝突したオブジェクトのタグが"Player"なら
        if (other.gameObject.tag == "Player")
            {
            // TestSceneに切り替え
            SceneManager.LoadScene("TestScene");
            }
        }
    }
