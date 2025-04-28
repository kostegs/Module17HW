using UnityEngine;

public class MoveToRandomDirection : IBehaviour
{
    const float TIME_TO_CHANGE_DIRECTION = 1;

    private IMovable _movable;
    private float _timeElapsed;
    private Vector3 _currentDirection;

    public MoveToRandomDirection(IMovable movable)
    {
        _movable = movable;
        _timeElapsed = TIME_TO_CHANGE_DIRECTION;
    }
        
    public void Update()
    {
        _timeElapsed -= Time.deltaTime;
        
        if (_timeElapsed < 0)
        {
            ChangeDirection();
            _timeElapsed = TIME_TO_CHANGE_DIRECTION;
        }

        _movable.Move(_currentDirection);        
    }

    private void ChangeDirection()
    {
        _movable.Transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
        _currentDirection = _movable.Transform.forward;
    }
}
