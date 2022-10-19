using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour
{
    [HideInInspector]
    public Vector2 MoveInput;

    public float Speed = 5f;

    private Rigidbody2D _rg2d;

    public bool IsFacingRight => isFacingRight;

    public bool IsMoving => _rg2d.velocity.magnitude > 0;

    private bool isFacingRight;

    [HideInInspector]
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            onHealthChanged?.Invoke();
        }
    }

    private int _health;

    public int MaxHealth = 100;

    public float GetHealthRelative() => Health / (float)MaxHealth;

    public event Action<int> onDamage;
    public event Action onDead;
    public event Action onHealthChanged;

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
    }

    private void Awake()
    {
        _rg2d = GetComponent<Rigidbody2D>();
        
        Health = MaxHealth;
        isFacingRight = true;
    }

    public void Damage(int value)
    {
        Health -= value;

        onDamage?.Invoke(value);

        if(Health < 0)
        {
            onDead?.Invoke();

            Destroy(gameObject);
        }    

    }

    private void FixedUpdate()
    {

        var newVelocity = MoveInput * Speed;

        _rg2d.velocity = newVelocity;

        if ((_rg2d.velocity.x > 0 && !isFacingRight) || (_rg2d.velocity.x < 0 && isFacingRight))
        {
            Flip();
        }
    }
}
