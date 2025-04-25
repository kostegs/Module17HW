using UnityEngine;

public class UserInput 
{
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";    

    private float _horizontalInput;
    private float _verticalInput;    

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;    

    public void Update()
    {
        CheckHorizontalInput();
        CheckVerticalInput();    
    }    

    private void CheckVerticalInput()
        => _verticalInput = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

    private void CheckHorizontalInput()
        => _horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
}
