using UnityEngine;

public interface IRotateable 
{
    float RotateSpeed { get; }

    void Rotate(Vector3 direction);
}
