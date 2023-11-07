using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTierra : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] float speed;
    [SerializeField] float destroyTime;

    private void Start()
    {
        Invoke("DestroyBullet", destroyTime);
    }
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        LifeNabam lifeNabam = collision.gameObject.GetComponent<LifeNabam>();
        if (lifeNabam != null)
        {
            lifeNabam.TakeDamage(damage);
            Destroy(gameObject);
        }

        BalrogLife balrogLife = collision.gameObject.GetComponent<BalrogLife>();
        if (balrogLife != null)
        {
            balrogLife.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Paredes"))
        {
            DestroyBullet();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ArdeatLive ardeatLive = collision.gameObject.GetComponent<ArdeatLive>();
        if (ardeatLive != null)
        {
            ardeatLive.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
