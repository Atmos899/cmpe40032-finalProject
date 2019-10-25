using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class EnemyCollision : MonoBehaviour
{
    private int damage = 1;
    public float speed = 5;
    public GameObject effect;
    public GameObject enemyHitSound;
    private Animator anim;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().health -= damage;
            Instantiate(effect,transform.position, Quaternion.identity);
            Instantiate(enemyHitSound, transform.position, Quaternion.identity);
            CameraShaker.Instance.ShakeOnce(10f, 7f, 0.1f, 0.1f);
            Destroy(gameObject);
            anim.SetTrigger("devour");
        }
    }
}
