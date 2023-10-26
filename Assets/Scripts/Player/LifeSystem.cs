using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private Coroutine damageCoroutine;
    public SpriteRenderer spriteRenderer;

    public GameObject panelPerdiste;

    public GameObject button1; 
    public GameObject button2;
   

    //public Animator nabumFestejo;

    //private void Awake()
    //{
    //    nabumFestejo.StartPlayback();
    //}

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
        panelPerdiste.SetActive(true);
        //gameObject.SetActive(false);

        StartCoroutine(ShowButtonsAfterDelay(2.0f));
    }
    private IEnumerator ShowButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
      

       
        button1.SetActive(true);
        button2.SetActive(true);
    }
}
