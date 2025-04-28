using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy : MonoBehaviour, IMovable, IDestroyable, IHaveBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private ParticleSystem _destroyEffectPrefab;
    
    public float MoveSpeed => _moveSpeed;

    public Transform Transform => transform;

    public float RotateSpeed => _rotateSpeed;

    public ParticleSystem DestroyEffectPrefab => _destroyEffectPrefab;

    private Mover _mover;
    private Rotator _rotator;
    private CharacterController _characterController;
    private IBehaviour _currentBehaviour;

    private void Awake()
    {
        _mover = new Mover();
        _rotator = new Rotator();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_currentBehaviour == null)
            return;

        _currentBehaviour.Update();
    }

    public void Move(Vector3 direction)
        => _mover.MoveTo(_characterController, direction, _moveSpeed);
    
    public void Rotate(Vector3 direction)
        => _rotator.RotateTo(transform, direction, _rotateSpeed);

    public void SetBehaviour(IBehaviour behaviour)
        => _currentBehaviour = behaviour;

    public void DestroyObject()
    {
        ParticleSystem destroyEffect = Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
        destroyEffect.Play();
        Destroy(this.gameObject);
    }
}
