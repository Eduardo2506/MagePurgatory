using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Niveles : MonoBehaviour
{
    public GameObject objectimage;
    public PauseManager pauseManager;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            CambiarEscena("Nivel2");
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.A))
        {
            CambiarEscena("Game");
        }
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    Time.timeScale = 0f;
        //    objectimage.SetActive(true);
        //    pauseManager.enabled = false;
        //}
    }

    public void BotonSalir()
    {
        pauseManager.enabled = true;
        Time.timeScale = 1f;
        objectimage.SetActive(false);
    }
    private void CambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
}
