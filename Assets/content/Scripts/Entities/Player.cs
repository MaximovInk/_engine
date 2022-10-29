using UnityEngine;

[RequireComponent(typeof(Entity))]
public class Player : MonoBehaviourSingleton<Player>
{
    private Vector2 _input;

    public Entity Entity { get => _entity; }

    private Entity _entity;

    public PlayerDouble PlayerDouble
    {
        get
        {
            if (_playerDouble == null)
                _playerDouble = FindObjectOfType<PlayerDouble>();
            return _playerDouble;
        }
    }

    private PlayerDouble _playerDouble;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
        _playerDouble = FindObjectOfType<PlayerDouble>();
    }
    
    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _entity.MoveInput = _input;
    }
}
