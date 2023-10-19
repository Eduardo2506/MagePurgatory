using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public void SiguienteEscena()
    {
        // Obt�n el �ndice de la escena actual
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        // Carga la siguiente escena (sumando 1 al �ndice actual)
        SceneManager.LoadScene(indiceEscenaActual + 1);
    }
}
