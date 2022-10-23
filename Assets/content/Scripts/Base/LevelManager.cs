﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviourSingleton<LevelManager>
{
    public LevelData LevelData = new LevelData();

    public LevelCounterLogic LevelCounter = new LevelCounterLogic();

    [SerializeField]
    private ExperienceItem ExperienceItem;

    public event Action AbilitesChanged;

    [SerializeField]
    private List<Enemy> enemiesOnScene = new List<Enemy>();

    public Enemy[] enemiesPrefabs;

    public Enemy MakeEnemy(Vector3 position)
    {
        var instance =  Instantiate(enemiesPrefabs[0]);

        instance.transform.position = position;

        enemiesOnScene.Add(instance);

        instance.Entity.onDead += 
            () => { enemiesOnScene.Remove(instance); };

        return instance;
    }

    public bool EnemiesIsExist() => enemiesOnScene.Count > 0;

    public Enemy FindEnemyNearestTo(Vector3 position)
    {
        return enemiesOnScene
            .OrderByDescending(v2 => 
            Vector2.Distance(position, v2.transform.position)).First();
    }

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
                LevelUPPanel.Instance.Popup.Show();
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

