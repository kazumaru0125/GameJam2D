using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float blinkSpeed = 1.0f; // 点滅速度

    void Start()
    {
        // コルーチンを開始
        StartCoroutine(BlinkText());
    }

    IEnumerator BlinkText()
    {
        while (true)
        {
            // テキストを点滅させるためのループ
            yield return Blink();
        }
    }

    IEnumerator Blink()
    {
        // アルファ値を変更して点滅効果を実現
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

