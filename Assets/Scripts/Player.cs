using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField] private float movementSpeed;

    private bool facingRight;

    private Animator myAnimator;
    [SerializeField] private Transform[] groundPoints;
    [SerializeField] private float groundRadius;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool airControl;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool jump;

    private bool attack;
    private bool slide;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;

        myAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        ResetValues();
        isGrounded = IsGrounded();
    }

    public void HandleMovement(float horizontal)
    {
        if (!myAnimator.GetBool("slide") &&
            !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);

        if (slide == true && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            myAnimator.SetBool("slide", true);

        else if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            myAnimator.SetBool("slide", false);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

        if (jump == true && isGrounded == true)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));

        }


    }

    void HandleAttacks()
    {
        if (attack == true)
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            attack = true;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            slide = true;


        if (Input.GetKeyDown(KeyCode.UpArrow))
            jump = true;

    }

    private void Flip(float horizontal)
    {
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")
            && (facingRight == true && horizontal < 0
            || facingRight == false && horizontal > 0))
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders =
                    Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void ResetValues()
    {
        attack = false;
        slide = false;
        jump = false;
    }

}
