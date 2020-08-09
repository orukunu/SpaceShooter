using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestroyerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    GameObject creatorObject;
    MyCreatorScript creatorScript;

    private void Start()
    {
        creatorObject = GameObject.FindGameObjectWithTag("CreatorObject");
        creatorScript = creatorObject.GetComponent<MyCreatorScript>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Boundary")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            creatorScript.ScoreIncreaser(10);
        }

        if (collider.tag == "Player") {
            Instantiate(playerExplosion, collider.transform.position, collider.transform.rotation);
            creatorScript.gameOver();
        }
    }
}
