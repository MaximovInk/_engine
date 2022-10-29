
using UnityEngine;

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
        base.Attack();
        SpawnProjectile();

    }
}
