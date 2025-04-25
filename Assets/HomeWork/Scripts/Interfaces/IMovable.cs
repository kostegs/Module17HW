using UnityEngine;

public interface IMovable
{
    float MoveSpeed { get; }
    Transform Transform { get; }

    void Move(Vector3 direction);
}
