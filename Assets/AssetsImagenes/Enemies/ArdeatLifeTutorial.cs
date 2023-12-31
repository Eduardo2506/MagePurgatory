using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdeatLifeTutorial : MonoBehaviour
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
    private ArdearTUtorial ardeatTuto;
    private void Start()
    {
        animDead = GetComponent<Animator>();
        ardeatTuto = FindObjectOfType<ArdearTUtorial>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        currentHealth = maxHealth;
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
        ardeatTuto.enabled = false;
        Destroy(gameObject, 1.22f);
        Destroy(this);
        ardeatTuto.DisableShooting();
    }
    private void DropObject()
    {
        if (dropVida != null)
        {
            Instantiate(dropVida, transform.position, Quaternion.identity);
        }
    }
}