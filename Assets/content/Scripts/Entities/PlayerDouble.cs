using UnityEngine;

[RequireComponent(typeof(Entity))]
public class PlayerDouble : MonoBehaviour
{
    private Vector2 _input;

    public Entity Entity { get => _entity; }

    private Entity _entity;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    [SerializeField]
    private float _positionsUpdateRate = 0.1f;
    private float _positionsTimer = 0f;

    [SerializeField]
    private float _distanceTeleport = 10f;
    [SerializeField]
    private float _distanceStop = 1f;

    private void Update()
    {
        _entity.MoveInput = _input;


        _positionsTimer += Time.deltaTime;
        if(_positionsTimer> _positionsUpdateRate)
        {
            var delta = Player.Instance.transform.position - transform.position;

            _input = delta.normalized;
        
            if(delta.magnitude > _distanceTeleport)
            {
                transform.position = Player.Instance.transform.position;
            }

            if (delta.magnitude < _distanceStop)
            {
                _input = Vector2.zero;
            }
        }
    }
}
