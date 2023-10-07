using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMousePosition : MonoBehaviour
{
    public float minX = 0f;
    public float maxX = 800f;  // Cambia estos valores según tus necesidades.
    public float minY = 0f;
    public float maxY = 600f;  // Cambia estos valores según tus necesidades.

    private void Update()
    {
        // Obtén la posición actual del mouse en la pantalla
        Vector3 mousePosition = Input.mousePosition;

        // Limita la posición del mouse a los límites especificados
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        // Actualiza la posición del cursor del mouse
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;  // Desbloquea el cursor para que se pueda actualizar

        // Aplica la nueva posición del cursor
        Cursor.position = new Vector3(clampedX, clampedY, mousePosition.z);
    }
}