using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;  
    public Transform[] spawnPoints;    
    public int maxEnemies = 10;       

    public int currentEnemies = 0;   
    public int enemiesActuales = 0;

    public float spawnInterval = 2f;
    private bool spawningEnabled = true;

    public GameObject panelToActivate;
    public CetroController cetroController;


    private void Start()
    {
        StartCoroutine(SpawnEnemiesWithInterval());//
        ActivateEleccion();
    }
    private IEnumerator SpawnEnemiesWithInterval()
    {
        while (spawningEnabled)
        {
            if (currentEnemies < maxEnemies)
            {
                SpawnEnemy();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void Update()
    {
        //if (currentEnemies < maxEnemies)
        //{
        //    SpawnEnemy();
        //}
    }

    private void SpawnEnemy()
    {
        
        int enemys = Random.Range(0, enemyPrefabs.Length);
        int spawnPointEnemies = Random.Range(0, spawnPoints.Length);

        /*GameObject enemy =*/ Instantiate(enemyPrefabs[enemys], spawnPoints[spawnPointEnemies].position, Quaternion.identity, transform);

        
        currentEnemies++;
        enemiesActuales++;

       
        Debug.Log("Enemigos Actuales: " + enemiesActuales);


        ActivateEleccion();
    }

    public void EnemyKilled()
    {
        
        enemiesActuales--;


        ActivateEleccion();
    }

    private void ActivateEleccion()
    {
        
        if (currentEnemies == maxEnemies && enemiesActuales == 0)
        {
            Debug.Log("Panel Activado");
            spawningEnabled = false;

            if (panelToActivate != null)
            {
                panelToActivate.SetActive(true);
            }

            Time.timeScale = 0f;

            cetroController.canShoot = false;
        }
    }
}
