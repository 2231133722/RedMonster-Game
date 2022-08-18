using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    [SerializeField] public Animator animator;

    public AudioClip aJump;
    AudioSource audioSource;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    //bool crouch = false;

    private Rigidbody2D rb;
    public float dashspeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    private bool isDashing;
    private int counterDash;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        isDashing = false;
        counterDash = 0;
    }
    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetBool("isWalking", Convert.ToBoolean(Input.GetAxisRaw("Horizontal")));

        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            audioSource.PlayOneShot(aJump, 0.5f);
        }

        //Dash
        if (Input.GetButtonDown("Fire3"))
        {
            isDashing = true;
            counterDash++;
            //direction = 1;

        }
        //else if (Input.GetButtonDown("Fire2"))
        //{
        //	isDashing = true;
        //	counterDash++;
        //	direction = 2;

        //}
        else
        {
            if (dashTime < -0)
            {
                dashTime = startDashTime;
                isDashing = false;
            }
            else if (isDashing == true && counterDash < 2)
            {
                dashTime -= Time.deltaTime;
                //if (direction != 0)
                //{
                //	if (direction == 1)
                //	{
                rb.velocity = new Vector2(dashspeed * horizontalMove, rb.velocity.y);
                //}
                //if (direction == 2)
                //{
                //	rb.velocity = Vector2.right * dashspeed;
                //}
                //}

            }
        }

        //if (Input.GetButtonDown("Crouch"))
        //{
        //	crouch = true;
        //} else if (Input.GetButtonUp("Crouch"))
        //{
        //	crouch = false;
        //}

    }

    public void OnLanding()
    {
        isDashing = false;
        counterDash = 0;
        jump = false;
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        //animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, /*crouch,*/ jump);
    }
}