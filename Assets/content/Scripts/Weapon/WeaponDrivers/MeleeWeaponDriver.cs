
using UnityEngine;

public class MeleeWeaponDriver : WeaponDriver
{
    public override void Attack()
    {
        base.Attack();

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