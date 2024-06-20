using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//by Casey
//comments in Japanese translated using Google Translate
//this script's function is a personal debug tool for things I (Casey) need to quickly test
//Casey �ɂ��
//Google Translate ���g�p���ē��{��ɖ|�󂳂ꂽ�R�����g
//���̃X�N���v�g�̋@�\�́A�� (Casey) �������Ƀe�X�g����K�v��������̂̂��߂̌l�I�ȃf�o�b�O �c�[���ł�
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
