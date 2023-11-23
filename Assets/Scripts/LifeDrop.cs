
using UnityEngine;

public class LifeDrop : MonoBehaviour
{
    public int healthAmount = 5; // Cantidad de vida que proporciona

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
            Destroy(gameObject);
        }
        //Destroy(gameObject);
    }
}
