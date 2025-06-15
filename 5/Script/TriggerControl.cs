using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class ObstacleStopper : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) // Ev veya engel tagý
        {
            Debug.Log("Engel bulundu, dur!");
            agent.isStopped = true; // NavMeshAgent'ý durdur
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("Engelden çýktýn, devam et!");
            agent.isStopped = false; // NavMeshAgent'ý tekrar baþlat
        }
    }
}
