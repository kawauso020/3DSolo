using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̏��������Ǘ����AUI�ɕ\������N���X
/// </summary>
public class TextManager : MonoBehaviour
{
    [SerializeField] int currentMoney = 0; // �v���C���[�̏�����

    [SerializeField] Text moneyText; // UI�ɕ\������e�L�X�g

    /// <summary>
    /// ���������Z���A�e�L�X�g���X�V����
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    /// <summary>
    /// �e�L�X�g���X�V����
    /// </summary>
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "������: " + currentMoney.ToString();
        }
    }
}
