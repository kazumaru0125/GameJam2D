using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//by Casey
//comments in Japanese translated using Google Translate
//this script's function is a personal debug tool for things I (Casey) need to quickly test
//Casey による
//Google Translate を使用して日本語に翻訳されたコメント
//このスクリプトの機能は、私 (Casey) がすぐにテストする必要があるもののための個人的なデバッグ ツールです
public class DebugController : MonoBehaviour
{
    [SerializeField] private StepCounter stepCounter;

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            stepCounter.TakeStep();
        }
    }
}
