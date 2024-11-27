using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public int currentMoney = 0; // プレイヤーの所持金
    public UnityEngine.UI.Text moneyText; // UIに表示するテキスト

    // お金を加算し、テキストを更新する
    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
    }

    // テキストを更新する
    private void UpdateMoneyText()
    {
        if (moneyText != null)
        {
            moneyText.text = "所持金: " + currentMoney.ToString();
        }
    }
}
