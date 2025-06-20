using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ショップのCanvasを表示/非表示に切り替えるクラス
/// </summary>
public class Shop : MonoBehaviour
{
    // 表示/非表示を切り替えるCanvas
    [SerializeField] private GameObject targetCanvas;

    // プレイヤーオブジェクト
    [SerializeField] private Transform player;

    // キャンバスを表示できる範囲
    [SerializeField] private float activationRange = 3.0f;

    // 切り替えに使用するキー
    [SerializeField] private KeyCode toggleKey = KeyCode.Space;

    void Start()
    {
        // 最初はCanvasを非表示にする
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(false);
            SetCursorState(false);
        }
    }
    /// <summary>
    /// プレイヤーとオブジェクトとの距離を計算し、キー入力に応じてCanvasを表示/非表示に切り替える
    /// </summary>
    void Update()
    {
        // プレイヤーとこのオブジェクトの距離を計算
        float distance = Vector3.Distance(player.position, transform.position);

        // 距離が範囲内でキーが押された場合にCanvasを表示
        if (distance <= activationRange && Input.GetKeyDown(toggleKey))
        {
            if (targetCanvas != null)
            {
                bool isActive = targetCanvas.activeSelf;
                targetCanvas.SetActive(!isActive);
                SetCursorState(!isActive);
            }
        }
    }
    /// <summary>
    /// マウスカーソルの表示/非表示を切り替える
    /// </summary>
    private void SetCursorState(bool isCursorVisible)
    {
        Cursor.visible = isCursorVisible; // カーソルを表示するかどうか
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked; // カーソルの動作を切り替える
    }

/// <summary>
/// シーンビューで範囲を可視化（デバッグ用）
/// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, activationRange);
    }
}
