using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAsteroidRotation : MonoBehaviour
{
    Rigidbody physics;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.angularVelocity = Random.insideUnitSphere * speed;
        
    }
}
