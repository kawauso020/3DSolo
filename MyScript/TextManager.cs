using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI�̃e�L�X�g���Ǘ�����N���X�H�H
/// �����̕\�����Ǘ�����N���X�H�H
/// </summary>
public class TextManager : MonoBehaviour
{
    [SerializeField]
    int currentMoney = 0; // �v���C���[�̏����� //public�͎g��Ȃ��I�N���X�̊O����A�N�Z�X���K�v�ȏꍇ�̓v���p�e�B���g��
    
    [SerializeField]
    Text moneyText; // UI�ɕ\������e�L�X�g�@//public�͎g��Ȃ��I�N���X�̊O����A�N�Z�X���K�v�ȏꍇ�̓v���p�e�B���g��

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
