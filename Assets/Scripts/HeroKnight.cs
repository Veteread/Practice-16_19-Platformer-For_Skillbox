using UnityEngine;
using UnityEngine.UI;

public class HeroKnight : MonoBehaviour
{
    
    public Transform GroundCheck;
    public Transform CheckPoint;
    public LayerMask Ground;
    public LayerMask Death;
    public GameObject Dead;
    public GameObject Finish;
    public Image img;

    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    private Attack attack;
    private GameObject obj;
    private AudioSource audioAttack;

    public float speed = 4.0f;
    public bool faceRight = true;
    public bool Block = false;
    public bool playerControl = false;
    
    private bool jumpControl = true;
    private bool onGround;
    private int currentAttack = 0;
    private float timeSinceAttack = 0.0f;
    private float delayToIdle = 0.0f;
    private float jumpForce = 180f;
    private float jumpTime = 0;
    private float jumpControlTime = 0.7f;
    private float groundCheckRadius;

    

    private void Start()
    {
        groundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        attack = GetComponent<Attack>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioAttack = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (playerControl == true)
        {
            float inputX = Input.GetAxis("Horizontal");
            timeSinceAttack += Time.deltaTime;            
            RemoveAttack();
            HandleAttacks(inputX);
            if (Block == false)
            {
                HandleMovement(inputX);
                Reflect();
                Jump();
                CheckingGround();
            }
        }

    }

    void RemoveAttack()
    {
        obj = GameObject.FindGameObjectWithTag("RemoveAttack");
        Destroy(obj, 0.1f);
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
        if (collision.CompareTag("Death"))
        {
            DeathHero();
        }
        if (collision.CompareTag("Finish"))
        {
            GetComponent<Vars>().LoadScoreFormlastLvl();
            FinishImage();
        }
    }

    public void DeathHero()
    {
        animator.SetTrigger("Death");
        Invoke("DeadImage", 1f);
    }

    private void DeadImage()
    {
        if (!Dead.activeSelf)
        {
            Dead.SetActive(true);            
            transform.position = CheckPoint.position;
        }
    }

    private void FinishImage()
    {

        if (!Finish.activeSelf)
        {
            Finish.SetActive(true);
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
            attack.AttackHero(faceRight);
            currentAttack = (currentAttack % 3) + 1;
            animator.SetTrigger("Attack" + currentAttack);
            timeSinceAttack = 0.0f;
            Block = false;
            audioAttack.Play();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Block");
            animator.SetBool("IdleBlock", true);
            Block = true;
            rb.velocity = Vector2.zero;
        }
        else if (Input.GetMouseButtonUp(1))
        {           
            animator.SetBool("IdleBlock", false);
            Block = false;
        }
    }

    public void HandleHurt()
    {
        animator.SetTrigger("Hurt");
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

    public void DamageToHeroTreatment(float Damage)
    {
        HandleHurt();
        GetComponent<Health>().TakeDamage(Damage);
        img.fillAmount = gameObject.GetComponent<Health>().currentHealth / 100;
    }

    public void StopForCutScene()
    {
        rb.velocity = Vector2.zero;
        animator.SetInteger("AnimState", 0);
        playerControl = false;
    }
}
