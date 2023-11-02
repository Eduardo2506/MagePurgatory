using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemySpawner panel;
    [SerializeField] private LifeSystem lifePlayer;

    [SerializeField] private Bullet bala;

    [SerializeField] private CetroController cetro;

    [SerializeField] private GameObject cetroNormal;

    [SerializeField] private GameObject cetroFuego;
    [SerializeField] private GameObject cetroHielo;
    [SerializeField] private GameObject cetroRayo;
    [SerializeField] private GameObject cetroTierra;

    private int velocidadPotenciadorCount = 0;
    private int vidaPotenciadorCount = 0;
    private int danoPotenciadorCount = 0;
    //public Image cetroPrincipal;
    //public Image Cetro2;
    //public Image Cetro3;
    //public Image Cetro4;
    //public Image Cetro5;


    private void Start()
    {
        //cetroPrincipal.enabled = true;
        //Cetro2.enabled = false;
        //Cetro3.enabled = false;
        //Cetro4.enabled = false;
        //Cetro5.enabled = false;

        bala.damage = 10;
    }
    public void PotenciadorVelocidad()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        //player.moveSpeed = 10f;
        player.moveSpeed += 1; 
        velocidadPotenciadorCount++;
        panel.panelToActivate.SetActive(false);
    }
    public void PotenciadorVida()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        lifePlayer.maxHealth += 5; 
        lifePlayer.currentHealth += 5; 
        vidaPotenciadorCount++;
        //lifePlayer.maxHealth = 150;
        //lifePlayer.currentHealth = 150;
        panel.panelToActivate.SetActive(false);
    }
    public void PotenciadorDaño()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        //bala.damage = 20;
        bala.damage += 1;
        danoPotenciadorCount++;
        panel.panelToActivate.SetActive(false);
    }
    public void MenorTiempoDeRecarga()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        player.dashCooldown = 2f;
        player.teleportCooldown = 4f;
        panel.panelToActivate.SetActive(false);
    }
    public void CetroFuego()
    {
        Time.timeScale = 1f;
        cetro.canShoot = false;

        cetroNormal.SetActive(false);
        cetroHielo.SetActive(false);
        cetroRayo.SetActive(false);
        cetroTierra.SetActive(false);

        cetroFuego.SetActive(true);

        //cetroPrincipal.enabled = false;
        //Cetro2.enabled = true;
        //Cetro3.enabled = false;
        //Cetro4.enabled = false;
        //Cetro5.enabled = false;

        panel.panelToActivate.SetActive(false);
    }
    public void CetroHielo()
    {
        Time.timeScale = 1f;
        cetro.canShoot = false;

        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroRayo.SetActive(false);
        cetroTierra.SetActive(false);

        cetroHielo.SetActive(true);

        //cetroPrincipal.enabled = false;
        //Cetro2.enabled = false;
        //Cetro3.enabled = true;
        //Cetro4.enabled = false;
        //Cetro5.enabled = false;

        panel.panelToActivate.SetActive(false);
    }
    public void CetroRayo()
    {
        Time.timeScale = 1f;
        cetro.canShoot = false;

        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroTierra.SetActive(false);
        cetroHielo.SetActive(false);

        cetroRayo.SetActive(true);

        //cetroPrincipal.enabled = false;
        //Cetro2.enabled = false;
        //Cetro3.enabled = false;
        //Cetro4.enabled = true;
        //Cetro5.enabled = false;

        panel.panelToActivate.SetActive(false);
    }
    public void CetroTierra()
    {
        Time.timeScale = 1f;
        cetro.canShoot = false;
        cetroNormal.SetActive(false);
        cetroFuego.SetActive(false);
        cetroHielo .SetActive(false);
        cetroRayo.SetActive(false);

        cetroTierra.SetActive(true);

        //cetroPrincipal.enabled = false;
        //Cetro2.enabled = false;
        //Cetro3.enabled = false;
        //Cetro4.enabled = false;
        //Cetro5.enabled = true;

        panel.panelToActivate.SetActive(false);
    }
}
