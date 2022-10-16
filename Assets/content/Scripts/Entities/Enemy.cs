
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyBehaviour
{
    public abstract void Init(Enemy controller);

    public abstract void Update(Enemy controller);
}

public class EnemyPlayerTargetBehaviour : EnemyBehaviour
{

    public override void Init(Enemy controller)
    {

    }

    public override void Update(Enemy controller)
    {
        if (Player.Instance == null) {
            controller.behaviour = null;
            return; 
        }
        
        var moveDir = (Player.Instance.transform.position - controller.transform.position).normalized;

        controller.Entity.MoveInput = moveDir;

    }
}

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

    public GameObject healthBar;
    public Slider HealthSlider;

    private void Awake()
    {
        _entity = GetComponent<Entity>();

        behaviour = new EnemyPlayerTargetBehaviour();

        behaviour.Init(this);

        _timerDmg = DelayReloadDamage;

        Entity.onDamage += (int value) => {
            healthBar.gameObject.SetActive(true);
            HealthSlider.value = Entity.GetHealthRelative();
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
                Player.Instance.Entity.Damage(DamageAmount);
                _timerDmg = 0f;
            }
        }
    }
}
