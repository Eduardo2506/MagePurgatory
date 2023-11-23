using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject interactionPanel;
    private bool playerInRange = false;

    private void Update()
    {
        // Verificar la entrada de teclado para activar o desactivar el panel
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleInteractionPanel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Si el jugador sale del área, asegúrate de que el panel esté desactivado
            interactionPanel.SetActive(false);
        }
    }

    private void ToggleInteractionPanel()
    {
        // Cambiar el estado del tiempo solo si el panel cambia de estado
        if (!interactionPanel.activeSelf)
        {
            Time.timeScale = 0f; // Pausar el tiempo
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el tiempo
        }

        // Alternar la visibilidad del panel
        interactionPanel.SetActive(!interactionPanel.activeSelf);
    }

    public void Volver()
    {
        playerInRange = false;
        Time.timeScale = 1f;
        interactionPanel.SetActive(false);
    }
}