using UnityEngine;

[System.Serializable]
public class WeaponData
{
    [Header("Основная базовая информация")]
    public string Name;
    public string Description;
    public WeaponType WeaponType;
    public Sprite Icon; 

    [Header("Доп информация")]
    public float Duration;
    public float Couldown;

    [Header("Для типа Melee")]
    public GameObject prefab;
    [Header("Для типа Projectile|Faced")]
    public Sprite Sprite;

    public Vector3 scale = Vector3.one;

    public float AutoTargetValue = 0.1f;
    public float AutoTargetFov = 45.0f;

    [Header("Для типа Faced")]
    public float Force = 1f;

    [Header("Не используется*")]

    public int MaxLevel;
    public int BaseDamage;



    /*
        public int Rarity;
        public float Area;
        public float Speed;
        public float Amount;
        public float Cooldown;
        public float Pierce;
        public float ProjectileInterval;
        public float HitboxDelay;
        public float Knockback;
        public float Chance;
        public int PoolLimit;
        public bool BlocksByWalls;
        public float CritMultiplyer;
     */
}

[CreateAssetMenu(menuName ="Engine/WeaponDatabase", fileName = "weaponDatabase", order = 900)]
public class WeaponsDatabase : ScriptableObject
{
    public WeaponData[] weapons;
}
