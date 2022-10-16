using UnityEngine;

public enum WeaponType
{
    Default,
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

public class ProjectileDriver : WeaponDriver
{
    public override void Attack()
    {
        GameObject go = new GameObject();
        go.transform.position = instance.transform.position;
        go.transform.localScale = instance.weaponData.scale;
        go.AddComponent<SpriteRenderer>().sprite = instance.weaponData.Sprite;
        var rb2d = go.AddComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(5f * (instance.player.Entity.IsFacingRight ? 1 : -1),10f);
        rb2d.gravityScale = 4f;
        var box = go.AddComponent<BoxCollider2D>();
        box.isTrigger = true;
        go.AddComponent<Projectile>();
        Object.Destroy(go, 3f); 
    }
}

public class DirectionDriveWeapon : WeaponDriver
{
    public override void Attack()
    {
        GameObject go = Object.Instantiate(instance.weaponData.prefab);
        go.transform.position = instance.transform.position;
        go.transform.parent = instance.transform;
        go.transform.localScale = new Vector3(
            go.transform.localScale.x *
            (instance.player.Entity.IsFacingRight ? 1 : -1),
            go.transform.localScale.y,
            go.transform.localScale.z);
        Object.Destroy(go,0.1f);

        /*
          GameObject go = new GameObject();
         go.transform.position = instance.transform.position;
         var scale = instance.weaponData.scale;
         //scale.x *= (instance.player.Entity.IsFacingRight ? 1 : -1);
         go.transform.localScale = scale;
         go.transform.parent = instance.transform;
         go.AddComponent<SpriteRenderer>().sprite = instance.weaponData.Sprite;
         var box = go.AddComponent<BoxCollider2D>();
         box.isTrigger = true;
         go.AddComponent<EnemyAttackTrigger>().DamageAmount 
             = instance.weaponData.BaseDamage;
         Object.Destroy(go, 0.1f);
         */
    }
}

public class WeaponInstance : MonoBehaviour
{
    //[HideInInspector]
    public WeaponData weaponData;

    public WeaponType WeaponType;

    [HideInInspector]
    public Player player;

    private WeaponDriver weaponDriver;

    private float timer;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void Start()
    {
        switch (WeaponType)
        {
            case WeaponType.Default:
                weaponDriver = new DirectionDriveWeapon();
                break;
            case WeaponType.Projectile:
                weaponDriver = new ProjectileDriver();
                break;
            case WeaponType.Faced:
                break;
            default:
                weaponDriver = new ProjectileDriver();
                break;
        }
       

        weaponDriver.Init(this);

        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > weaponData.Duration)
        {
            timer = 0;

            weaponDriver.Attack();
        }

        weaponDriver.Update();
    }
}
