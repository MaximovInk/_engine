using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public WeaponInstance prefab;
    public int MaxLevel;
    public int BaseDamage;
    public Sprite Icon;
    /*
        public int Rarity;
        public float Area;
        public float Speed;
        public float Amount;
        public float Duration;
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
