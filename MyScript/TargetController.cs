using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

/// <summary>
/// ���ׂ��^�[�Q�b�g���Ǘ�����N���X
/// </summary>
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

    /// <summary>
    /// �^�[�Q�b�g��HP��0�ɂȂ����Ƃ��ɌĂяo�����
    /// </summary>
    void OnDie()
    {
        Debug.Log("�^�[�Q�b�g������");
        IsDead = true;

        EventManager.Broadcast(Events.TargetDeathEvent);
    }
}
