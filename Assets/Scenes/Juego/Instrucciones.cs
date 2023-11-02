using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject interactionPanel;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Time.timeScale = 0f;
            interactionPanel.SetActive(true);
        }
    }
    public void Volver() 
    {
        playerInRange = false;
        Time.timeScale = 1f;
        interactionPanel.SetActive(false);
    }
}