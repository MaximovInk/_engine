

using UnityEngine;

public class FacedProjectileWeaponDriver : ProjectileWeaponDriver
{

    public override void Attack()
    {
        base.Attack();

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
