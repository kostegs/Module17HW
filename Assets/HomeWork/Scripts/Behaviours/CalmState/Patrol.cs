using System.Collections.Generic;
using UnityEngine;

public class Patrol : IBehaviour
{
    private Queue<Transform> _patrolPoints;
    private Transform _currentPoint;    
    private IMovableAndRotateable _movable;

    public Patrol(IEnumerable<Transform> patrolPoints, IMovableAndRotateable movable)
    {
        _movable = movable;

        foreach(Transform point  in patrolPoints)        
            _patrolPoints.Enqueue(point);

        SetNextPatrolPoint();        
    }        
    
    public void Update()
    {
        Vector3 direction = VectorsAssistive.GetDirectionTo(_movable.Transform.position, _currentPoint.position);        
        direction = direction * _movable.MoveSpeed * Time.deltaTime;
        _movable.Move(direction);
        _movable.Rotate(direction);

        if (VectorsAssistive.IsReachedDestination(_movable.Transform.position, _currentPoint.position))
            SetNextPatrolPoint();
    }

    private void SetNextPatrolPoint()
    {
        _currentPoint = _patrolPoints.Dequeue();
        _patrolPoints.Enqueue(_currentPoint);        
    }
}
