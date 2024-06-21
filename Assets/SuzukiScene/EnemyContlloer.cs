using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyContlloer : MonoBehaviour
{
    public GameObject prefabObject; // プレハブとして使うオブジェクト
    public int numberOfObjects = 10; // 生成するオブジェクトの数
    public float scrollSpeed = 3.0f; // スクロール速度
    public float fixedYPosition = 0f; // 固定するY座標
    public float minDistanceBetweenObjects = 1.0f; // オブジェクト間の最小距離

    private List<GameObject> objects = new List<GameObject>(); // 生成したオブジェクトを格納するリスト
    private float screenWidth; // カメラの画面幅
    private Camera mainCamera;

    void Start()
    {
        // カメラの設定を取得する
        mainCamera = Camera.main;
        CalculateScreenWidth();

        // オブジェクトを生成してリストに追加する
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GenerateValidSpawnPosition();
            GameObject obj = Instantiate(prefabObject, spawnPosition, Quaternion.identity);
            objects.Add(obj);
        }
    }

    void Update()
    {
        // 全てのオブジェクトを左にスクロールする
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // オブジェクトが画面外に出たら、画面の反対側に移動させる
            if (objects[i].transform.position.x < mainCamera.transform.position.x - screenWidth / 2 - objects[i].GetComponent<Renderer>().bounds.size.x / 2)
            {
                RepositionObject(objects[i]);
            }
        }
    }

    void RepositionObject(GameObject objToReposition)
    {
        // 画面の右端に再配置する
        float newX = mainCamera.transform.position.x + screenWidth / 2 + objToReposition.GetComponent<Renderer>().bounds.size.x / 2;
        objToReposition.transform.position = new Vector3(newX, fixedYPosition, objToReposition.transform.position.z);
    }

    Vector3 GenerateValidSpawnPosition()
    {
        Vector3 spawnPosition;
        bool validPositionFound = false;

        do
        {
            float randomX = Random.Range(mainCamera.transform.position.x - screenWidth / 2, mainCamera.transform.position.x + screenWidth / 2);
            spawnPosition = new Vector3(randomX, fixedYPosition, 0);
            validPositionFound = true;

            foreach (GameObject obj in objects)
            {
                if (Vector3.Distance(spawnPosition, obj.transform.position) < minDistanceBetweenObjects)
                {
                    validPositionFound = false;
                    break;
                }
            }
        } while (!validPositionFound);

        return spawnPosition;
    }

    void CalculateScreenWidth()
    {
        // カメラの設定に基づいて画面の幅を計算する
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        screenWidth = screenAspect * cameraHeight;
    }
}
