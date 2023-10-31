using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject panelPausa;
    private bool juegoPausado = false;
    public CetroController cetroNormal;
    public CetroFuegoController cetroFuego;
    public CetroHieloController cetroHielo;
    public CetroRayoController cetroRayo;
    public CetroTierraController cetroTierra;

    private void Start()
    {
        panelPausa.SetActive(false); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        cetroNormal.canShoot = false;
        cetroFuego.canShoot = false;
        cetroHielo.canShoot = false;
        cetroRayo.canShoot = false;
        cetroTierra.canShoot = false;
        Time.timeScale = 0; 
        panelPausa.SetActive(true); 
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        cetroNormal.canShoot = true;
        cetroFuego.canShoot = true;
        cetroHielo.canShoot = true;
        cetroRayo.canShoot = true;
        cetroTierra.canShoot = true;
        Time.timeScale = 1; 
        panelPausa.SetActive(false); 
        juegoPausado = false;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SalirJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
