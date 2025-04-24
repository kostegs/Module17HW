using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS_NAME = "Horizontal";
    private const string VERTICAL_AXIS_NAME = "Vertical";
    private const KeyCode USE_SPELL_KEY = KeyCode.F;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _spellKeyPressed;

    public float HorizontalInput => _horizontalInput;
    public float VerticalInput => _verticalInput;
    public bool SpellKeyPressed => _spellKeyPressed;    

    private void Update()
    {
        CheckHorizontalInput();
        CheckVerticalInput();
        CheckSpellKeyPressed();        
    }    

    private void CheckSpellKeyPressed()
        => _spellKeyPressed = Input.GetKeyDown(USE_SPELL_KEY);

    private void CheckVerticalInput()
        => _verticalInput = Input.GetAxisRaw(VERTICAL_AXIS_NAME);

    private void CheckHorizontalInput()
        => _horizontalInput = Input.GetAxisRaw(HORIZONTAL_AXIS_NAME);
}
