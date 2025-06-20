using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの所持金を管理し、UIに表示するクラス
/// </summary>
public class TextManager : MonoBehaviour
{
    [SerializeField] int currentMoney = 0; // プレイヤーの所持金

    [SerializeField] Text moneyText; // UIに表示するテキスト

    /// <summary>
    /// お金を加算し、テキストを更新する
    /// </summary>
    /// <param name="amount"></param>
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    /// <summary>
    /// テキストを更新する
    /// </summary>
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "所持金: " + currentMoney.ToString();
        }
    }
}
