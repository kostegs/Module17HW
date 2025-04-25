using UnityEngine;

public class MoveToOppositeDirection : IBehaviour
{
    private Character _character;
    private IMovableAndRotateable _movable;
    private Vector3 _direction;

    public MoveToOppositeDirection(Character character, IMovableAndRotateable movable)
    {
        _character = character;
        _movable = movable;

        _direction = VectorsAssistive.GetDirectionTo(_movable.Transform.position, _character.Transform.position).normalized * -1;

        Debug.DrawLine(_movable.Transform.position, _direction * 20, Color.red);
    }

    public void Update()
    {
        _movable.Move(_direction);
        _movable.Rotate(_direction);
    }


}
