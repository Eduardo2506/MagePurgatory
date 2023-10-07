using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScene : MonoBehaviour
{
    public void SiguienteEscena()
    {
        // Obtén el índice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Carga la siguiente escena (sumando 1 al índice actual)
        SceneManager.LoadScene(indiceEscenaActual + 1);
    }

    public void SalirDelJuego()
    {
        // Salir de la aplicación
        Application.Quit();
        Debug.Log("Saliste del juego");
    }
}
