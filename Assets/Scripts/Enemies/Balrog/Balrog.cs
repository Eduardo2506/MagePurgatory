using System.Collections;
using System.Collections.Generic;
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


    private void Start()
    {
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canAttack)
        {

            collision.gameObject.GetComponent<LifeSystem>().TakeDamage(damage);

            Vector2 directionPlayer = (collision.transform.position - transform.position).normalized;
            float pushForce = 5f;
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = directionPlayer * pushForce;
            collision.gameObject.GetComponent<PlayerMovement>().Push(directionPlayer, pushForce);



            canAttack = false;
            Invoke("ResetAttackCooldown", attackCooldown);
        }
        if (collision.gameObject.CompareTag("balahielo"))
        {
            if (!isSlowed)
            {
                moveSpeed /= 2;
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