using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Obstacle : MonoBehaviour
{

    public int damage = 1;
    public float speed = 5f;
    public GameObject effect;
    public GameObject explosionSound;
    private Animator anim;
    //public CameraShake cameraShake;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //(cameraShake.Shake(.15f, .4f));
            Instantiate(explosionSound, transform.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(10f, 7f, 0.1f, 0.1f);
            Instantiate(effect, transform.position, Quaternion.identity);
            collision.GetComponent<PlayerMovement>().health -= damage;
            Destroy(gameObject);
            anim.SetTrigger("devour");
        }else if(collision.CompareTag("EndPoint"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
