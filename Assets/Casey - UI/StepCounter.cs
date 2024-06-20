using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//by Casey
//comments in Japanese translated using Google Translate
//This script's function is to maintain the player's step limit
//Casey による
//Google Translate を使って日本語に翻訳されたコメント
//このスクリプトの機能は、プレイヤーの歩数制限を維持することです

public class StepCounter : MonoBehaviour
{
    //--------------------------------------------------------------------------

    //UI text to display steps remaining
    // 残りのステップを表示する UI テキスト
    [SerializeField] private TMP_Text UItext;

    //the total number of steps that can be taken in this level
    //このレベルで実行できるステップの総数
    [SerializeField] private int maxSteps;

    //the number of steps remaining before the level is failed
    //レベルが失敗するまでの残りステップ数
    private int stepsRemaining;


    //--------------------------------------------------------------------------

    //set up variables in Start()
    //Start() で変数を設定する
    void Start()
    {
        stepsRemaining = maxSteps;
        UItext.text = maxSteps.ToString();
    }

    //TODO: this function should be called whenever the player takes a step (requires modifying player controller)
    //TODO: この関数は、プレイヤーがステップを踏むたびに呼び出されます (プレイヤー コントローラーの変更が必要)
    public void TakeStep()
    {
        //subtract a step from stepsRemaining, update the UI text, then check if the player has run out of steps
        //stepsRemainingからステップ数を減算し、UIテキストを更新して、プレイヤーのステップ数がなくなったかどうかを確認します
        stepsRemaining--;
        UItext.text = stepsRemaining.ToString();
        if(stepsRemaining <= 0)
        {
            //TODO: a game-over should occur if this conditional is reached (player has run out of steps)
            //TODO: この条件に達した場合、ゲームオーバーが発生する必要があります (プレイヤーのステップがなくなった場合)

        }
    }
}
