using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;


public class TopDownCharacterController : MonoBehaviour
{
    #region Framework Stuff
    //Reference to attached animator
    private Animator _animator;

    //Reference to attached rigid body 2D
    private Rigidbody2D _rb;

    //The direction the player is moving in
    public Vector2 playerDirection;

    //The speed at which they're moving
    private float _playerSpeed = 1f;

    [Header("Movement parameters")]
    //The maximum speed the player can move
    public float playerMaxSpeed;
    
    #endregion
    
   

    [FormerlySerializedAs("m_bulletPrefab")] [SerializeField]
    private GameObject mBulletPrefab;
    [FormerlySerializedAs("m_firePoint")] [SerializeField]
    private Transform mFirePoint;
    [FormerlySerializedAs("m_projectileSpeed")] [SerializeField]
    private float mProjectileSpeed;
    [FormerlySerializedAs("m_startingBullets")] 
    public int mStartingBullets;
    [SerializeField] private GameObject Size1BulletPrefab;
    [FormerlySerializedAs("BulletText")] public TMPro.TextMeshProUGUI bulletText;
    private static SpriteRenderer _sprite;
    private PlayerWeight _playerWeight;
    
    public GameObject pauseMenuUI;
    [FormerlySerializedAs("Paused")] public bool paused;
    public HoverUI hoverUI1;
    public HoverUI hoverUI2;
    public HoverUI hoverUI3;
    public HoverUI hoverUI4;
    public HoverUI hoverUI5;
    public HoverUI hoverUI6;
    [FormerlySerializedAs("Blood")] public ParticleSystem blood;
    [FormerlySerializedAs("FireEffect")] public ParticleSystem fireEffect;
    private bool _particleCooldown;
   private bool _fireParticleCooldown;
    [FormerlySerializedAs("HealthBar")] public GameObject healthBar;
    public GameObject bulletTextHolder;
    public GameObject weightTextHolder;
   
    [FormerlySerializedAs("Health")] public Health health;
    [FormerlySerializedAs("GameOVER")] public GameObject gameOver;
    [FormerlySerializedAs("_light2D")] public GameObject light2D;
    public GameObject biglight2D;
    private ShadowCaster2D _shadowCaster2D;
    public bool nofire;
    public bool returning;
    public GameObject moneyUIHolder;
    public TMPro.TextMeshProUGUI moneyLabel;
    private Upgrades _upgrades;
    [SerializeField] private AudioSource fireAudioSource;
    public bool end;
   public bool dead;
    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing components
    /// </summary>
    private void Awake()
    {
        _playerWeight = GetComponent<PlayerWeight>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _shadowCaster2D = GetComponent<ShadowCaster2D>();
        StartCoroutine(Begin(0.1f));



    }
    
    private void Start()
    {
        bulletText.text = "Projectiles: " + mStartingBullets;
    }

    /// <summary>
    /// When a fixed update loop is called, it runs at a constant rate, regardless of pc performance so physics can be calculated properly
    /// </summary>
    private void FixedUpdate()
    {
        //Set the velocity to the direction they're moving in, multiplied
        //by the speed they're moving
        _rb.velocity = playerDirection * (_playerSpeed * playerMaxSpeed * Time.fixedDeltaTime);

        bulletText.text = "Projectiles: " + mStartingBullets;
        if (mStartingBullets > 5)
        {
            mStartingBullets = 5;
        }
    }

    /// When the update loop is called, it runs every frame, ca run more or less frequently depending on performance. Used to catch changes in variables or input.
    [FormerlySerializedAs("Left")] public  bool left;

