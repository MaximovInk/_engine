using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public string Name;
    public string Description;

    public WeaponInstance weaponDriverPrefab;

    public GameObject prefab;
    public int MaxLevel;
    public int BaseDamage;
    public Sprite Icon;

    public Sprite Sprite;

    public float Duration;

    public float AutoTarget = 0.1f;

    public Vector3 scale = Vector3.one;

    public float Force = 1f;

    public WeaponType WeaponType;

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
