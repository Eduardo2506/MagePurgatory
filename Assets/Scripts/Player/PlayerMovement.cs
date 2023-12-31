using Cinemachine;
using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Movimiento
    [SerializeField] public float moveSpeed; 
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

    private bool isPushed = false; 
    public float pushDuration = 0.5f; 
    private float pushEndTime = 0f;


    [SerializeField] private Image energyBar;
    [SerializeField] public Image healthBar;
   
    public float energyRechargeDelay = 10.0f; 
    private float lastEnergyUsedTime;

    [SerializeField] public GameObject panelMesaCetros;
    private bool onMesa = false;
    private bool panelActivo = false;

    private SpriteRenderer spriteRenderer;//

    public bool canDashTutorial = true;
    public bool canTeleportTutorial = true;

    public GameObject panelEnemies;
    private bool onEnemies = false;
    private bool panelEnemiesActivo = false;

    public GameObject panelPowerUps;
    public bool onPowerUps;
    private bool panelPowerUpsActivo = false;

    public PauseManager pause;


    [SerializeField] private CetroController cetroNormalController;
    [SerializeField] private CetroFuegoController cetroFuegoController;
    [SerializeField] private CetroHieloController cetroHieloController;
    [SerializeField] private CetroRayoController cetroRayoController;
    [SerializeField] private CetroTierraController cetroTierraController;

    private float dash = 1;
    [SerializeField] private AudioSource dashAudioSource;
    [SerializeField] private AudioSource walkAudioSource;
    [SerializeField] private AudioSource tpAudioSource;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();


        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
      
         moveInput.x = Input.GetAxis("Horizontal");
         moveInput.y = Input.GetAxis("Vertical");

         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//

        if (dash > 1) dash -= Time.deltaTime * moveSpeed; else dash = 1;
        if (!isPushed)
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed) * dash;
            animator.SetBool("isWalk", (Mathf.Abs(moveInput.x) > 0 || Mathf.Abs(moveInput.y) > 0));
        }

        
        if (Mathf.Abs(moveInput.x) > 0.1f || Mathf.Abs(moveInput.y) > 0.1f)
        {
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.Play();
            }
        }
        else
        {
            walkAudioSource.Stop();
        }

        if (isPushed && Time.time >= pushEndTime)//
        {
            isPushed = false;
            rb.velocity = Vector2.zero;
        }

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX =  true;
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        //dash
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastDashTime >= dashCooldown && canDashTutorial)
        {
            if (moveInput.magnitude > 0.1f)
            {
                StartDash();

                MovimientoCamera.Instance.MoverCamara(6, 6, dashCooldown);
            }
        }

        float timeLastDash = Time.time - lastDashTime;
        float cooldownPercentage = Mathf.Clamp01(timeLastDash / dashCooldown);

        //teleport
        if (Input.GetMouseButtonDown(1) && canTeleport && canTeleportTutorial)
        {
            MovimientoCamera.Instance.MoverCamara(8, 8, 2);
            animator.SetBool("isTeleporting", false);
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
            float rechargeRate = 0.1f; 
            energyBar.fillAmount = Mathf.Clamp(energyBar.fillAmount + (rechargeRate * Time.deltaTime), 0.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.E) && onMesa && !pause.juegoPausado)
        {
            if (!panelActivo)
            {

                cetroNormalController.canShoot = false;

                cetroFuegoController.canShoot = false;
                cetroHieloController.canShoot = false;
                cetroRayoController.canShoot = false;
                cetroTierraController.canShoot = false;
                Time.timeScale = 0f;
                panelMesaCetros.SetActive(true);
                panelActivo = true;
            }
            else
            {
                cetroNormalController.canShoot = true;

                cetroFuegoController.canShoot = true;
                cetroHieloController.canShoot = true;
                cetroRayoController.canShoot = true;
                cetroTierraController.canShoot = true;
                Time.timeScale = 1f;
                panelMesaCetros.SetActive(false);
                panelActivo = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && onEnemies && !pause.juegoPausado)
        {
            if (!panelEnemiesActivo)
            {
                Time.timeScale = 0f;
                panelEnemies.SetActive(true);
                panelEnemiesActivo = true;
            }
            else
            {
                Time.timeScale = 1f;
                panelEnemies.SetActive(false);
                panelEnemiesActivo = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && onPowerUps && !pause.juegoPausado)
        {
            if (!panelPowerUpsActivo)
            {
                Time.timeScale = 0f;
                panelPowerUps.SetActive(true);
                panelPowerUpsActivo = true;
            }
            else
            {
                Time.timeScale = 1f;
                panelPowerUps.SetActive(false);
                panelPowerUpsActivo = false;
            }
        }

    }
    public void Push(Vector2 pushDirection, float pushForce)//
    {
        isPushed = true;
        pushEndTime = Time.time + pushDuration;

        rb.velocity = pushDirection * pushForce;
    }
    void TeleportToMousePosition()
    {
        particulasTp.Play();//
        float teleportCostPercentage = 0.1f; //0.1f
        if (energyBar.fillAmount - teleportCostPercentage >= 0)
        {
            animator.SetTrigger("isTeleporting");

            tpAudioSource.Play();

            Vector2 teleportPosition = mousePos;
            teleportPosition.x = Mathf.Clamp(teleportPosition.x, -10, 10);
            teleportPosition.y = Mathf.Clamp(teleportPosition.y, -10, 10);
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

        float dashCostPercentage = 0.09f; //0.09f
        if (energyBar.fillAmount - dashCostPercentage >= 0)
        {
            dash = 3;
            energyBar.fillAmount -= dashCostPercentage;

            lastEnergyUsedTime = Time.time;//

            if (dashAudioSource != null && !dashAudioSource.isPlaying)
            {
                dashAudioSource.Play();
            }

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mesa"))
        {
            onMesa = true;
        }
        if (other.CompareTag("Enemies"))
        {
            onEnemies = true;
        }
        if (other.CompareTag("PowerUps"))
        {
            onPowerUps = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mesa"))
        {
            onMesa = false;
            panelMesaCetros.SetActive(false);
        }
        if (other.CompareTag("Enemies"))
        {
            onEnemies = false;
            panelEnemies.SetActive(false);
        }
        if (other.CompareTag("PowerUps"))
        {
            onPowerUps = false;
        }
    }
    public void EnableDash()
    {
        canDashTutorial = true;
    }

    public void DisableDash()
    {
        canDashTutorial = false;
    }

    public void EnableTeleport()
    {
        canTeleportTutorial = true;
    }

    public void DisableTeleport()
    {
        canTeleportTutorial = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector2.zero, Vector2.one * 20 );
    }
}
