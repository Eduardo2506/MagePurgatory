
using UnityEngine;

public class LifeDrop : MonoBehaviour
{
    public int healthAmount = 5;
    public float timeDestroy = 8f;

    private void Start()
    {
        Destroy(gameObject, timeDestroy);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeSystem playerLife = other.GetComponent<LifeSystem>();

            if (playerLife != null && playerLife.currentHealth < playerLife.maxHealth)
            {
                playerLife.Heal(healthAmount);
                Destroy(gameObject);
            }
            LifeSystemTutorial playerLifeTutorial = other.GetComponent<LifeSystemTutorial>();
            if (playerLifeTutorial != null && playerLifeTutorial.currentHealth < playerLifeTutorial.maxHealth)
            {
                playerLifeTutorial.Heal(healthAmount);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
