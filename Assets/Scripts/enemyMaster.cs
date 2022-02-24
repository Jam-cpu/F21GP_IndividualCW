using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMaster : MonoBehaviour
{
    // define variables
    Vector3 walkPoint;
    public GameObject Player;
    public float Distance = 20f;
    public bool isAngered;
    private bool rPoint;
    public NavMeshAgent _agent;
    public LayerMask player;

    // simply creates a path towards the player from the enemies current position
    void ChasePlayer()
    {
            _agent.SetDestination(Player.transform.position);  
    }

    // defined as a return type, this method is used for itteratively creating paths
    IEnumerator Patrolling()
    {
        rPoint = true;
        yield return new WaitForSeconds(1f);
        GetNewPath();
        rPoint = false;
    }
    // uses NavMeshAgent to create a path between current position and a random point within set paramaters
    void GetNewPath()
    {
        _agent.SetDestination(walkPoint);
        walkPoint = GenerateRandomPoint();
    }

    // using the size of the stage defined, picks a random x and z coordinate within that
    // this method then returns that point
    Vector3 GenerateRandomPoint()
    {
        float x = Random.Range(31, -31);
        float z = Random.Range(-2, -69);
        Vector3 newPoint = new Vector3(x, 0.44f, z);
        return newPoint;
    }

    // constantly update and check if the enemy is angered
    // if it is, chase. If not, patrol.
    void Update()
    {
        isAngered =  Physics.CheckSphere(transform.position,Distance,player);
        if(!isAngered && !rPoint)
        {
            StartCoroutine(Patrolling());
        }
        if(isAngered)
        {
            ChasePlayer();
        }
    }
}
