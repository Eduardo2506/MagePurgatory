using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (collision.gameObject.CompareTag("Paredes"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Estatua"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
     
            LifeSystem lifePlayer = collision.gameObject.GetComponent<LifeSystem>();
            if (lifePlayer != null)
            {
                lifePlayer.TakeDamage(damage);

                PlayerMovement movPlayer = collision.gameObject.GetComponent<PlayerMovement>();
                if (movPlayer != null) 
                {
                    float damagePercentage = (float)damage / (float)lifePlayer.maxHealth;
                    movPlayer.healthBar.fillAmount = Mathf.Max(0, movPlayer.healthBar.fillAmount - damagePercentage);
                }
            }
            LifeSystemTutorial lifePlayerTutorial = collision.gameObject.GetComponent<LifeSystemTutorial>();
            if (lifePlayerTutorial != null)
            {
                lifePlayerTutorial.TakeDamage(damage);

                PlayerMovement movPlayer = collision.gameObject.GetComponent<PlayerMovement>();
                if (movPlayer != null)
                {
                    float damagePercentage = (float)damage / (float)lifePlayerTutorial.maxHealth;
                    movPlayer.healthBar.fillAmount = Mathf.Max(0, movPlayer.healthBar.fillAmount - damagePercentage);
                }
            }
     
            Destroy(gameObject);
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}



