using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMaster : MonoBehaviour
{
    Vector3 walkPoint;
    public GameObject Player;
    public float Distance = 20f;
    public bool isAngered;
    private bool rPoint;
    public NavMeshAgent _agent;
    public LayerMask player;
    void ChasePlayer()
    {
            _agent.SetDestination(Player.transform.position);  
    }

    IEnumerator Patrolling()
    {
        rPoint = true;
        yield return new WaitForSeconds(1f);
        GetNewPath();
        rPoint = false;
    }

    void GetNewPath()
    {
        _agent.SetDestination(walkPoint);
        walkPoint = GenerateRandomPoint();
    }

    Vector3 GenerateRandomPoint()
    {
        float x = Random.Range(31, -31);
        float z = Random.Range(-2, -69);
        Vector3 newPoint = new Vector3(x, 0.44f, z);
        return newPoint;
    }

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
