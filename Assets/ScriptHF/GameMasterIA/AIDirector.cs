using UnityEngine;
using System.Collections.Generic;

public class AIDirector : MonoBehaviour
{
    [Header("Scene Objects")]
    public List<GameObject> enemies;
    public List<GameObject> weapons;
    public List<GameObject> ammo;

    [Header("Time Thresholds (seconds)")]
    public float slowTime = 300f;  
    public float fastTime = 120f;   

    void Start()
    {
        ApplyDirectorLogic();
    }

    void ApplyDirectorLogic()
    {
        float lastTime = RunStats.lastRunTime;

        if (lastTime < 0f)
        {
            SetAllActive(enemies, true);
            SetAllActive(weapons, true);
            SetAllActive(ammo, true);
            return;
        }

        if (lastTime > slowTime)
        {
            ToggleByPercentage(enemies, 0.5f);
            SetAllActive(weapons, true);
            SetAllActive(ammo, true);
        }
        else if (lastTime < fastTime)
        {
            SetAllActive(enemies, true);
            ToggleByPercentage(weapons, 0.5f);
            ToggleByPercentage(ammo, 0.5f);
        }
        else
        {
            SetAllActive(enemies, true);
            SetAllActive(weapons, true);
            SetAllActive(ammo, true);
        }
    }

    void SetAllActive(List<GameObject> list, bool state)
    {
        foreach (var obj in list)
            if (obj != null)
                obj.SetActive(state);
    }

    void ToggleByPercentage(List<GameObject> list, float percentage)
    {
        int activeCount = Mathf.RoundToInt(list.Count * percentage);

        SetAllActive(list, false);

        for (int i = 0; i < activeCount; i++)
        {
            list[i].SetActive(true);
        }
    }
}
