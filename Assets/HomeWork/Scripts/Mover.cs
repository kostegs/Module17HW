using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private UserInput _userInput;
    [SerializeField] private CharacterController _characterController;

    private void Update()
        => MoveCharacter();

    public void IncreaseMoveSpeed(float speed)
    {
        if(speed <= 0) 
            return;

        _movingSpeed += speed;

        Debug.Log($"Скорость была увеличена, новое значение: {_movingSpeed}");
    }

    private void MoveCharacter()
    {
        float horizontalSpeed = _userInput.HorizontalInput;
        float verticalSpeed = _userInput.VerticalInput;

        if (horizontalSpeed == 0 && verticalSpeed == 0)
            return;

        Vector3 input = new Vector3(horizontalSpeed, 0, verticalSpeed);
        Vector3 direction = input.normalized;

        MoveTo(direction);
        RotateTo(direction);
    }

    private void RotateTo(Vector3 direction)
            => transform.rotation = GetRotationTo(transform.position, transform.rotation, direction.normalized, _rotationSpeed);

    private void MoveTo(Vector3 direction)
        => _characterController.Move(direction * _movingSpeed * Time.deltaTime);

    private Quaternion GetRotationTo(Vector3 sourcePosition, Quaternion sourceRotation, Vector3 destination, float rotationSpeed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(destination);

        float step = rotationSpeed * Time.deltaTime;

        return Quaternion.RotateTowards(sourceRotation, lookRotation, step);
    }

}
