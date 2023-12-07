using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Balrog : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int damage = 20;
    public float attackCooldown = 5f;


    private Transform player;
    private bool canAttack = true;

    private SpriteRenderer spriteRenderer;

    private bool isSlowed = false;
    private float originalMoveSpeed;

    private bool isFrozen = false;
    private AudioSource followAudioSource;


    private void Start()
    {
        followAudioSource = GetComponent<AudioSource>();

        originalMoveSpeed = moveSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (canAttack && !isFrozen)
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
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {
            LifeSystem playerLife = collision.gameObject.GetComponent<LifeSystem>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
                
                PlayerMovement playerMov = collision.gameObject.GetComponent<PlayerMovement>();
                if (playerMov != null )
                {
                    float damagePercentage = (float)damage / (float)playerLife.maxHealth;
                    playerMov.healthBar.fillAmount = Mathf.Max(0, playerMov.healthBar.fillAmount - damagePercentage);
                }
            }

            LifeSystemTutorial playerLifeTutorial = collision.gameObject.GetComponent<LifeSystemTutorial>();
            if (playerLifeTutorial != null)
            {
                playerLifeTutorial.TakeDamage(damage);

                PlayerMovement playerMov = collision.gameObject.GetComponent<PlayerMovement>();
                if (playerMov != null)
                {
                    float damagePercentage = (float)damage / (float)playerLifeTutorial.maxHealth;
                    playerMov.healthBar.fillAmount = Mathf.Max(0, playerMov.healthBar.fillAmount - damagePercentage);
                }
            }

            //collision.gameObject.GetComponent<LifeSystem>().TakeDamage(damage);

            Vector2 directionPlayer = (collision.transform.position - transform.position).normalized;
            float pushForce = 2.5f;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = directionPlayer * pushForce;
            collision.gameObject.GetComponent<PlayerMovement>().Push(directionPlayer, pushForce);

            canAttack = false;
            Invoke("ResetAttackCooldown", attackCooldown);
        }
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

    private void ResetAttackCooldown()
    {

        canAttack = true;
    }
}