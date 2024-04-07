using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;
    public float TimeToRevert;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sp;
    private const float idleS = 0;
    private const float walkS = 1;
    private const float revertS = 2;
    private float currentState;
    private float currentTimeToRevert;

    void Start()
    {
        currentState = walkS;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = revertS;
        }

        switch (currentState)
        {
            case idleS:
                currentTimeToRevert += Time.deltaTime;
                break;
            case walkS:
                rb.velocity = Vector2.right * Speed;
                break;
            case revertS:
                sp.flipX = !sp.flipX;
                Speed *= -1;
                currentState = walkS;
                break;
        }

        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyStoper"))
            currentState = idleS;
    }
}

