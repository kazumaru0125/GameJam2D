using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//by Casey
//comments in Japanese translated using Google Translate
//This script's function is to maintain the player's step limit
//Casey �ɂ��
//Google Translate ���g���ē��{��ɖ|�󂳂ꂽ�R�����g
//���̃X�N���v�g�̋@�\�́A�v���C���[�̕����������ێ����邱�Ƃł�

public class StepCounter : MonoBehaviour
{
    //--------------------------------------------------------------------------

    //UI text to display steps remaining
    // �c��̃X�e�b�v��\������ UI �e�L�X�g
    [SerializeField] private TMP_Text UItext;

    //the total number of steps that can be taken in this level
    //���̃��x���Ŏ��s�ł���X�e�b�v�̑���
    [SerializeField] private int maxSteps;

    //the number of steps remaining before the level is failed
    //���x�������s����܂ł̎c��X�e�b�v��
    private int stepsRemaining;


    //--------------------------------------------------------------------------

    //set up variables in Start()
    //Start() �ŕϐ���ݒ肷��
    void Start()
    {
        stepsRemaining = maxSteps;
        UItext.text = maxSteps.ToString();
    }

    //TODO: this function should be called whenever the player takes a step (requires modifying player controller)
    //TODO: ���̊֐��́A�v���C���[���X�e�b�v�𓥂ނ��тɌĂяo����܂� (�v���C���[ �R���g���[���[�̕ύX���K�v)
    public void TakeStep()
    {
        //subtract a step from stepsRemaining, update the UI text, then check if the player has run out of steps
        //stepsRemaining����X�e�b�v�������Z���AUI�e�L�X�g���X�V���āA�v���C���[�̃X�e�b�v�����Ȃ��Ȃ������ǂ������m�F���܂�
        stepsRemaining--;
        UItext.text = stepsRemaining.ToString();
        if(stepsRemaining <= 0)
        {
            //TODO: a game-over should occur if this conditional is reached (player has run out of steps)
            //TODO: ���̏����ɒB�����ꍇ�A�Q�[���I�[�o�[����������K�v������܂� (�v���C���[�̃X�e�b�v���Ȃ��Ȃ����ꍇ)

        }
    }
}
