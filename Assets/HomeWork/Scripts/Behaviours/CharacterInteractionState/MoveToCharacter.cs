using UnityEngine;

public class MoveToCharacter : IBehaviour
{
    private Character _character;
    private IMovable _movable;

    public MoveToCharacter(Character character, IMovable movable)
    {
        _character = character;
        _movable = movable;
    }

    public void Update()
    {
        Vector3 direction = VectorsAssistive.GetDirectionTo(_movable.Transform.position, _character.Transform.position).normalized;

        _movable.Move(direction);
        _movable.Rotate(direction);
    }
}
