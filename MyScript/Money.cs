using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������Ǘ�����N���X
/// </summary>
public class Money : MonoBehaviour
{

    [SerializeField] //public�͎g��Ȃ��I�G�f�B�^�[��ɕ\�����邾���Ȃ�SerializeField���g��
    int moneyReward = 10; // �|�����Ƃ��ɓ����邨���̊z
    [SerializeField] //public�͎g��Ȃ��I�G�f�B�^�[��ɕ\�����邾���Ȃ�SerializeField���g��
    TextManager textManager; // �e�L�X�g�X�V�p�̎Q��

    //���̃N���X����Ăяo���Ȃ�v���p�e�B��p�ӂ���

    // �G���|���ꂽ�Ƃ�
    public void Die()
    {
        // �e�L�X�g���X�V���Ă��������Z
        if (textManager != null)
        {
            textManager.AddMoney(moneyReward);
        }
    }
}
