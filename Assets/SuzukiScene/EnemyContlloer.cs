using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyContlloer : MonoBehaviour
{
    public GameObject prefabObject; // �v���n�u�Ƃ��Ďg���I�u�W�F�N�g
    public int numberOfObjects = 10; // ��������I�u�W�F�N�g�̐�
    public float scrollSpeed = 3.0f; // �X�N���[�����x
    public float fixedYPosition = 0f; // �Œ肷��Y���W
    public float minDistanceBetweenObjects = 1.0f; // �I�u�W�F�N�g�Ԃ̍ŏ�����

    private List<GameObject> objects = new List<GameObject>(); // ���������I�u�W�F�N�g���i�[���郊�X�g
    private float screenWidth; // �J�����̉�ʕ�
    private Camera mainCamera;

    void Start()
    {
        // �J�����̐ݒ���擾����
        mainCamera = Camera.main;
        CalculateScreenWidth();

        // �I�u�W�F�N�g�𐶐����ă��X�g�ɒǉ�����
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 spawnPosition = GenerateValidSpawnPosition();
            GameObject obj = Instantiate(prefabObject, spawnPosition, Quaternion.identity);
            objects.Add(obj);
        }
    }

    void Update()
    {
        // �S�ẴI�u�W�F�N�g�����ɃX�N���[������
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

            // �I�u�W�F�N�g����ʊO�ɏo����A��ʂ̔��Α��Ɉړ�������
            if (objects[i].transform.position.x < mainCamera.transform.position.x - screenWidth / 2 - objects[i].GetComponent<Renderer>().bounds.size.x / 2)
            {
                RepositionObject(objects[i]);
            }
        }
    }

    void RepositionObject(GameObject objToReposition)
    {
        // ��ʂ̉E�[�ɍĔz�u����
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
        // �J�����̐ݒ�Ɋ�Â��ĉ�ʂ̕����v�Z����
        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = mainCamera.orthographicSize * 2;
        screenWidth = screenAspect * cameraHeight;
    }
}
