using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Duration = 3f;

    private void Start()
    {
        Destroy(gameObject, Duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Entity.Damage(10);
            Destroy(gameObject);
        }
    }

}

