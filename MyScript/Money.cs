using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int moneyReward = 10; // 倒したときに得られるお金の額
    public TextManager textManager; // テキスト更新用の参照

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
