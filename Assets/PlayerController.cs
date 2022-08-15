using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	public CharacterController controller;
	[SerializeField] public Animator animator;

	public AudioClip aJump;
	AudioSource audioSource;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	//bool crouch = false;

    private void Start()
    {
		audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetBool("isWalking", Convert.ToBoolean(Input.GetAxisRaw("Horizontal")));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("isJumping", true);
			audioSource.PlayOneShot(aJump, 0.5f);
		}

		//if (Input.GetButtonDown("Crouch"))
		//{
		//	crouch = true;
		//} else if (Input.GetButtonUp("Crouch"))
		//{
		//	crouch = false;
		//}

	}

	public void OnLanding ()
	{
		animator.SetBool("isJumping", false);
	}

	public void OnCrouching (bool isCrouching)
	{
		//animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, /*crouch,*/ jump);
		jump = false;
	}
}