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

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        facingRight = true;

        myAnimator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleInput();
        HandleAttacks();
        ResetValues();
    }

    public void HandleMovement(float horizontal)
    {
        if(!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag("Attack"))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
            

        }

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
    }

    private void Flip(float horizontal)
    {
        if(facingRight == true && horizontal < 0)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if(facingRight == false && horizontal > 0)
        {
            facingRight = !facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValues()
    {
        attack = false;
    }
    /*Update runs once per frame, fixed update runs as many times per frame as you want
     * fixed update works with the physics engine, so while using a rigidbody, you should use fixed
     */
}
