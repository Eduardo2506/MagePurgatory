using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdeatLive : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.EnemyKilled();
        }
        //GetComponentInParent<EnemySpawner>().EnemyKilled();
    }
}
