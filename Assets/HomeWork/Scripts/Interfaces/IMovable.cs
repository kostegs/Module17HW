using UnityEngine;

public interface IMovable
{
    float MoveSpeed { get; }
    float RotateSpeed { get; }
    Transform Transform { get; }

    void Move(Vector3 direction);
    void Rotate(Vector3 direction);
}
