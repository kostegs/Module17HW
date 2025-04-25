using UnityEngine;

public class CharacterMoveWASD : IBehaviour
{
    private UserInput _userInput;
    private IMovableAndRotateable _character;    

    public CharacterMoveWASD(Mover mover, Rotator rotator, IMovableAndRotateable character)
    {
        _userInput = new UserInput();
        _character = character;        
    }

    void IBehaviour.Update()
    {
        _userInput.Update();

        float horizontalSpeed = _userInput.HorizontalInput;
        float verticalSpeed = _userInput.VerticalInput;

        if (horizontalSpeed == 0 && verticalSpeed == 0)
            return;

        Debug.Log($"horizontal: {_userInput.HorizontalInput}, vertical: {_userInput.VerticalInput}");

        Vector3 input = new Vector3(horizontalSpeed, 0, verticalSpeed);
        Vector3 direction = input.normalized;

        _character.Move(direction);
        _character.Rotate(direction);        
    }
}
