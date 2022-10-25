using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public int DamageAmount = 10;
    public float Duration = 0.1f;
    public float Knockback;

    private void Awake()
    {
        Destroy(gameObject, Duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if(enemy != null)
        {
            var delta = enemy.transform.position - transform.position;
            enemy.Entity.Damage(DamageAmount, delta * Knockback);
            Destroy(gameObject);
        }
    }

}

