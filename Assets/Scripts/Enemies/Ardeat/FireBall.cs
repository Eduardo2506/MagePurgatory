using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int damage = 10; 
    public float fireballForce = 10f;
    public float destroyDelay = 5f;

    

    private void Start()
    {
        Invoke("DestroyBullet", destroyDelay);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
     
            collision.gameObject.GetComponent<LifeSystem>().TakeDamage(damage);

     
            Destroy(gameObject);
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

