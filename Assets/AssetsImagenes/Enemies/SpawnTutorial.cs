using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTutorial : MonoBehaviour
{
    public Transform spawnPoint; 
    public GameObject enemyPrefab1; 
    public GameObject enemyPrefab2; 
    public GameObject enemyPrefab3;
    public GameObject panelEnemies;

    public void SpawnEnemy(int enemyType)
    {
        GameObject enemyPrefab = null;


        switch (enemyType)
        {
            case 1:
                enemyPrefab = enemyPrefab1;
                break;
            case 2:
                enemyPrefab = enemyPrefab2;
                break;
            case 3:
                enemyPrefab = enemyPrefab3;
                break;
            default:
                Debug.LogWarning("Tipo de enemigo no válido.");
                break;
        }

        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void SpawnEnemy1()
    {
        panelEnemies.SetActive(false);
        Time.timeScale = 1f;
        SpawnEnemy(1);
    }

    public void SpawnEnemy2()
    {
        panelEnemies.SetActive(false);
        Time.timeScale = 1f;
        SpawnEnemy(2);
    }

    public void SpawnEnemy3()
    {
        panelEnemies.SetActive(false);
        Time.timeScale = 1f;
        SpawnEnemy(3);
    }
}