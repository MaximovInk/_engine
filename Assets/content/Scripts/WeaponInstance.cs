using UnityEngine;

public enum WeaponType
{
    Default,
    Projectile,
    Faced
}

public class WeaponInstance : MonoBehaviour
{
    [HideInInspector]
    public WeaponData weaponData;

    public WeaponType WeaponType;

   
}
