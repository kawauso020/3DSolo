using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UIのテキストを管理するクラス？？
/// お金の表示を管理するクラス？？
/// </summary>
public class TextManager : MonoBehaviour
{
    [SerializeField]
    int currentMoney = 0; // プレイヤーの所持金 //publicは使わない！クラスの外からアクセスが必要な場合はプロパティを使う
    
    [SerializeField]
    Text moneyText; // UIに表示するテキスト　//publicは使わない！クラスの外からアクセスが必要な場合はプロパティを使う

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
