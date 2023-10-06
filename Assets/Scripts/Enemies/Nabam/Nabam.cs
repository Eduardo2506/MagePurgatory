using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nabam : MonoBehaviour
{
    public float moveSpeed = 5f;  
    public float explosionRadius = 2f;  
    public int explosionDamage = 10;  

    private Transform player; 
    private LifeSystem lifePlayer;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false;
    private float originalMoveSpeed;

    private void Start()
    {

        originalMoveSpeed = moveSpeed;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        lifePlayer = player.GetComponent<LifeSystem>();
    }

    private void Update()
    {
       
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (Vector3.Distance(transform.position, player.position) < explosionRadius)
        {
            Explode();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balahielo"))
        {
            if (!isSlowed)
            {
                moveSpeed /= 5;
                isSlowed = true;
                StartCoroutine(ResetSpeedAfterDelay());
            }
        }
    }

    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        // Restaura la velocidad original y la variable de ralentización
        moveSpeed = originalMoveSpeed;
        isSlowed = false;
    }

    private void Explode()
    {
        
        if (lifePlayer != null)
        {
            lifePlayer.TakeDamage(explosionDamage);
        }
        GetComponentInParent<EnemySpawner>().EnemyKilled();

        Destroy(gameObject);
    }
}
