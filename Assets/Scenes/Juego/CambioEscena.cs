using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void SiguienteEscena()
    {
        // Obtén el índice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Carga la siguiente escena (sumando 1 al índice actual)
        SceneManager.LoadScene(indiceEscenaActual + 1);
    }
}
