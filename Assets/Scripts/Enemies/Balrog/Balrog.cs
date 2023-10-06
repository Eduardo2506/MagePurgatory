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

    private void Start()
    {
        originalMoveSpeed = moveSpeed;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (canAttack)
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
    }
    private IEnumerator ResetSpeedAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        // Restaura la velocidad original y la variable de ralentización
        moveSpeed = originalMoveSpeed;
        isSlowed = false;
    }

    private void ResetAttackCooldown()
    {

        canAttack = true;
    }
}