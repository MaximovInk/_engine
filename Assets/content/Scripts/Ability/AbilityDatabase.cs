using UnityEngine;

public enum AbilityType
{
    PlayerSpeed,
    AddDuration,
    ProjectileSpeed,
    Size,
    Damage,
    AddProjectile
}

[System.Serializable]
public class AbilityData
{
    [Header("Основная базовая информация")]
    public string Name;
    public string Description;
    public Sprite Icon;

    public float WeightChance = 0.1f;

    public AbilityType Type;

    public float Value;
}

[CreateAssetMenu(menuName = "Engine/AbilityDatabase", fileName = "abilityDatabase", order = 900)]
public class AbilityDatabase : ScriptableObject
{
    public AbilityData[] abilites;
}
