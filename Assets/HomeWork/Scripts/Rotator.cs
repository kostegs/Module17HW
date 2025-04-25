using UnityEngine;

public class Rotator
{
    public void RotateTo(Transform transform, Vector3 direction, float rotationSpeed)
        => transform.rotation = VectorsAssistive.GetRotationTo(transform.position, transform.rotation, direction.normalized, rotationSpeed);
}
