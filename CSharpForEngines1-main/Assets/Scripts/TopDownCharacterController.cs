using System.Collections;
using System.Collections.Generic;
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
    private Vector2 playerDirection;

    //The speed at which they're moving
    private float playerSpeed = 1f;

    [Header("Movement parameters")]
    //The maximum speed the player can move
    [SerializeField] private float playerMaxSpeed = 100f;
    #endregion

   

    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] Transform m_firePoint;
    [SerializeField] float m_projectileSpeed;

    /// <summary>
    /// When the script first initialises this gets called, use this for grabbing componenets
    /// </summary>
    private void Awake()
    {
        //Get the attached components so we can use them later
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called after Awake(), and is used to initialize variables e.g. set values on the player
    /// </summary>
    private void Start()
    {
        
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
    /// </summary>
    bool Left = false;
    private void Update()
    {
        // read input from WASD keys
        playerDirection.x = Input.GetAxis("Horizontal");
        playerDirection.y = Input.GetAxis("Vertical");

        // check if there is some movement direction, if there is something, then set animator flags and make speed = 1
        if (playerDirection.magnitude != 0)
        {
            animator.SetFloat("Horizontal", playerDirection.x);
            animator.SetFloat("Vertical", playerDirection.y);
            animator.SetBool("IsWalking", true);

            //And set the speed to 1, so they move!
            
            playerSpeed = 1f;
            
        }
        else
        {
            //Was the input just cancelled (released)? If so, set
            //speed to 0
            
            playerSpeed = 0f;
            
            
            animator.SetBool("IsWalking", false);
        }



        if (playerDirection.x < -0.01f)
        {
            Left = true;
            ScaleX(-1);
        }
        else if (playerDirection.x > 0.01f)
        {
            Left = false;
            ScaleX(1);
        }

        
        if (animator.GetBool("IsWalking") == false)
        {
            ScaleX(Left ? -1 : 1);
        }
        // Was the fire button pressed (mapped to Left mouse button or gamepad trigger)
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot (well debug for now)
            //Debug.Log($"Shoot! {Time.time}", gameObject);
            Fire();
        }
    }

    void ScaleX(float X)
    {
        // Get the current scale of the GameObject
        Vector3 currentScale = transform.localScale;

        // Set the new scale for the X-axis within the specified range
        

        // Update the scale of the GameObject
        transform.localScale = new Vector3(X, currentScale.y, currentScale.z);
    }
    void Fire()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 Direction = mousePos - transform.position;

        GameObject bulletToSpawn = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity);

        if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(Direction.normalized * m_projectileSpeed, ForceMode2D.Impulse);
        }
       
    }

}