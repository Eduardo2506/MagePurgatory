using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PantallCompleta : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown dropdownResolutions;
    Resolution[] resolutiones;
    private void Start()
    {
        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }
        RevisarResoluciones();
    }
    private void Update()
    {
        
    }

    public void ActivarPantallCompleta(bool pantallaCompleta) 
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void RevisarResoluciones()
    {
        resolutiones = Screen.resolutions;
        dropdownResolutions.ClearOptions();
        List<string> opciones = new List <string>();
        int resolucionActual = 0;

        for (int i = 0; i < resolutiones.Length; i++)
        {
            string opcion = resolutiones[i].width + " x " + resolutiones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resolutiones[i].width == Screen.currentResolution.width && resolutiones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }

        }
        dropdownResolutions.AddOptions(opciones);
        dropdownResolutions.value = resolucionActual;
        dropdownResolutions.RefreshShownValue();

        dropdownResolutions.value = PlayerPrefs.GetInt("numeroResolucion", 0);
    }
    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("numeroResolucion", dropdownResolutions.value);

        Resolution resolucion = resolutiones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
