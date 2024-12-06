using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����X�^�[���o��������N���X
/// </summary>
public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab; // �����X�^�[��Prefab
    [SerializeField] private Transform[] spawnPoints; // �����X�^�[���o������|�C���g
    [SerializeField] private int initialSpawnCount = 5; // �����̃����X�^�[��
    [SerializeField] private float initialSpawnInterval = 5f; // �����̏o���Ԋu
    [SerializeField] private int spawnIncrement = 1; // �����X�^�[���̑�����
    [SerializeField] private float intervalDecrement = 0.5f; // �o���Ԋu�̌�����
    [SerializeField] private float minimumSpawnInterval = 1f; // �o���Ԋu�̍ŏ��l
    [SerializeField] private int maxActiveMonsters = 20; // �����ɏo���ł��郂���X�^�[�̍ő吔

    private int currentSpawnCount; // ���݂̃����X�^�[�o����
    private float currentSpawnInterval; // ���݂̏o���Ԋu
    private List<GameObject> activeMonsters = new List<GameObject>();

    private void Start()
    {
        currentSpawnCount = initialSpawnCount;
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnMonstersPeriodically());
    }

    private IEnumerator SpawnMonstersPeriodically()
    {
        while (true)�@//�������[�v�ɂȂ肻���Ȃ̂Œ��ӁA������݂������������iGameManager����󋵂����Ƃ��j
        {
            // ���݂̃A�N�e�B�u�ȃ����X�^�[�����Ǘ�
            activeMonsters.RemoveAll(monster => monster == null);

            // ����𒴂��Ȃ��悤�ɐ���
            int spawnableCount = Mathf.Min(currentSpawnCount, maxActiveMonsters - activeMonsters.Count);
            for (int i = 0; i < spawnableCount; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
                activeMonsters.Add(monster);
            }

            // ����̏���: �����X�^�[���𑝂₵�A�o���Ԋu��Z�k
            currentSpawnCount += spawnIncrement;
            currentSpawnInterval = Mathf.Max(minimumSpawnInterval, currentSpawnInterval - intervalDecrement);

            // ���̏o���܂őҋ@
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }
}