using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private CalmBehaviours _calmBehaviour;
    [SerializeField] private CharacterInteractionBehaviours _characterInteractionBehaviour;
    [SerializeField] private PatrolPoints _patrolPoints;
    [SerializeField] private Enemy _enemyPrefab;    

    private void Awake()
    {
        IEnumerable<Transform> patrolPoints = _patrolPoints.GetPatrolPoints();

        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

        if (enemy.TryGetComponent<BehaviourSwitcher>(out BehaviourSwitcher switcher))
            switcher.Initialize(enemy, patrolPoints, _calmBehaviour, _characterInteractionBehaviour);
        else
            Debug.LogError("Объект для спавна не имеет нужный компонент BehaviourSwitcher");
    }
}
