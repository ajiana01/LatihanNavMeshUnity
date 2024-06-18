using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private Transform mcChara;
    private NavMeshAgent agent;
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            if (playerObj.GetComponent<Rigidbody>() == null)
            {
                playerObj.AddComponent<Rigidbody>();
            }
            mcChara = playerObj.GetComponent<Transform>();
        }
        agent = gameObject.AddComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mcChara != null)
        {
            agent.SetDestination(mcChara.position);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pelor"))
        {
            Destroy(gameObject);
        }
    }
    
    // Deteksi trigger dengan objek lain
    private void OnTriggerEnter(Collider other)
    {
        // Jika mengenai objek dengan tag "pelor"
        if (other.gameObject.CompareTag("Pelor"))
        {
            Destroy(gameObject); // Menghancurkan objek musuh
        }
    }
}
