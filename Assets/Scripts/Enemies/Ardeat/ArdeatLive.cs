using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdeatLive : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject dropVida;
    public float dropProbability = 0.8f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine damageCoroutine;

    private Animator animDead;
    public bool setDead;
    private Ardeat ardeat;

    private void Start()
    {
        animDead = GetComponent<Animator>();
        ardeat = FindObjectOfType<Ardeat>();
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
        }

        damageCoroutine = StartCoroutine(DamageFlash());

        if (currentHealth <= 0)
        {
            setDead = true;
            Die();
        }
    }
    private IEnumerator DamageFlash()
    {
        Color damageColor = Color.black;

        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Die()
    {
        if (Random.value <= dropProbability)
        {
            DropObject();
        }
        animDead.SetBool("isDead", setDead);
        ardeat.enabled = false;
        //Invoke("Desactivar", 1.22f);
        Destroy(gameObject, 1.22f);
        //gameObject.SetActive(false);
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.EnemyKilled();
        }
        Destroy(this);
        ardeat.DisableShooting();
        //GetComponentInParent<EnemySpawner>().EnemyKilled();
    }
    private void Desactivar()
    {
        gameObject.SetActive(false);
    }
    private void DropObject()
    {
        if (dropVida != null)
        {
            Instantiate(dropVida, transform.position, Quaternion.identity);
        }
    }
}
