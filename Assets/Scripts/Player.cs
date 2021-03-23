using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    [SerializeField] private float movementSpeed;

    private bool facingRight;

    private Animator myAnimator;

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
    }

    public void HandleMovement(float horizontal)
    {
        if(!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        
        if (slide == true && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            myAnimator.SetBool("slide", true);
        
        else if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
            myAnimator.SetBool("slide", false);

        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

    }

    void HandleAttacks()
    {
        if(attack == true)
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
        {
            //Debug.Log("lshift pressed");
            slide = true;
        }
    }

    private void Flip(float horizontal)
    {
        if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide") && (facingRight == true && horizontal < 0
            || facingRight == false && horizontal > 0))
        {
            //myAnimator.SetBool("slide", false);
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;  
        }
    }

    private void ResetValues()
    {
        attack = false;
        slide = false;
    }
    /*Update runs once per frame, fixed update runs as many times per frame as you want
     * fixed update works with the physics engine, so while using a rigidbody, you should use fixed
     */
}
