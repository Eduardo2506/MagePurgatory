using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private CetroController cetro;
    [SerializeField] private EnemySpawner panel;
    [SerializeField] private LifeSystem lifePlayer;
    [SerializeField] private Bullet bala;

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
}
