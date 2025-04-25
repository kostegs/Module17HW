using System.Collections.Generic;
using UnityEngine;

public class BehaviourSwitcher : MonoBehaviour
{
    [SerializeField] CalmBehaviours _calmBehaviour;
    [SerializeField] CharacterInteractionBehaviours _characterInteractionBehaviour;    
    [SerializeField] List<Transform> _patrolPoints;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        SwitchCalmBehaviour();
    }        

    private void SwitchCalmBehaviour()
    {
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

    private void SwitchCharacterInteractionBehaviour()
    {
        IBehaviour behaviour;


    }


}
