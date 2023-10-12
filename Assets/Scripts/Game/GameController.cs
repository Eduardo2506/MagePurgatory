using System.Collections.Generic;
using UnityEngine;

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


    private void Start()
    {
        bala.damage = 10;
    }
    public void PotenciadorVelocidad()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        player.moveSpeed = 10f;
        panel.panelToActivate.SetActive(false);
    }
    public void PotenciadorVida()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        lifePlayer.maxHealth = 150;
        lifePlayer.currentHealth = 150;
        panel.panelToActivate.SetActive(false);
    }
    public void PotenciadorDaño()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        bala.damage = 20;
        panel.panelToActivate.SetActive(false);
    }
    public void MenorTiempoDeRecarga()
    {
        Time.timeScale = 1f;
        cetro.canShoot = true;
        player.dashCooldown = 1f;
        player.teleportCooldown = 2f;
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
        panel.panelToActivate.SetActive(false);
    }
}
