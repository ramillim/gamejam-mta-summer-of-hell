using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    private float elapsedTime;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        goal = GameObject.FindWithTag("Player").transform;
        AdjustCourse();
    }

    private void Update()
    {
        if (elapsedTime > 1f)
        {
            AdjustCourse();
            elapsedTime = 0f;
            return;
        }

        elapsedTime += Time.deltaTime;
    }

    private void AdjustCourse()
    {
        Vector3 newDestination = goal.position;
        newDestination.y = transform.position.y;
        agent.destination = newDestination;
    }
}
