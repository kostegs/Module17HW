using UnityEngine;

public static class VectorsAssistive
{
    private const float DISTANCE_REACHED_DESTINATION = 0.1f;

    public static Quaternion GetRotationTo(Vector3 sourcePosition, Quaternion sourceRotation, Vector3 destination, float rotationSpeed)
    {
        Quaternion lookRotation = Quaternion.LookRotation(destination);

        float step = rotationSpeed * Time.deltaTime;

        return Quaternion.RotateTowards(sourceRotation, lookRotation, step);
    }

    public static Vector3 GetDirectionTo(Vector3 sourcePosition, Vector3 destinationPosition)
        => destinationPosition - sourcePosition;   
    
    public static bool IsReachedDestination(Vector3 currentPosition, Vector3 destinationPosition)
        => GetDirectionTo(currentPosition, destinationPosition).magnitude < DISTANCE_REACHED_DESTINATION;
    
}
