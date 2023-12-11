using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArdearTUtorial : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject fireballPrefab;
    public Transform pointFire;
    public float fireballCooldown = 5f;


    private Transform player;
    private bool canShoot = true;

    public float initialDelay = 10f;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false;
    private float originalMoveSpeed;

    private bool isFrozen = false;
    
    [SerializeField] private float distance;

    private AudioSource followAudioSource;
    private void Start()
    {
        followAudioSource = GetComponent<AudioSource>();

        originalMoveSpeed = moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        Invoke("EnableShooting", initialDelay);//
    }

    private void Update()
    {
        if (!isFrozen)
        {
            Vector2 direction = player.position - transform.position;
            Vector2 point = (Vector2)player.position - (distance * direction.normalized);

            transform.position = Vector2.MoveTowards(transform.position, point, moveSpeed * Time.deltaTime);

            if (direction.x > 0) spriteRenderer.flipX = false;
            if (direction.x < 0) spriteRenderer.flipX = true;

            if (!followAudioSource.isPlaying)
            {
                followAudioSource.Play();
            }
        }
        else
        {
            followAudioSource.Pause();
        }
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
            if (GetComponent<ArdeatLifeTutorial>() != null && GetComponent<ArdeatLifeTutorial>().currentHealth <= 0)
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
