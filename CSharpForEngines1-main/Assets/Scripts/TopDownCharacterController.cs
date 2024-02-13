using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Stuff
    //Reference to attached animator
    private Animator animator;

    //Reference to attached rigidbody 2D
    private Rigidbody2D rb;

    //The direction the player is moving in
    public Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    [Header("Movement parameters")]
    //The maximum speed the player can move
    public float playerMaxSpeed;
    
    #endregion
    
   

    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] Transform m_firePoint;
    [SerializeField] float m_projectileSpeed;
    [SerializeField] int m_startingBullets;
    public TMPro.TextMeshProUGUI BulletText;
    private SpriteRenderer sprite;
    PlayerWeight playerWeight;
    
    public GameObject pauseMenuUI;
    public bool Paused = false;
    public HoverUI hoverUI1;
    public HoverUI hoverUI2;
    public HoverUI hoverUI3;
    public HoverUI hoverUI4;
    public HoverUI hoverUI5;
    public HoverUI hoverUI6;
    public ParticleSystem Blood;
    public ParticleSystem FireEffect;
    private bool ParticleCooldown = false;
   private bool FireParticleCooldown = false;
    public GameObject HealthBar;
    public GameObject Canvas;
    

    public Health Health;
    public GameObject GameOVER;
   public bool dead = false;
    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing componenets
    /// </summary>
    private void Awake()
    {
        playerWeight = GetComponent<PlayerWeight>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
    }
    
    private void Start()
    {
        BulletText.text = "Bullets: " + m_startingBullets;
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc perfornamce so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        rb.velocity = playerDirection * (playerSpeed * playerMaxSpeed) * Time.fixedDeltaTime;
    }

    /// <summary>
    /// When the update loop is called, it runs every frame, ca run more or less frequently depending on performance. Used to catch changes in variables or input.
    /// <summary>
  public  bool Left = false;
    private void Update()
    {
        if(SceneManager.GetSceneByName("StartingHotelLobby").isLoaded)
        {
            HealthBar.SetActive(false);
            Canvas.SetActive(false);
        }
        else if (SceneManager.GetSceneByName("StartingHotelLobby").isLoaded == false)
        {
            HealthBar.SetActive(true);
            Canvas.SetActive(true);
        }

        updateMaxSpeed();

        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");
        
        if (Health.health <= 0)
        {
            animator.SetBool("Dead", true);
            dead = true;
            playerSpeed = 0f;
            playerMaxSpeed = 0f;
            
            if(dead == true)
            {
              StartCoroutine(Wait());
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && dead == false)
        {
            TogglePauseMenu();
        }

        if (dead == false)
        {
            if (playerDirection.x < -0.01f)
            {
                sprite.flipX = true;
            }
            else if (playerDirection.x > 0.01f)
            {
                sprite.flipX = false;
            }

            
            if (playerDirection.magnitude != 0)
            {
                animator.SetFloat("Horizontal", playerDirection.x);
                animator.SetFloat("Vertical", playerDirection.y);
                animator.SetBool("IsWalking", true);
                playerSpeed = 1f;
            }
            else
            {
                playerSpeed = 0f;
                animator.SetBool("IsWalking", false);
            }
        }

        
        if (Input.GetButtonDown("Fire1") && m_startingBullets > 0 && dead == false && SceneManager.GetSceneByName("StartingHotelLobby").isLoaded == false)
        {
            Fire();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && ParticleCooldown == false)
        {
             
            StartCoroutine(PlayHitParticles());
            StartCoroutine(HitFlash());
        }
        
    }
    
    void Fire()
        {
            if (dead == false && Paused == false && hoverUI1.noFire == false && hoverUI2.noFire == false && hoverUI3.noFire == false && hoverUI4.noFire == false && hoverUI5.noFire == false && hoverUI6.noFire == false)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;

                Vector2 Direction = mousePos - transform.position;

                m_startingBullets = m_startingBullets - 1;
                BulletText.text = "Bullets: " + m_startingBullets;
                GameObject bulletToSpawn = Instantiate(m_bulletPrefab, m_firePoint.position, Quaternion.identity);
            if (FireParticleCooldown == false) 
            {
            StartCoroutine(PlayFireParticles());
            }

                if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
                {
                    bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * m_projectileSpeed, ForceMode2D.Impulse);
                }
            }
            else if (dead == true)
            {
                // Nothing
            }
        }

    public void TogglePauseMenu()
    {
        if (Paused == false)
        {
            Paused = true;
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
        else if (Paused == true)
        {
            Paused = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }
    IEnumerator PlayHitParticles()
    {
        ParticleCooldown = true;
        Blood.Play();
        
        yield return new WaitForSeconds(2.5f);
        
        Blood.Stop();
        ParticleCooldown = false;
    }

    IEnumerator PlayFireParticles()
    {
        FireParticleCooldown = true;
        FireEffect.Play();

        yield return new WaitForSeconds(0.5f);

        FireEffect.Stop();
        FireParticleCooldown = false;
    }
    IEnumerator HitFlash()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
    }
   
    IEnumerator Wait()
     {
        yield return new WaitForSeconds(1.5f);
        GameOVER.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Back()
    {
        if (Paused == true)
        {
            Paused = false;
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
       
    }
    public void updateMaxSpeed()
    {
        playerMaxSpeed = 200f;
        playerMaxSpeed = playerMaxSpeed - playerWeight.trueWeight;
    }
}
