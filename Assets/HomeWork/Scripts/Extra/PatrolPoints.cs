using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField] List<Transform> _patrolPoints;

    public IEnumerable<Transform> GetPatrolPoints()
    {
        return _patrolPoints;
    }
}
