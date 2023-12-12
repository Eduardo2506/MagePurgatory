using UnityEngine;

public class Instrucciones : MonoBehaviour
{
    public GameObject interactionPanel;
    public GameObject panelPrimero;
    public GameObject panelSegundo;
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractionPanel();
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
            interactionPanel.SetActive(false);
        }
    }

    private void InteractionPanel()
    {
        if (!interactionPanel.activeSelf)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f; 
        }
        interactionPanel.SetActive(!interactionPanel.activeSelf);
    }
    public void SiguienteVerPrefabVida()
    {
        panelPrimero.SetActive(false);
        panelSegundo.SetActive(true);
    }
    public void RegresarSpawnerDeEnemigos()
    {
        panelSegundo.SetActive(false);
        panelPrimero.SetActive(true);
    }
    public void VolverSinLosDosPaneles()
    {
        Time.timeScale = 1f;
        panelSegundo.SetActive(false);
        panelPrimero.SetActive(false);
    }
    public void Volver()
    {
        playerInRange = false;
        Time.timeScale = 1f;
        interactionPanel.SetActive(false);
    }
}