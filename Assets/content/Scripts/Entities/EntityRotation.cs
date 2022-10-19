using UnityEngine;

public enum EntityRotState
{
    Left,
    Top,
    Right,
    Bottom
}


[RequireComponent(typeof(Entity))]
public class EntityRotation : MonoBehaviour
{

    public Sprite[] LeftAnimation;
    public Sprite[] RightAnimation;
    public Sprite[] TopAnimation;
    public Sprite[] BottomAnimation;

    [SerializeField]
    private int stayIndex;

    [SerializeField]
    private EntityRotState _state;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private Entity _entity;

    [SerializeField]
    private float animationRate = 0.1f;

    private void Awake()
    {
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        UpdateState();
        UpdateSprite();
    }

    private void SetSprite(Sprite sprite)
    {
        if (sprite == null) return;
        _spriteRenderer.sprite = sprite;
    }

    private int _animIndex;
    private float _frameTime = 0;

    private void UpdateSpriteAnim(Sprite[] sprites)
    {
        _frameTime += Time.deltaTime;
        if(_frameTime > animationRate)
        {
            _frameTime = 0f;
            _animIndex++;
        }

        if (_animIndex >= sprites.Length)
            _animIndex = 0;
        SetSprite(sprites[_animIndex]);
    }

    private void UpdateState()
    {
        var input = _entity.MoveInput;

        if(input.y != 0) 
            _state = input.y > 0 ? EntityRotState.Top : EntityRotState.Bottom;
        else
            _state = input.x > 0 ? EntityRotState.Right : EntityRotState.Left;

    }

    private void UpdateSprite()
    {
        if(_entity.IsMoving)
        {
            switch (_state)
            {
                case EntityRotState.Left:
                    UpdateSpriteAnim(LeftAnimation);
                    break;
                case EntityRotState.Top:
                    UpdateSpriteAnim(TopAnimation);
                    break;
                case EntityRotState.Right:
                    UpdateSpriteAnim(RightAnimation);
                    break;
                case EntityRotState.Bottom:
                    UpdateSpriteAnim(BottomAnimation);
                    break;
            }
        }
        else
        {
            switch (_state)
            {
                case EntityRotState.Left:
                    SetSprite(LeftAnimation[stayIndex]);
                    break;
                case EntityRotState.Top:
                    SetSprite(TopAnimation[stayIndex]);
                    break;
                case EntityRotState.Right:
                    SetSprite(RightAnimation[stayIndex]);
                    break;
                case EntityRotState.Bottom:
                    SetSprite(BottomAnimation[stayIndex]);
                    break;
            }

        }
        
    }
}

/*
 
STATIC 8 ROTATIONS

[RequireComponent(typeof(Entity))]
public class EntityRotation : MonoBehaviour
{
    public Sprite LeftTop;
    public Sprite Top;
    public Sprite RightTop;

    public Sprite Left;

    [Header("Default")]
    public Sprite Right;

    public Sprite LeftBottom;
    public Sprite Bottom;
    public Sprite RightBottom;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private Entity _entity;

    private void Awake()
    {
        if (_spriteRenderer == null)
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        UpdateSprite();
    }

    private void SetSprite(Sprite sprite)
    {
        if (sprite == null) return;
        _spriteRenderer.sprite = sprite;
    }

    private void UpdateSprite()
    {
        var input = _entity.MoveInput;

        if(input.magnitude < 0.1f)
        {
            //_spriteRenderer.sprite = Right;
        }
        else
        {
            if (input.y != 0)
            {
                if (input.x != 0)
                {
                    if(input.x > 0)
                    {
                        SetSprite(input.y > 0 ? RightTop : RightBottom);
                    }
                    else
                    {
                        SetSprite(input.y > 0 ? LeftTop : LeftBottom);
                    }
                }
                else
                {
                    SetSprite(input.y > 0 ? Top : Bottom);
                }
            }
            else
            {
                SetSprite(input.x > 0 ? Right : Left);
            }
        }
        

    }
}

 */