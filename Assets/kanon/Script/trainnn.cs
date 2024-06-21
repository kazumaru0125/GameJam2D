using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trainnn : MonoBehaviour
{
 public GameObject objectPrefab; // �ړ�������I�u�W�F�N�g�̃v���n�u
    public GameObject spawnedObjectPrefab; // �\��������I�u�W�F�N�g�̃v���n�u
    public Vector3 startPoint = new Vector3(-10, 0, 0); // �����ʒu�i���[�j
    public Vector3 endPoint = new Vector3(0, 0, 0); // �ڕW�ʒu�i�����j
    public float speed = 5.0f; // �ړ����x
    public Vector3 spawnOffset = new Vector3(0, -1, 0); // �\���ʒu�̃I�t�Z�b�g�i�������j
    private GameObject targetObject; // �ړ�������C���X�^���X
    private bool hasReachedCenter = false; // �����ɓ��B�������ǂ����̃t���O

    void Start()
    {
        // �����ʒu�ɃI�u�W�F�N�g�𐶐�
        targetObject = Instantiate(objectPrefab, startPoint, Quaternion.identity);
    }

    void Update()
    {
        if (targetObject != null && !hasReachedCenter)
        {
            // �I�u�W�F�N�g�𒆉��Ɉړ�������
            targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, endPoint, speed * Time.deltaTime);

            // �����ɓ��B������t���O�𗧂ĂāABGM���Đ����āA2�b��ɕʂ̃I�u�W�F�N�g��\������
            if (Vector3.Distance(targetObject.transform.position, endPoint) < 0.01f)
            {
                hasReachedCenter = true;
                StartCoroutine(PlayBGMAndSpawnObject());
            }
        }
    }

    IEnumerator PlayBGMAndSpawnObject()
    {
        // BGM���Đ�

        // 2�b�҂�
        yield return new WaitForSeconds(10.0f);

        // BGM���~

        // �I�u�W�F�N�g�̒����ɕʂ̃I�u�W�F�N�g��\������
        Vector3 spawnPosition = targetObject.transform.position + spawnOffset;
        Instantiate(spawnedObjectPrefab, spawnPosition, Quaternion.identity);
    }}
