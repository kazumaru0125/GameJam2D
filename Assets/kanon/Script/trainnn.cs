using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainnn : MonoBehaviour
{
 public GameObject objectPrefab; // 移動させるオブジェクトのプレハブ
    public GameObject spawnedObjectPrefab; // 表示させるオブジェクトのプレハブ
    public Vector3 startPoint = new Vector3(-10, 0, 0); // 初期位置（左端）
    public Vector3 endPoint = new Vector3(0, 0, 0); // 目標位置（中央）
    public float speed = 5.0f; // 移動速度
    public Vector3 spawnOffset = new Vector3(0, -1, 0); // 表示位置のオフセット（少し下）
    private GameObject targetObject; // 移動させるインスタンス
    private bool hasReachedCenter = false; // 中央に到達したかどうかのフラグ

    void Start()
    {
        // 初期位置にオブジェクトを生成
        targetObject = Instantiate(objectPrefab, startPoint, Quaternion.identity);
    }

    void Update()
    {
        if (targetObject != null && !hasReachedCenter)
        {
            // オブジェクトを中央に移動させる
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, endPoint, speed * Time.deltaTime);

            // 中央に到達したらフラグを立てて、BGMを再生して、2秒後に別のオブジェクトを表示する
            if (Vector3.Distance(targetObject.transform.position, endPoint) < 0.01f)
            {
                hasReachedCenter = true;
                StartCoroutine(PlayBGMAndSpawnObject());
            }
        }
    }

    IEnumerator PlayBGMAndSpawnObject()
    {
        // BGMを再生

        // 2秒待つ
        yield return new WaitForSeconds(10.0f);

        // BGMを停止

        // オブジェクトの中央に別のオブジェクトを表示する
        Vector3 spawnPosition = targetObject.transform.position + spawnOffset;
        Instantiate(spawnedObjectPrefab, spawnPosition, Quaternion.identity);
    }}
