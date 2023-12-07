using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NabumTutorialLife : MonoBehaviour
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
    private NabamTutorial nabamTuto;

    private CircleCollider2D colider;


    private void Start()
    {
        colider = GetComponent<CircleCollider2D>();
        animDead = GetComponent<Animator>();
        nabamTuto = FindObjectOfType<NabamTutorial>();
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
        nabamTuto.enabled = false;
        Destroy(gameObject, 1.22f);
        colider.enabled = false;
        Destroy(this);
        //gameObject.SetActive(false);
        //GetComponentInParent<EnemySpawner>().EnemyKilled();
    }
    private void DropObject()
    {
        if (dropVida != null)
        {
            Instantiate(dropVida, transform.position, Quaternion.identity);
        }
    }
}