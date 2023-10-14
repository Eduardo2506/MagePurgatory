using System.Collections;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Coroutine damageCoroutine;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            Die();
        }
    }
    public IEnumerator DamageFlash()
    {
        Color originalColor = spriteRenderer.color;
        Color damageColor = Color.red;

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
        gameObject.SetActive(false); 
    }
}
