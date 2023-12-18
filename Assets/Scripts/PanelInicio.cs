using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInicio : MonoBehaviour
{
    public GameObject panelInicio;

    void Start()
    {
        MostrarPanelInicio();
    }

    void MostrarPanelInicio()
    {
        if (panelInicio != null)
        {
            panelInicio.SetActive(true);
        }
    }
    public void QuitarPanelInicio()
    {
        panelInicio.SetActive(false);
    }
}
