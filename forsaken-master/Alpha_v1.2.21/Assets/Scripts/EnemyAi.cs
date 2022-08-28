using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    //private EnemyPathfindingMovement pathFindingMovement;
    private Vector3 startingPosition;
    private Vector3 roamPosition;

    //private void Awake()
    //{
    //    pathFindingMovement = GetComponent<EnemyPathfindingMovement>();
    //}

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        //pathFindingMovement.MoveTo(roamPosition);
        float reachedPositionDistance = 1f;
        if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance)
        {
            //ReachedRoamPosition;
            roamPosition = GetRoamingPosition();
        }
    }

    public static Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDirection() * Random.Range(5f, 7f);
    }
}