    private static readonly int Dead = Animator.StringToHash("Dead");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void Update()
    {
        
        
        if(SceneManager.GetSceneByName("StartingHotelLobby").isLoaded || SceneManager.GetSceneByName("Hotel Lobby").isLoaded || SceneManager.GetSceneByName("Hotel Lobby Death").isLoaded)
        {
            healthBar.SetActive(false);
            bulletTextHolder.SetActive(false);
            weightTextHolder.SetActive(false);
            light2D.SetActive(false);
            biglight2D.SetActive(false);
            health.health = 100;
            
            
            _shadowCaster2D.castsShadows = true;
        }
        
        else if (SceneManager.GetSceneByName("StartingHotelLobby").isLoaded == false || SceneManager.GetSceneByName("Hotel Lobby").isLoaded == false || SceneManager.GetSceneByName("Hotel Lobby Death").isLoaded == false)
        {
            healthBar.SetActive(true);
            bulletTextHolder.SetActive(true);
            weightTextHolder.SetActive(true);
           
            if (_upgrades.biglight)
            {
                biglight2D.SetActive(true);
                light2D.SetActive(false);
            }
            else
            {
                biglight2D.SetActive(false);
                light2D.SetActive(true);
            }
            
            _shadowCaster2D.castsShadows = false;

        }

        if (SceneManager.GetSceneByName("Hotel Lobby").isLoaded || SceneManager.GetSceneByName("Hotel Lobby Death").isLoaded)
        {
            moneyUIHolder.SetActive(true);
            
        }
        else if (SceneManager.GetSceneByName("StartingHotelLobby").isLoaded || SceneManager.GetSceneByName("Hotel Lobby").isLoaded == false || SceneManager.GetSceneByName("Hotel Lobby Death").isLoaded == false)
        {
            moneyUIHolder.SetActive(false);
        }
        
        if (!end)
        {  
         UpdateMaxSpeed();
        }
        else 
        {
          NoSpeed();
          _animator.SetTrigger("End");
        }
        

        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");
        
        if (health.health <= 0)
        {
            _animator.SetBool(Dead, true);
            dead = true;
            _playerSpeed = 0f;
            playerMaxSpeed = 0f;
            
            if(dead)
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
            _sprite.flipX = playerDirection.x switch
            {
                < -0.01f => true,
                > 0.01f => false,
                _ => _sprite.flipX
            };

            if (playerDirection.magnitude != 0)
            {
                _animator.SetFloat(Horizontal, playerDirection.x);
                _animator.SetFloat(Vertical, playerDirection.y);
                _animator.SetBool(IsWalking, true);
                _playerSpeed = 1f;
            }
            else
            {
                _playerSpeed = 0f;
                _animator.SetBool(IsWalking, false);
            }
        }


        if (!Input.GetButtonDown("Fire1") || mStartingBullets <= 0 || nofire  || dead ||
            SceneManager.GetSceneByName("StartingHotelLobby").isLoaded  ||
            SceneManager.GetSceneByName("Hotel Lobby").isLoaded  ||
            SceneManager.GetSceneByName("Hotel Lobby Death").isLoaded ) return;
        if (_upgrades.projectileSize1)
        {
            FireSize1();
        }

        if (!_upgrades.projectileSize1)
        {
            Fire();  
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || _particleCooldown) return;
        StartCoroutine(PlayHitParticles());
        StartCoroutine(HitFlash());

    }

    private void Fire()
    {
        switch (dead)
        {
            case false when paused == false  && hoverUI1.noFire == false && hoverUI2.noFire == false && hoverUI3.noFire == false && hoverUI4.noFire == false && hoverUI5.noFire == false && hoverUI6.noFire == false:
            {
                var mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;

                Vector2 direction = mousePos - transform.position;

                mStartingBullets = mStartingBullets - 1;
                bulletText.text = "Projectiles: " + mStartingBullets;
                fireAudioSource.Play();
                var bulletToSpawn = Instantiate(mBulletPrefab, mFirePoint.position, Quaternion.identity);
                if (_fireParticleCooldown == false) 
                {
                    StartCoroutine(PlayFireParticles());
                }

                if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
                {
                    bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(direction.normalized * mProjectileSpeed, ForceMode2D.Impulse);
                }

                break;
            }
            case true:
                // Nothing
                break;
        }
    }
    private void FireSize1()
    {
        switch (dead)
        {
            case false when paused == false  && hoverUI1.noFire == false && hoverUI2.noFire == false && hoverUI3.noFire == false && hoverUI4.noFire == false && hoverUI5.noFire == false && hoverUI6.noFire == false:
            {
                var mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0f;

                Vector2 direction = mousePos - transform.position;

                mStartingBullets = mStartingBullets - 1;
                bulletText.text = "Projectiles: " + mStartingBullets;
                fireAudioSource.Play();
                var bulletToSpawn = Instantiate(Size1BulletPrefab, mFirePoint.position, Quaternion.identity);
                if (_fireParticleCooldown == false) 
                {
                    StartCoroutine(PlayFireParticles());
                }

                if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
                {
                    bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(direction.normalized * mProjectileSpeed, ForceMode2D.Impulse);
                }

                break;
            }
            case true:
                // Nothing
                break;
        }
    }

    private void TogglePauseMenu()
    {
        switch (paused)
        {
            case false:
                paused = true;
                Time.timeScale = 0f;
                pauseMenuUI.SetActive(true);
                break;
            case true:
                paused = false;
                Time.timeScale = 1f;
                pauseMenuUI.SetActive(false);
                break;
        }
    }

    private IEnumerator PlayHitParticles()
    {
        _particleCooldown = true;
        blood.Play();
        
        
        yield return new WaitForSeconds(2.5f);
        
        blood.Stop();
        _particleCooldown = false;
    }

    private IEnumerator PlayFireParticles()
    {
        _fireParticleCooldown = true;
        fireEffect.Play();
        

        yield return new WaitForSeconds(0.5f);

        fireEffect.Stop();
        _fireParticleCooldown = false;
    }

    private IEnumerator HitFlash()
    {

        
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;
        
        yield return new WaitForSeconds(0.2f);
    }

    private IEnumerator Wait()
     {
        yield return new WaitForSeconds(1.5f);
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void Back()
    {
        if (!paused) return;
        paused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);

    }

    private void UpdateMaxSpeed()
    {
        playerMaxSpeed = 200f;
        playerMaxSpeed = playerMaxSpeed - _playerWeight.trueWeight;
        
    }
    private void NoSpeed()
    {
            playerMaxSpeed = 0f;
            
            
        }
    private IEnumerator Begin(float time)
    {
        
        yield return new WaitForSeconds(time);
        _upgrades = FindObjectOfType<Upgrades>();
        

    }  
}
