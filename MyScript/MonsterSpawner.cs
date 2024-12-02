using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab; // モンスターのPrefab
    [SerializeField] private Transform[] spawnPoints; // モンスターが出現するポイント
    [SerializeField] private int initialSpawnCount = 5; // 初期のモンスター数
    [SerializeField] private float initialSpawnInterval = 5f; // 初期の出現間隔
    [SerializeField] private int spawnIncrement = 1; // モンスター数の増加量
    [SerializeField] private float intervalDecrement = 0.5f; // 出現間隔の減少量
    [SerializeField] private float minimumSpawnInterval = 1f; // 出現間隔の最小値
    [SerializeField] private int maxActiveMonsters = 20; // 同時に出現できるモンスターの最大数

    private int currentSpawnCount; // 現在のモンスター出現数
    private float currentSpawnInterval; // 現在の出現間隔
    private List<GameObject> activeMonsters = new List<GameObject>();

    private void Start()
    {
        currentSpawnCount = initialSpawnCount;
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnMonstersPeriodically());
    }

    private IEnumerator SpawnMonstersPeriodically()
    {
        while (true)
        {
            // 現在のアクティブなモンスター数を管理
            activeMonsters.RemoveAll(monster => monster == null);

            // 上限を超えないように制御
            int spawnableCount = Mathf.Min(currentSpawnCount, maxActiveMonsters - activeMonsters.Count);
            for (int i = 0; i < spawnableCount; i++)
            {
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject monster = Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
                activeMonsters.Add(monster);
            }

            // 次回の準備: モンスター数を増やし、出現間隔を短縮
            currentSpawnCount += spawnIncrement;
            currentSpawnInterval = Mathf.Max(minimumSpawnInterval, currentSpawnInterval - intervalDecrement);

            // 次の出現まで待機
            yield return new WaitForSeconds(currentSpawnInterval);
        }
    }
}
