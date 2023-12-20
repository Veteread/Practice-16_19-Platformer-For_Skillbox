using UnityEngine;

public class HeroKnight : MonoBehaviour 
{

    [SerializeField] private float speed = 4.0f;
    [SerializeField] private bool noBlood = false;
    public Transform GroundCheck;
    public Transform CheckPoint;
    public LayerMask Ground;
    public LayerMask Death;

    private Vector2 moveVector;
    private Attack attack;
    private Animator animator;
    private Rigidbody2D rb;

    private bool onGround;
    private bool faceRight = true;
    private bool jumpControl = true;

    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    private float delayToIdle = 0.0f;

    private float jumpForce = 160f;
    private float jumpTime = 0;
    private float jumpControlTime = 0.7f;
    private float groundCheckRadius;

    private GameObject obj;

    private void Start()
    {
        groundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        attack = GetComponent<Attack>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeSinceAttack += Time.deltaTime;

        float inputX = Input.GetAxis("Horizontal");

        HandleAttacks(inputX);
        HandleBlock();
        HandleMovement(inputX);
        CheckingGround();
        Jump();
        Reflect();
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
            if (onGround) 
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
        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, Ground);
        animator.SetBool("Grounded", onGround);
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
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    private void HandleAttacks(float inputX)
    {
        if (Input.GetMouseButtonDown(0) && timeSinceAttack > 0.25f)
        {
            attack.AttackHero(inputX);
            currentAttack = (currentAttack % 3) + 1;
            animator.SetTrigger("Attack" + currentAttack);
            timeSinceAttack = 0.0f;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Block");
            animator.SetBool("IdleBlock", true);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            animator.SetBool("IdleBlock", false);
        }
    }

    private void HandleBlock()
    {
        //... остальные части метода остаются такими же
    }

    private void HandleMovement(float inputX)
    {
        delayToIdle -= Time.deltaTime;

        if (Mathf.Abs(inputX) > Mathf.Epsilon)
        {
            delayToIdle = 0.05f;
            animator.SetInteger("AnimState", 1);
        }
        else
        {
            if (delayToIdle < 0)
            {
                animator.SetInteger("AnimState", 0);
            }
        }

        animator.SetFloat("moveX", Mathf.Abs(moveVector.x));
        moveVector.x = inputX;
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
}
