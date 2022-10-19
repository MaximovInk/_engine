﻿using System;
using UnityEngine;
public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    public LevelData LevelData = new LevelData();

    public LevelCounterLogic LevelCounter = new LevelCounterLogic();

    [SerializeField]
    private ExperienceItem ExperienceItem;

    public event Action AbilitesChanged;

    public void SpawnExperienceAt(Vector3 position)
    {
        var exp = Instantiate(ExperienceItem);
        exp.transform.position = position;
    }

    private void Awake()
    {
        LevelData.abilities = new System.Collections.Generic.List<AbilitySlot>();

        LevelData.OnChanged += (data) =>
        {
            if(LevelCounter.UpdateLevel(data.Experience, data.Level))
            {
                LevelData.Level++;
                LevelData.Experience = 0;
            }
        };
    }

    public void AddAbility(AbilitySlot slot)
    {
        LevelData.abilities.Add(slot);
        slot.Init();
        AbilitesChanged?.Invoke();
    }
}
