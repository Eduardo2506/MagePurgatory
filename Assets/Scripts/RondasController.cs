using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RondasController : MonoBehaviour
{
    private int ronda = 1;
    public EnemySpawner enemy;

    //private int maxEnemiesPerRound = 3;//

    public TextMeshProUGUI  textoRonda;
    public TextMeshProUGUI textoContador;
    public GameObject panelVictoria;   
    private IEnumerator Start()
    {
        textoRonda.transform.parent.gameObject.SetActive(true);
        enemy.currentEnemies = 0;
        enemy.currentEnemyType = 0;//
        //tiempo de espera al inicar
        textoRonda.text = $"Ronda: {ronda}";
        yield return new WaitForSeconds(3);
        textoContador.gameObject.SetActive(true);
        textoRonda.transform.parent.gameObject.SetActive(false);
        for (int i = 3; i > 0; i--)
        {
            textoContador.text = i.ToString();
            //$"ronda: {ronda}"
            yield return new WaitForSeconds(1);
        }
        textoContador.gameObject.SetActive(false);

        //spawn
        Coroutine corutina = StartCoroutine(enemy.SpawnEnemy());
        

        yield return new WaitUntil(() => enemy.currentEnemies == enemy.maxEnemies && enemy.enemiesActuales == 0);
        StopCoroutine(corutina);
        ronda++;

        // Ajustar los enemigos y los valores en enemyTypeCounts manualmente.
        int incremento1 = 1; // Personaliza estos valores según tus necesidades.
        int incremento2 = 1;
        int incremento3 = 1;

        enemy.maxEnemies += incremento1 + incremento2 + incremento3;
        enemy.enemyTypeCounts = CalcularEnemyTypeCounts(enemy.maxEnemies, incremento1, incremento2, incremento3);
        //// Aumentar los enemigos y ajustar los valores en enemyTypeCounts.
        //int aumentoDeEnemigos = 3; // Puedes ajustar este valor según tus necesidades.
        //enemy.maxEnemies += aumentoDeEnemigos;

        //// Ajustar los valores en enemyTypeCounts para que la suma sea igual a maxEnemies.
        //int[] nuevosEnemyTypeCounts = CalcularEnemyTypeCounts(enemy.maxEnemies);
        //enemy.enemyTypeCounts = nuevosEnemyTypeCounts;


        //enemy.maxEnemies += maxEnemiesPerRound;

        if (ronda >= 8)
        {
            yield return new WaitForSeconds(3);
            panelVictoria.SetActive(true);
            Debug.Log("ganaste");
     
            yield break;
        }

        //aparecer cartas
        yield return new WaitForSeconds(4);
        yield return new WaitUntil(() => enemy.panelToActivate.activeSelf == false);
        StartCoroutine(Start());
    }
    private int[] CalcularEnemyTypeCounts(int maxEnemies, int incremento1, int incremento2, int incremento3)
    {
        int[] nuevosEnemyTypeCounts = new int[enemy.enemyTypeCounts.Length];

        // Asignar incrementos personalizados a cada valor en enemyTypeCounts.
        nuevosEnemyTypeCounts[0] = enemy.enemyTypeCounts[0] + incremento1;
        nuevosEnemyTypeCounts[1] = enemy.enemyTypeCounts[1] + incremento2;
        nuevosEnemyTypeCounts[2] = enemy.enemyTypeCounts[2] + incremento3;

        // Asegurar que la suma sea igual a maxEnemies.
        int diferencia = maxEnemies - nuevosEnemyTypeCounts.Sum();
        nuevosEnemyTypeCounts[2] += diferencia;

        return nuevosEnemyTypeCounts;
    }
    // Función para calcular los nuevos valores en enemyTypeCounts.
    //private int[] CalcularEnemyTypeCounts(int maxEnemies)
    //{
    //    // Puedes ajustar la lógica según tus necesidades.
    //    int[] nuevosEnemyTypeCounts = new int[enemy.enemyTypeCounts.Length];

    //    for (int i = 0; i < nuevosEnemyTypeCounts.Length; i++)
    //    {
    //        nuevosEnemyTypeCounts[i] = maxEnemies / nuevosEnemyTypeCounts.Length;
    //    }

    //    // Ajustar el último valor para asegurarse de que la suma sea igual a maxEnemies.
    //    nuevosEnemyTypeCounts[nuevosEnemyTypeCounts.Length - 1] += maxEnemies % nuevosEnemyTypeCounts.Length;

    //    return nuevosEnemyTypeCounts;
    //}


}
