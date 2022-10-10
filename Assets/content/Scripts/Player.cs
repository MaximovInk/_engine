using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviourSingleton<Player>
{
    private Vector2 _input;

    public Entity Entity { get => _entity; }

    private Entity _entity;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _entity.MoveInput = _input;

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
            enemy.Entity.Damage(10);
    }
}
