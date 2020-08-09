using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerControllerScript : MonoBehaviour
{
    Rigidbody physics;
    float horizontal = 0;
    float vertical = 0;
    Vector3 playerVector;
    public float playerSpeed;
    public float curve;
    float lastFire = 0;
    public float fireDelayer;
    public GameObject LazerBeam;
    public Transform SpawnPoint;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > lastFire)
        {
            lastFire = Time.time + fireDelayer;
            Instantiate(LazerBeam, SpawnPoint.position, Quaternion.identity);
            audio.Play();
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        playerVector = new Vector3(horizontal,0,vertical);

        physics.velocity = playerVector * playerSpeed;

        physics.position = new Vector3
            (
            Mathf.Clamp(physics.position.x, -6, 6),
            0.0f,
            Mathf.Clamp(physics.position.z, -5, 12)
            );

        physics.rotation = Quaternion.Euler(physics.velocity.z,0,physics.velocity.x*-curve);
        
    }
}
