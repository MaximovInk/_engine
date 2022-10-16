using UnityEngine;

public class WorldItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected virtual void OnPickup()
    {

    }
}

