using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RondasController : MonoBehaviour
{
    private int ronda = 1;
    public EnemySpawner enemy;


    public TextMeshProUGUI  textoRonda;
    public TextMeshProUGUI textoContador;
       
    private IEnumerator Start()
    {
        textoRonda.transform.parent.gameObject.SetActive(true);
        enemy.currentEnemies = 0;
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
        Coroutine corutina = StartCoroutine(enemy.SpawnEnemiesWithInterval());
        

        yield return new WaitUntil(() => enemy.currentEnemies == enemy.maxEnemies && enemy.enemiesActuales == 0);
        StopCoroutine(corutina);
        ronda++;
        if (ronda >= 7)
        {
            Debug.Log("ganaste");
     
            yield break;
        }

        //aparecer cartas
        yield return new WaitForSeconds(4);
        yield return new WaitUntil(() => enemy.panelToActivate.activeSelf == false);
        StartCoroutine(Start());
    }
}
