using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
            return;
        }
        NabumTutorialLife tutorialNabumLife = collision.gameObject.GetComponent<NabumTutorialLife>();
        if (tutorialNabumLife != null)
        {
            tutorialNabumLife.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        BalrogLife balrogLife = collision.gameObject.GetComponent<BalrogLife>();
        if (balrogLife != null)
        {
            balrogLife.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
        BalroLifeTutorial balrogLifeTutorial = collision.gameObject.GetComponent<BalroLifeTutorial>();
        if (balrogLifeTutorial != null)
        {
            balrogLifeTutorial.TakeDamage(damage);
            Destroy(gameObject);
            return;
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
            return;
        }
        ArdeatLifeTutorial ardeatLifeTutorial = collision.gameObject.GetComponent<ArdeatLifeTutorial>();
        if (ardeatLifeTutorial != null)
        {
            ardeatLifeTutorial.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
