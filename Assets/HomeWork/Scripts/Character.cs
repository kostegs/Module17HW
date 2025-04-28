using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour, IMovable
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private CharacterMoving _movingStrategy;

    private Mover _mover;
    private Rotator _rotator;
    private IBehaviour _moving;
    private CharacterController _characterController;

    public float MoveSpeed => _movingSpeed;

    public Transform Transform => transform;

    public float RotateSpeed => _rotationSpeed;

    private void Awake()
    {
        _mover = new Mover();
        _rotator = new Rotator();
        _characterController = GetComponent<CharacterController>();

        switch (_movingStrategy)
        {
            case CharacterMoving.CharacterMoveWASD:
                _moving = new CharacterMoveWASD(_mover, _rotator, this);
                break;
            default:
                Debug.LogError("Ќе выбрана стратеги€ передвижени€ персонажа");
                break;
        }
    }

    private void Update()
    {
        _moving.Update();
    }

    public void Move(Vector3 direction)
        => _mover.MoveTo(_characterController, direction, _movingSpeed);
    
    public void Rotate(Vector3 direction)
        => _rotator.RotateTo(transform, direction, _rotationSpeed);
    
}
