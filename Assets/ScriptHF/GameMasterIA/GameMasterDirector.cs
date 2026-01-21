using UnityEngine;
using System.Collections.Generic;

public class GameMasterDirector : MonoBehaviour
{
    [Header("References")]
    public RaceTimer raceTimer;

    [Header("Spawn Lists")]
    public List<GameObject> weapons;
    public List<GameObject> ammo;
    public List<GameObject> enemies;

    [Header("Spawn Settings")]
    public Transform[] spawnPoints;

    [Header("Timers")]
    public float decisionInterval = 5f;

    private float decisionTimer = 0f;

    void Update()
    {
        decisionTimer += Time.deltaTime;

        if (decisionTimer >= decisionInterval)
        {
            decisionTimer = 0f;
            MakeDecision();
        }
    }

    void MakeDecision()
    {
        float time = GetElapsedTime();

        SpawnProfile profile = EvaluateTime(time);

        SpawnFromList(weapons, profile.weaponCount);
        SpawnFromList(ammo, profile.ammoCount);
        SpawnFromList(enemies, profile.enemyCount);
    }

    float GetElapsedTime()
    {
        return typeof(RaceTimer)
            .GetField("elapsed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(raceTimer) as float? ?? 0f;
    }

    SpawnProfile EvaluateTime(float time)
    {
        if (time < 30f)
            return new SpawnProfile(3, 3, 1);

        if (time < 90f)
            return new SpawnProfile(2, 2, 2);

        return new SpawnProfile(1, 1, 4);
    }

    void SpawnFromList(List<GameObject> list, int count)
    {
        if (list.Count == 0 || spawnPoints.Length == 0) return;

        for (int i = 0; i < count; i++)
        {
            GameObject prefab = list[Random.Range(0, list.Count)];
            Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(prefab, point.position, Quaternion.identity);
        }
    }
}

