using UnityEngine;

public class Mover
{  
    public void MoveTo(CharacterController characterController, Vector3 direction, float speed)
        => characterController.Move(direction * speed * Time.deltaTime);
}
