using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bedil : MonoBehaviour
{
    [SerializeField] public GameObject prefabPelor;

    [SerializeField] public Transform firePoint;

    [SerializeField] private float bulletSpeed = 20f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Tembak();
        } ;
    }

    void Tembak()
    {
        GameObject pelor = Instantiate(prefabPelor, firePoint.position, firePoint.rotation);
        Rigidbody rb = pelor.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;
    }
}
