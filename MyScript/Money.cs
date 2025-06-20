using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵が倒されたときにお金を加算するクラス
/// </summary>

public class Money : MonoBehaviour
{
    [SerializeField] int moneyReward = 10; // 倒したときに得られるお金の額
    [SerializeField] TextManager textManager; // テキスト更新用の参照

    // 敵が倒されたとき //--> これいつ呼ばれる？このクラスは誰についているの？？
    public void Die()
    {
        // テキストを更新してお金を加算
        if (textManager != null)
        {
            textManager.AddMoney(moneyReward);
        }
    }
}
