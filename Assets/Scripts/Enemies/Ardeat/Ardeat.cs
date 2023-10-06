using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ardeat : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject fireballPrefab;
    public Transform pointFire; 
    public float fireballCooldown = 5f;


    private Transform player;
    private bool canShoot = true;

    public float initialDelay = 10f;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false; // Variable para rastrear si el enemigo está ralentizado
    private float originalMoveSpeed; // Almacena la velocidad original

    private void Start()
    {
        originalMoveSpeed = moveSpeed; // Almacena la velocidad original

        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Inicia el disparo de fuego en un bucle.
        //InvokeRepeating("ShootFireball", 0f, fireballCooldown);
        Invoke("EnableShooting", initialDelay);//
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(direction * moveSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balahielo"))
        {
            if (!isSlowed)
            {
                moveSpeed /= 2;
                isSlowed = true;
                StartCoroutine(ResetSpeedAfterDelay());
            }
        }
    }
    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(4f); // Espera 4 segundos
        // Restaura la velocidad original y la variable de ralentización
        moveSpeed = originalMoveSpeed;
        isSlowed = false;
    }
    private void EnableShooting()//
    {
        canShoot = true;
        ShootFireball(); 

        
        InvokeRepeating("ShootFireball", fireballCooldown, fireballCooldown);
    }
    private void ShootFireball()
    {
        if (canShoot)
        {
            if (GetComponent<ArdeatLive>() != null && GetComponent<ArdeatLive>().currentHealth <= 0)
            {
                DisableShooting();
                return;
            }
            GameObject fireball = Instantiate(fireballPrefab, pointFire.position, Quaternion.identity);


            Vector2 direction = (player.position - pointFire.position).normalized;

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = direction * fireball.GetComponent<FireBall>().fireballForce;
        }
    }
    public void DisableShooting()
    {
        canShoot = false;
        CancelInvoke("ShootFireball"); 
    }

}
