using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movimiento
    [SerializeField] public float moveSpeed; // Velocidad de movimiento
    Vector2 moveInput;
    Animator animator;
    Rigidbody2D rb;

    //Dash
    [SerializeField] public float dashCooldown = 2f;
    [SerializeField] float dashDuration = 0.5f;
    private bool isDashing = false;//
    private float lastDashTime;

    //Teletransportacion
    public Transform playerTransform;
    public float teleportCooldown = 5f;
    private float lastTeleportTime;
    private bool canTeleport = true;
    Vector2 mousePos;
    public Camera cam;

    [SerializeField] private ParticleSystem particulasDash;
    [SerializeField] private ParticleSystem particulasTp;
    //private SpriteRenderer spriteRenderer;//

    private bool isBeingPushed = false; // Variable para controlar el empuje
    public float pushDuration = 0.5f; // Duración del empuje
    private float pushEndTime = 0f; // Tiempo en que termina el empuje


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();


        //spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
      
         moveInput.x = Input.GetAxis("Horizontal");
         moveInput.y = Input.GetAxis("Vertical");

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//

         transform.Translate(moveInput * Time.deltaTime * moveSpeed);
         animator.SetBool("isMoving", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));

        if (isBeingPushed && Time.time >= pushEndTime)//
        {
            isBeingPushed = false;
            rb.velocity = Vector2.zero;
        }
        //mousePos.x = Mathf.Clamp(mousePos.x, -10, 10);//tp fuera del mapa

        //Limite en y
        //mousePos.y = Mathf.Clamp(mousePos.y, -10, 10);//tp fuera del mapa

        

        //if (moveInput.x < 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
        //else if (moveInput.x > 0)
        //{
        //    spriteRenderer.flipX = false;
        //}

        
        //dash
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastDashTime >= dashCooldown)
        {
            StartDash();
        }

        float timeLastDash = Time.time - lastDashTime;
        float cooldownPercentage = Mathf.Clamp01(timeLastDash / dashCooldown);

        //teleport
        if (Input.GetKeyDown(KeyCode.T) && canTeleport)
        {
            TeleportToMousePosition();
            canTeleport = false;
            lastTeleportTime = Time.time;//
            lastDashTime = Time.time;
        }
        if (!canTeleport && Time.time - lastTeleportTime >= teleportCooldown)
        {
            canTeleport = true;
        }
        float timeLastTeleport = Time.time - lastTeleportTime;
        float teleporCooldownPercentage = Mathf.Clamp01(timeLastTeleport / teleportCooldown);
    }
    public void Push(Vector2 pushDirection, float pushForce)//
    {
        isBeingPushed = true;
        pushEndTime = Time.time + pushDuration;

        rb.velocity = pushDirection * pushForce;
    }
    void TeleportToMousePosition()
    {
        particulasTp.Play();//
        
        Vector2 teleportPosition = mousePos;
        playerTransform.position = teleportPosition;
    }
    void StartDash()
    {
        particulasDash.Play();//
        isDashing = true;
        lastDashTime = Time.time;

        // Aplicar el Dash (cambia la lógica según tus necesidades)
        Vector2 dashDirection = moveInput.normalized;
        rb.velocity = dashDirection * moveSpeed * 3f;

        // Aquí podrías desactivar la capacidad de mover al jugador durante el Dash si es necesario

        // Detener el Dash después de la duración especificada
        StartCoroutine(StopDash());
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        // Aquí podrías reactivar la capacidad de mover al jugador después del Dash si es necesario

        rb.velocity = Vector2.zero;
    }
    //private void FixedUpdate()
    //{
    //    if (!isDashing)
    //    {
    //        transform.Translate(moveInput * Time.deltaTime * moveSpeed);
    //    }
    //}

}
