using UnityEngine;

public enum WeaponType
{
    Melee,
    Projectile,
    Faced
}

public abstract class WeaponDriver
{
    public WeaponInstance instance;

    public virtual void Init(WeaponInstance instance)
    {
        this.instance = instance;
    }

    public virtual void Update() { }
    public abstract void Attack();
}

public class ProjectileWeaponDriver : WeaponDriver
{
    protected virtual Projectile SpawnProjectile()
    {
        GameObject go = new GameObject();
        go.transform.position = instance.transform.position;
        go.transform.localScale = instance.weaponData.scale * instance.SizeMultiplier;
        go.AddComponent<SpriteRenderer>().sprite = instance.weaponData.Sprite;
        var rb2d = go.AddComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(5f * (Player.Instance.Entity.IsFacingRight ? 1 : -1), 10f);
        rb2d.gravityScale = 4f;
        var box = go.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        var projectile = go.AddComponent<Projectile>();

        projectile.AutoTargetValue = instance.weaponData.AutoTargetValue;
        projectile.AutoTargetFov = instance.weaponData.AutoTargetFov;
        projectile.Speed = rb2d.velocity.magnitude;
        projectile.Knockback = instance.weaponData.Knockback;

        projectile.Init();

        return projectile;
    }

    public override void Attack()
    {
        SpawnProjectile();

    }
}

public class MeleeWeaponDriver : WeaponDriver
{
    public override void Attack()
    {
        GameObject go = Object.Instantiate(instance.weaponData.prefab);
        go.transform.position = instance.transform.position;
        go.transform.parent = instance.transform;
        go.transform.localScale = new Vector3(
            go.transform.localScale.x *
            (Player.Instance.Entity.IsFacingRight ? 1 : -1),
            go.transform.localScale.y,
            go.transform.localScale.z) * instance.SizeMultiplier;


        go.GetComponent<EnemyAttackTrigger>().Knockback 
            = instance.weaponData.Knockback;
    }
}

public class FacedProjectileWeaponDriver : ProjectileWeaponDriver
{

    public override void Attack()
    {
        var projectile = SpawnProjectile();

        var rb2d = projectile.GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0;

        //Стоим
        if (Player.Instance.GetComponent<Rigidbody2D>().velocity.magnitude < 1f)
        {
            rb2d.velocity
            = (Player.Instance.Entity.IsFacingRight ? 1 : -1)
            * Player.Instance.Entity.Speed 
            * 2f
            * instance.weaponData.Force
            * new Vector2(1, 0);
        }
        //Двигаемся
        else
        {
            rb2d.velocity
                = Player.Instance.GetComponent<Rigidbody2D>().velocity
                * instance.weaponData.Force
                * 2f;

        }

        projectile.Speed = rb2d.velocity.magnitude;

        projectile.AutoTargetValue = instance.weaponData.AutoTargetValue;
        projectile.AutoTargetFov = instance.weaponData.AutoTargetFov;
        projectile.transform.up = rb2d.velocity.normalized;
        projectile.isFaced = true;
        projectile.Knockback = instance.weaponData.Knockback;

        projectile.Init();
    }
}

public class WeaponInstance : MonoBehaviour
{
    //[HideInInspector]
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
