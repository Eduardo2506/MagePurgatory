using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriNextScene : MonoBehaviour
{
    public GameObject nextGame;
    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Time.timeScale = 0f;
            nextGame.SetActive(true);
        }
        //if (other.CompareTag("Player"))
        //{
        //    SceneManager.LoadScene("Game");
        //}
    }
    public void PasarNivel()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
        //nextGame.SetActive(false);
    }
    public void NoPasarNivel()
    {
        nextGame.SetActive(false);
        Time.timeScale = 1f;
    }
}
//{


//private void OnTriggerEnter2D(Collider2D other)
//{
//    if (other.CompareTag("Player"))
//    {
//        playerInRange = true;
//        Time.timeScale = 0f;
//        interactionPanel.SetActive(true);
//    }
//}
//public void Volver()
//{
//    playerInRange = false;
//    Time.timeScale = 1f;
//    interactionPanel.SetActive(false);
//}
//}