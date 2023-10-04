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

    private void Start()
    {
        
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
