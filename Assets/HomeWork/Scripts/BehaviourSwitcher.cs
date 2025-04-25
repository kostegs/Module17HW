using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviourSwitcher : MonoBehaviour
{
    private CalmBehaviours _calmBehaviour;
    private CharacterInteractionBehaviours _characterInteractionBehaviour;
    private List<Transform> _patrolPoints;
    private Enemy _enemy;    

    public void Initialize(Enemy enemy, IEnumerable<Transform> patrolPoints, CalmBehaviours calmBehaviour, CharacterInteractionBehaviours characterInteractionBehaviour)
    {
        _enemy = enemy;
        _patrolPoints = patrolPoints.ToList<Transform>();
        _calmBehaviour = calmBehaviour;
        _characterInteractionBehaviour = characterInteractionBehaviour;

        SwitchToCalmBehaviour();
    }    

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            SwitchToCharacterInteractionBehaviour(character);
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();

        if (character != null)
            SwitchToCalmBehaviour();
    }

    private void SwitchToCalmBehaviour()
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

    private void SwitchToCharacterInteractionBehaviour(Character character)
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
