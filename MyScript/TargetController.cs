using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

/// <summary>
/// ターゲットのコントローラークラス
/// このクラスは、ターゲットの状態を管理し、死んだときにイベントを発行します。
/// </summary>
/// 
public class TargetController : MonoBehaviour
{
    public bool IsDead { get; private set; }

    Health m_Health;
    Actor m_Actor;

    void Awake()
    {
        ActorsManager actorsManager = FindObjectOfType<ActorsManager>();
        if (actorsManager != null)
            actorsManager.SetPlayer(gameObject);
    }

    void Start()
    {

        m_Health = GetComponent<Health>();
        DebugUtility.HandleErrorIfNullGetComponent<Health, PlayerCharacterController>(m_Health, this, gameObject);

        m_Actor = GetComponent<Actor>();
        DebugUtility.HandleErrorIfNullGetComponent<Actor, PlayerCharacterController>(m_Actor, this, gameObject);

        m_Health.OnDie += OnDie;

    }

    void OnDie()
    {
        Debug.Log("ターゲットが死んだ");
        IsDead = true;

        EventManager.Broadcast(Events.TargetDeathEvent);
    }
}
