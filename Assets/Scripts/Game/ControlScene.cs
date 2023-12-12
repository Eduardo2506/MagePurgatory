using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    public string nameScene;
    public GameObject panelOpciones;
    public void SiguienteEscena()
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(indiceEscenaActual + 1);
    }

    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliste del juego");
    }

    public void Creditos()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Opciones()
    {
        panelOpciones.SetActive(true);
    } 
    public void ReturnMenuOptions()
    {
        panelOpciones.SetActive(false);
    }
}
