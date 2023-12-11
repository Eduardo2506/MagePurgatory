using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NabamTutorial : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float explosionRadius = 2f;
    public int explosionDamage = 10;

    private Transform player;
    private LifeSystemTutorial lifePlayer;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false;
    private float originalMoveSpeed;

    private bool isFrozen = false;

    private PlayerMovement playerMovement;
    private CircleCollider2D colider;
    private AudioSource followAudioSource;



    private void Start()
    {
        colider = GetComponent<CircleCollider2D>();
        followAudioSource = GetComponent<AudioSource>();

        originalMoveSpeed = moveSpeed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();

        lifePlayer = player.GetComponent<LifeSystemTutorial>();

        playerMovement = player.GetComponent<PlayerMovement>();//
    }

    private void Update()
    {
        if (!isFrozen)
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

    private void Explode()
    {
        if (lifePlayer != null)
        {
            lifePlayer.TakeDamage(explosionDamage);

            float damagePercentage = (float)explosionDamage / (float)lifePlayer.maxHealth;
            playerMovement.healthBar.fillAmount = Mathf.Max(0, playerMovement.healthBar.fillAmount - damagePercentage);
        }

        colider.enabled = false;
        Destroy(this);

        Destroy(gameObject);
    }
}

