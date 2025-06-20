using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �G���|���ꂽ�Ƃ��ɂ��������Z����N���X
/// </summary>

public class Money : MonoBehaviour
{
    [SerializeField] int moneyReward = 10; // �|�����Ƃ��ɓ����邨���̊z
    [SerializeField] TextManager textManager; // �e�L�X�g�X�V�p�̎Q��

    // �G���|���ꂽ�Ƃ� //--> ���ꂢ�Ă΂��H���̃N���X�͒N�ɂ��Ă���́H�H
    public void Die()
    {
        // �e�L�X�g���X�V���Ă��������Z
        if (textManager != null)
        {
            textManager.AddMoney(moneyReward);
        }
    }
}
