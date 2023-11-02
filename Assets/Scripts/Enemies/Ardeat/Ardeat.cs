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
    public bool canShoot = false;

    public float initialDelay = 10f;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false; 
    private float originalMoveSpeed;

    private bool isFrozen = false;

    public float attackDistance = 5f;
    private void Start()
    {
        originalMoveSpeed = moveSpeed; 

        //currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Inicia el disparo de fuego en un bucle.
        //InvokeRepeating("ShootFireball", 0f, fireballCooldown);
        Invoke("EnableShooting", initialDelay);//
    }

    private void Update()
    {
        if (!isFrozen)
        {
            Vector2 direction = player.position - transform.position;
            float distanceToPlayer = direction.magnitude;
            if (distanceToPlayer <= attackDistance)
            {
                moveSpeed = 0f;
                canShoot = true;
            }
            else
            {
                moveSpeed = 3f;
                canShoot = false;
            }
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
        //Vector2 direction = player.position - transform.position;
        //direction.Normalize();

        //if (direction.x < 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else
        //{
        //    spriteRenderer.flipX = false;
        //}

        //transform.Translate(direction * moveSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balahielo"))
        {
            if (!isSlowed)
            {
                moveSpeed /= 3;
                isSlowed = true;
                StartCoroutine(ResetSpeedAfterDelay());
            }
        }
        if (collision.gameObject.CompareTag("balatierra"))
        {
            FreezeEnemy();
        }
    }
    private void FreezeEnemy()
    {
        isFrozen = true;
        moveSpeed = 0f;

        StartCoroutine(UnfreezeAfterDelay(2f));
    }
    private IEnumerator UnfreezeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isFrozen = false;
        moveSpeed = originalMoveSpeed;
    }
    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(4f);
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
            fireball.transform.right = direction;
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
