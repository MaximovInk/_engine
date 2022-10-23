using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Duration = 3f;
    public float AutoTargetValue = 0f;
    public float AutoTargetFov = 0f;
    private Rigidbody2D _rb2d;
    private Enemy _target;

    private const float TargetFindingDelay = 0.1f;
    private float _targetFindTimer = 0f;

    public float Speed = 0f;

    public bool isFaced = false;

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

    public void Init()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        if (AutoTargetValue < 0.01f) return;

        ApplyTarget();
    }

    private void Update()
    {
        if (AutoTargetValue < 0.01f) return;

        _targetFindTimer += Time.deltaTime;

        if(_targetFindTimer > TargetFindingDelay)
        {
            _targetFindTimer = 0f;
            ApplyTarget();
        }

        if (isFaced)
        {
            transform.up = _rb2d.velocity.normalized;
        }
    }

    private void ApplyTarget()
    {
        if (!LevelManager.Instance.EnemiesIsExist()) return;

        _target = LevelManager.Instance.FindEnemyNearestTo(transform.position);

         var dir = _rb2d.velocity.normalized;
        var targetDir = (_target.transform.position - transform.position).normalized;


         var angleDiff = Mathf.Abs(Utilites.VecToAngle(dir) - Utilites.VecToAngle(targetDir));

        
         if (angleDiff < AutoTargetFov)
        {
            _rb2d.velocity = Vector2.Lerp(dir, targetDir, AutoTargetValue).normalized * Speed;
        }
        else
        {
            _rb2d.velocity = dir * Speed;
        }
         
    }
}

