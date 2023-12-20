using UnityEngine;
using System.Collections;

public class HeroKnight : MonoBehaviour 
{

    [SerializeField] float      speed = 4.0f;
    [SerializeField] bool       noBlood = false;
    public Transform GroundCheck;
    public Transform CheckPoint;
    public LayerMask Ground;
    public LayerMask Death;
    private Vector2 moveVector;
    private Attack attack;
    public bool OnGround;
    private bool jumpControl;
    private bool faceRight = true;
    public float jumpForce = 160f;
    private float jumpTime = 0;
    private float jumpControlTime = 0.7f;
    private float GroundCheckRadius;
    private GameObject obj;
    private Animator            animator;
    private Rigidbody2D         rb;
   // private Sensor_HeroKnight   groundSensor;
    //private int                 facingDirection = 1;
    private int                 currentAttack = 0;
    private float               timeSinceAttack = 0.0f;
    private float               delayToIdle = 0.0f;
    
    void Start ()
    {
        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        attack = GetComponent<Attack>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update ()
    {
        // Increase timer that controls attack combo
        timeSinceAttack += Time.deltaTime;

        // -- Handle input and movement --
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        //if (inputX > 0)
        //{
        //    GetComponent<SpriteRenderer>().flipX = false;
        //    facingDirection = 1;
        //}
            
        //else if (inputX < 0)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    facingDirection = -1;
        //}

        // Move
        //if (!m_rolling )
        //  rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        //Set AirSpeed in animator
        //animator.SetFloat("AirSpeedY", rb.velocity.y);

        
        //Attack
       // else if(Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f)
           if (Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f)
                {
            attack.AttackHero(inputX);
            currentAttack++;

            // Loop back to one after third attack
            if (currentAttack > 3)
                currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (timeSinceAttack > 1.0f)
                currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            animator.SetTrigger("Attack" + currentAttack);

            // Reset timer
            timeSinceAttack = 0.0f;
        }

        // Block
        else if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Block");
            animator.SetBool("IdleBlock", true);
        }

        else if (Input.GetMouseButtonUp(1))
            animator.SetBool("IdleBlock", false);

        //Run
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            // Reset timer
            delayToIdle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }

        //Idle
        else
        {
            // Prevents flickering transitions to idle
            delayToIdle -= Time.deltaTime;
                if(delayToIdle < 0)
                    animator.SetInteger("AnimState", 0);
        }
        CheckingGround();
        Jump();
        Reflect();
        Walk();
        RemoveAttack();
    }

    void RemoveAttack()
    {
        obj = GameObject.FindGameObjectWithTag("RemoveAttack");
        Destroy(obj, 0.2f);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (OnGround) 
            {
                 jumpControl = true;
                 animator.SetTrigger("Jump");
            }
        }
        else { jumpControl = false; }
        if (jumpControl)
        {
            if ((jumpTime += Time.fixedDeltaTime) < jumpControlTime)
            {
                rb.AddForce(Vector2.up * jumpForce / (jumpTime * 10));
            }
        }
        else { jumpTime = 0; }
    }

    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, Ground);
        animator.SetBool("Grounded", OnGround);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Death"))
        {           
            animator.SetBool("noBlood", noBlood);
            animator.SetTrigger("Death");
            transform.position = CheckPoint.position;
        }
    }

    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    void Walk()
    {
       animator.SetFloat("moveX", Mathf.Abs(moveVector.x));
       // animator.SetInteger("AnimState", 1);
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
}
