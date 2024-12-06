using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �V���b�v���Ǘ�����N���X
/// </summary>
public class Shop : MonoBehaviour
{
    // �\��/��\����؂�ւ���Canvas
    [SerializeField] private GameObject targetCanvas;

    // �v���C���[�I�u�W�F�N�g
    [SerializeField] private Transform player;

    // �L�����o�X��\���ł���͈�
    [SerializeField] private float activationRange = 3.0f;

    // �؂�ւ��Ɏg�p����L�[
    [SerializeField] private KeyCode toggleKey = KeyCode.Space;

    void Start()
    {
        // �ŏ���Canvas���\���ɂ���
        if (targetCanvas != null)
        {
            targetCanvas.SetActive(false);
            SetCursorState(false);
        }
    }
    /// <summary>
    /// �v���C���[�ƃI�u�W�F�N�g�Ƃ̋������H�H�H�r���܂ł���������Ă��Ȃ���
    /// </summary>
    void Update()
    {
        // �v���C���[�Ƃ��̃I�u�W�F�N�g�̋������v�Z
        float distance = Vector3.Distance(player.position, transform.position);

        // �������͈͓��ŃL�[�������ꂽ�ꍇ��Canvas��\��
        if (distance <= activationRange && Input.GetKeyDown(toggleKey)) //--> ����NewInputSystem�ɕύX���� 
        {
            if (targetCanvas != null)
            {
                bool isActive = targetCanvas.activeSelf;
                targetCanvas.SetActive(!isActive);
                SetCursorState(!isActive);
            }
        }w
    }
    /// <summary>
    /// �}�E�X�J�[�\���̕\��/��\����؂�ւ���
    /// </summary>
    private void SetCursorState(bool isCursorVisible)
    {
        Cursor.visible = isCursorVisible; // �J�[�\����\�����邩�ǂ���
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked; // �J�[�\���̓����؂�ւ���
    }

    // �V�[���r���[�Ŕ͈͂������i�f�o�b�O�p�j
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, activationRange);
    }
}
