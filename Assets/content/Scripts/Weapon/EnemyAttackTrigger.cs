using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public int DamageAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.Entity.Damage(DamageAmount);
            Destroy(gameObject);
        }
    }

}

