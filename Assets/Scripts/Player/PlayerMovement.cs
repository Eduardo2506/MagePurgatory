using System.Collections;
using UnityEngine;

using UnityEngine.UI;

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

    private bool isBeingPushed = false; 
    public float pushDuration = 0.5f; 
    private float pushEndTime = 0f;


    [SerializeField] private Image energyBar;
   
    private float energyRechargeDelay = 10.0f; 
    private float lastEnergyUsedTime; 


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

        if (energyBar.fillAmount < 1.0f && Time.time - lastEnergyUsedTime >= energyRechargeDelay)//
        {
            // Recargar la barra de energía después de 10 segundos
            float rechargeRate = 0.1f; // Ajusta la velocidad de recarga
            energyBar.fillAmount = Mathf.Clamp(energyBar.fillAmount + (rechargeRate * Time.deltaTime), 0.0f, 1.0f);
        }
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
        float teleportCostPercentage = 0.5f; //0.1f
        if (energyBar.fillAmount - teleportCostPercentage >= 0)
        {
            Vector2 teleportPosition = mousePos;
            playerTransform.position = teleportPosition;

            energyBar.fillAmount -= teleportCostPercentage;

            lastEnergyUsedTime = Time.time;//
        }
        else
        {
            particulasTp.Stop();
        }

       
    }
    void StartDash()
    {
        particulasDash.Play();//
        isDashing = true;
        lastDashTime = Time.time;

        
        float dashCostPercentage = 0.3f; //0.09f
        if (energyBar.fillAmount - dashCostPercentage >= 0)
        {
            Vector2 dashDirection = moveInput.normalized;
            rb.velocity = dashDirection * moveSpeed * 3f;

            energyBar.fillAmount -= dashCostPercentage;

            lastEnergyUsedTime = Time.time;//

        }
        else
        {
            particulasDash.Stop();
        }
        

        StartCoroutine(StopDash());
    }

    private IEnumerator StopDash()
    {
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;


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
