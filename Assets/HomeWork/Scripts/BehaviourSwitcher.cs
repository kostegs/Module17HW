using System.Collections.Generic;
using UnityEngine;

public class BehaviourSwitcher : MonoBehaviour
{
    [SerializeField] CalmBehaviours _calmBehaviour;
    [SerializeField] CharacterInteractionBehaviours _characterInteractionBehaviour;    
    [SerializeField] List<Transform> _patrolPoints;

    private Enemy _enemy;    

    public void Initialize()
    {

    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        SwitchCalmBehaviour();
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            SwitchCharacterInteractionBehaviour(character);
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            SwitchCalmBehaviour();
    }

    private void SwitchCalmBehaviour()
    {
        Debug.Log("Switch to calm behaviour");

        IBehaviour behaviour = new Stay();

        switch (_calmBehaviour)
        {
            case CalmBehaviours.Stay:
                behaviour = new Stay();
                break;
            case CalmBehaviours.Patrol:
                behaviour = new Patrol(_patrolPoints, _enemy);
                break;
            case CalmBehaviours.MoveToRandomDirection:
                behaviour = new MoveToRandomDirection(_enemy);
                break;
            default:
                Debug.LogError("Не удалось определить обработчик для поведения покоя");
                break;
        }

        _enemy.SetBehaviour(behaviour);
    }

    private void SwitchCharacterInteractionBehaviour(Character character)
    {
        Debug.Log("Switch to interact behaviour");

        IBehaviour behaviour = new Stay();

        switch (_characterInteractionBehaviour)
        {
            case CharacterInteractionBehaviours.MoveToCharacter:
                behaviour = new MoveToCharacter(character, _enemy);
                break;
            case CharacterInteractionBehaviours.MoveToOppositeDirection:
                behaviour = new MoveToOppositeDirection(character, _enemy);
                break;
            case CharacterInteractionBehaviours.PermanentDeath:
                behaviour = new PermanentDeath(_enemy);
                break;
            default:
                Debug.LogError("Не удалось определить обработчик для поведения атаки");
                break;
        }

        _enemy.SetBehaviour(behaviour);
    }
}
