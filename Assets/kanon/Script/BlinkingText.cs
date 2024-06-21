using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float blinkSpeed = 1.0f; // �_�ő��x

    void Start()
    {
        // �R���[�`�����J�n
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            // �e�L�X�g��_�ł����邽�߂̃��[�v
            yield return Blink();
        }
    }

    IEnumerator Blink()
    {
        // �A���t�@�l��ύX���ē_�Ō��ʂ�����
        for (float t = 0; t < 1.0f; t += Time.deltaTime * blinkSpeed)
        {
            Color color = textMeshPro.color;
            color.a = Mathf.Lerp(1.0f, 0.0f, t);
            textMeshPro.color = color;
            yield return null;
        }

        for (float t = 0; t < 1.0f; t += Time.deltaTime * blinkSpeed)
        {
            Color color = textMeshPro.color;
            color.a = Mathf.Lerp(0.0f, 1.0f, t);
            textMeshPro.color = color;
            yield return null;
        }
    }
}

