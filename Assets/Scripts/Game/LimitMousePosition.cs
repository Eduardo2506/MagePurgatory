using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMousePosition : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 800f;  // Cambia estos valores seg�n tus necesidades.
    public float minY = 0f;
    public float maxY = 600f;  // Cambia estos valores seg�n tus necesidades.

    private void Update()
    {
        // Obt�n la posici�n actual del mouse en la pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Limita la posici�n del mouse a los l�mites especificados
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        // Actualiza la posici�n del cursor del mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor para que se pueda actualizar

        // Aplica la nueva posici�n del cursor
        Cursor.position = new Vector3(clampedX, clampedY, mousePosition.z);
    }
}