using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Enemy : MonoBehaviour
{
    public EnemyBehaviour behaviour;

    public Entity Entity { get => _entity; }

    private Entity _entity;

    public float distanceMin = 1;

    public int DamageAmount = 10;

    public float DelayReloadDamage = 1f;
    private float _timerDmg = 0f;

    private void Awake()
    {
        _entity = GetComponent<Entity>();

        behaviour = new EnemyPlayerTargetBehaviour();

        behaviour.Init(this);

        _timerDmg = DelayReloadDamage;

        Entity.onDead += () =>
        {
            LevelManager.Instance.LevelData.EnemyDeathCount++;

            var deathCount = LevelManager.Instance.LevelData.EnemyDeathCount;

            if (deathCount % 2 == 0)
            {
                LevelManager.Instance.SpawnExperienceAt(transform.position);
            }
        };
    }

    private void Update()
    {
        if (behaviour == null) return;

        behaviour.Update(this);

        if (Vector2.Distance(Player.Instance.transform.position, transform.position) < distanceMin)
        {
            _timerDmg += Time.deltaTime;

            if(_timerDmg > DelayReloadDamage)
            {
                Player.Instance.Entity.Damage(DamageAmount, Vector2.zero);
                _timerDmg = 0f;
            }
        }
    }

    private void OnDestroy()
    {
        
    }
}
