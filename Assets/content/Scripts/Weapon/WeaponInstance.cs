using UnityEngine;

public enum WeaponType
{
    Melee,
    Projectile,
    Faced
}


public class WeaponInstance : MonoBehaviour
{
    public WeaponData weaponData;

    public float CouldownMultiplier = 1f;
    public float SizeMultiplier = 1f;

    private WeaponDriver weaponDriver;

    private float timer;

    private void Start()
    {
        switch (weaponData.WeaponType)
        {
            case WeaponType.Melee:
                weaponDriver = new MeleeWeaponDriver();
                break;
            case WeaponType.Projectile:
                weaponDriver = new ProjectileWeaponDriver();
                break;
            case WeaponType.Faced:
                weaponDriver = new FacedProjectileWeaponDriver();
                break;
            default:
                weaponDriver = new ProjectileWeaponDriver();
                break;
        }
       
        weaponDriver.Init(this);

        
    }

    private void Update()
    {
        timer += Time.deltaTime * CouldownMultiplier;

        if(timer > weaponData.Couldown)
        {
            timer = 0;

            weaponDriver.Attack();
        }

        weaponDriver.Update();
    }
}
