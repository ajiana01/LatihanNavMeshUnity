using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelor : MonoBehaviour
{
    [SerializeField] public float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
