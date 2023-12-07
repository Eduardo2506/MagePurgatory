using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RondasController : MonoBehaviour
{
    private int ronda = 1;
    public EnemySpawner enemy;

    public LifeSystem playerLife;

    //private int maxEnemiesPerRound = 3;//

    public TextMeshProUGUI  textoRonda;
    public TextMeshProUGUI textoContador;
    public GameObject panelVictoria;

    public LevelChanger fade;
    private IEnumerator Start()
    {
        textoRonda.transform.parent.gameObject.SetActive(true);
        enemy.currentEnemies = 0;
        enemy.currentEnemyType = 0;//
        //enemy.enemiesActuales = 0;/////
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

        //Ajustar los enemigos y los valores en enemyTypeCounts
        int incremento1 = 1;
        int incremento2 = 1;
        int incremento3 = 1;

        enemy.maxEnemies += incremento1 + incremento2 + incremento3;
        enemy.enemyTypeCounts = CalcularEnemyTypeCounts(enemy.maxEnemies, incremento1, incremento2, incremento3);


        if (ronda >= 7)//las rondas seran -uno de la que ponga, 8
        {
            if (SceneManager.GetActiveScene().name == "Game")
            {
                Debug.Log("Ganaste la ronda final del nivel 1");
                enemy.panelToActivate.SetActive(false);//

                yield return new WaitForSeconds(2);//
                Time.timeScale = 1f;//
                //yield return new WaitForSeconds(5);
                SceneManager.LoadScene("Nivel2");
                if (fade != null)
                {
                    fade.NexToNivel2();//
                }
                
                yield break;
                //SceneManager.LoadScene("Nivel 2");//
            }
            else if (SceneManager.GetActiveScene().name == "Nivel2")
            {
                Debug.Log("Ganaste la ronda final del nivel 2");
                enemy.panelToActivate.SetActive(false);

                yield return new WaitForSeconds(2);
                Time.timeScale = 1f;
                panelVictoria.SetActive(true);
                Debug.Log("ganaste");
                yield break;
            }
        }

        //Aparecer cartas
        yield return new WaitForSeconds(4);
        yield return new WaitUntil(() => enemy.panelToActivate.activeSelf == false);
        StartCoroutine(Start());
    }
    private int[] CalcularEnemyTypeCounts(int maxEnemies, int incremento1, int incremento2, int incremento3)
    {
        int[] nuevosEnemyTypeCounts = new int[enemy.enemyTypeCounts.Length];

        //Incrementar valores en enemyTypeCounts
        nuevosEnemyTypeCounts[0] = enemy.enemyTypeCounts[0] + incremento1;
        nuevosEnemyTypeCounts[1] = enemy.enemyTypeCounts[1] + incremento2;
        nuevosEnemyTypeCounts[2] = enemy.enemyTypeCounts[2] + incremento3;

        //Suma sea igual a maxEnemies
        int diferencia = maxEnemies - nuevosEnemyTypeCounts.Sum();
        nuevosEnemyTypeCounts[2] += diferencia;

        return nuevosEnemyTypeCounts;
    }
}
