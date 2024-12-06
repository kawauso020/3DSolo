using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// お金を管理するクラス
/// </summary>
public class Money : MonoBehaviour
{

    [SerializeField] //publicは使わない！エディター上に表示するだけならSerializeFieldを使う
    int moneyReward = 10; // 倒したときに得られるお金の額
    [SerializeField] //publicは使わない！エディター上に表示するだけならSerializeFieldを使う
    TextManager textManager; // テキスト更新用の参照

    //他のクラスから呼び出すならプロパティを用意する

    // 敵が倒されたとき
    public void Die()
    {
        // テキストを更新してお金を加算
        if (textManager != null)
        {
            textManager.AddMoney(moneyReward);
        }
    }
}
