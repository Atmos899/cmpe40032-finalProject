using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{

    public GameObject obstacle;
    void Start()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            
            Destroy(gameObject);
        }
    }
}
