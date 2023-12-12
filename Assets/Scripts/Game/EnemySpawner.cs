using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f;
    public int[] enemyTypeCounts;
    public int maxEnemies = 7;


    public int currentEnemyType = 0;
    public int currentEnemies = 0;
    public int enemiesActuales = 0;

    private bool spawningEnabled = true;

    public GameObject panelToActivate;
    public CetroController cetroController;

    public Text textoContador;
    public Image imagenRonda;

    public PowerUpController powerUps;



    private void Start()
    {
    }
    private IEnumerator ShowImagenIncial()
    {
        imagenRonda.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);

        imagenRonda.gameObject.SetActive(false);

        StartCoroutine(ShowContador());
    }
    private IEnumerator ShowContador()
    {
        textoContador.gameObject.SetActive(true);

        for (int i = 3; i >= 1; i--)
        {
            textoContador.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        textoContador.gameObject.SetActive(false);
    }
    IEnumerator SpawnEnemiesWithInterval(GameObject enemyPrefab, int count, float interval)
    {
        for (int i = 0; i < count; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            enemiesActuales++;

            yield return new WaitForSeconds(interval);
        }
    }
    private void Update()
    {
    }
    public void PlayerDied()
    {
        StopAllCoroutines();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        currentEnemyType = 0;
        currentEnemies = 0;
        enemiesActuales = 0;
    }
    public IEnumerator SpawnEnemy()
    {
        int totalEnemiesSpawned = 0;

        while (currentEnemyType < enemyPrefabs.Length && totalEnemiesSpawned < maxEnemies)
        {
            int remainingEnemiesToSpawn = Mathf.Min(maxEnemies - totalEnemiesSpawned, enemyTypeCounts[currentEnemyType]);

            yield return SpawnEnemiesWithInterval(enemyPrefabs[currentEnemyType], remainingEnemiesToSpawn, spawnInterval);

            totalEnemiesSpawned += remainingEnemiesToSpawn;
            currentEnemies += remainingEnemiesToSpawn;

            currentEnemies = Mathf.Min(currentEnemies, maxEnemies);

            yield return WaitForEnemiesToBeDefeated();

            currentEnemyType++;

            if (currentEnemyType >= enemyPrefabs.Length)
                currentEnemyType = 0;
        }
    }
    IEnumerator WaitForEnemiesToBeDefeated()
    {
        while (enemiesActuales > 0)
        {
            yield return null;
        }
        enemiesActuales = 0;
    }
    public void EnemyKilled()
    {
        
        enemiesActuales--;


        ActivateEleccion();
    }

    public void ActivateEleccion()
    {
        
        if (currentEnemies == maxEnemies && enemiesActuales == 0)
        {
            Debug.Log("Esperando 3 segundos para activar el panel");
            spawningEnabled = false;

            Invoke("ActivatePanel", 3.0f);
        }
    }
    public void ActivatePanel()
    {
        Carta[] allCards = Resources.FindObjectsOfTypeAll<Carta>();//

        ShuffleArray(allCards);

        Debug.Log("Panel Activado");

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
            powerUps.PowerUps();
        }
        Time.timeScale = 0f;//0f


        cetroController.canShoot = false;
    }
    private void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
