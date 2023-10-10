using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Text textoContador;
    public Image imagenRonda;


    private void Start()
    {
        StartCoroutine(ShowImagenIncial());
        //StartCoroutine(StartGame());
        //StartCoroutine(SpawnEnemiesWithInterval());//
        //ActivateEleccion();
    }
    private IEnumerator ShowImagenIncial()
    {
        // Mostrar la imagen de inicio durante 3 segundos.
        imagenRonda.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);

        imagenRonda.gameObject.SetActive(false);

        StartCoroutine(ShowContador());
    }
    private IEnumerator ShowContador()
    {
        // Mostrar la cuenta regresiva durante 3 segundos.
        textoContador.gameObject.SetActive(true);

        for (int i = 3; i >= 1; i--)
        {
            textoContador.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        textoContador.gameObject.SetActive(false);

        // Comenzar a spawnear enemigos.
        StartCoroutine(SpawnEnemiesWithInterval());

        ActivateEleccion();
    }
    //private IEnumerator StartGame()
    //{
    //    texto.gameObject.SetActive(true);
    //    imagen.gameObject.SetActive(true);

    //    for (int i = 3; i >= 1; i--)
    //    {
    //        texto.text = i.ToString();
    //        yield return new WaitForSeconds(1f);
    //    }
    //    texto.gameObject.SetActive(false);
    //    imagen.gameObject.SetActive(false);

    //    StartCoroutine(SpawnEnemiesWithInterval());
    //    ActivateEleccion();
    //}
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
            Debug.Log("Esperando 3 segundos para activar el panel");
            spawningEnabled = false;

            Invoke("ActivatePanel", 3.0f);
            //Debug.Log("Panel Activado");
            //spawningEnabled = false;

            //if (panelToActivate != null)
            //{
            //    panelToActivate.SetActive(true);
            //}

            //Time.timeScale = 0f;

            //cetroController.canShoot = false;
        }
    }
    private void ActivatePanel()
    {
        Debug.Log("Panel Activado");

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }

        Time.timeScale = 0f;

        cetroController.canShoot = false;
    }
}
