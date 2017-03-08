using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCharacterController : MonoBehaviour 
{

	Animator animator;
	public string animatorBlendFloat ;

	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float gravity = -12;
	public float jumpHeight = 1;

	public KeyCode jumpButton;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	public string horizontal;
	public string vertical;

	CharacterController controller;

	public string[] animStrings;
	public bool[] trigs;

	// Use this for initialization
	void Start () 
	{
		animator = this.gameObject.GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

		trigs = new bool[animStrings.Length];
	}

	void Jump()
	{
		if(controller.isGrounded)
		{
			float jumpVelocity = Mathf.Sqrt ( -2 *gravity * jumpHeight);
			velocityY = jumpVelocity;

			trigs[0] = true;
			if(trigs[0] == true)
			{
				animator.SetBool(animStrings[0], true);
			}
		}
		else
		{
			animator.SetBool(animStrings[0], false);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		Vector2 input = new Vector2(Input.GetAxisRaw(horizontal), 0 /*Input.GetAxisRaw(vertical)*/);
		Vector2 inputDirection = input.normalized;

		if(Input.GetKeyDown(jumpButton))
		{
			Jump();
		}
		else
		{
			animator.SetBool(animStrings[0], false);
		}

		if(inputDirection != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2 (inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
			trigs[1] = true;
			if(trigs[1] == true)
			{
				animator.SetBool(animStrings[1], true);
			}
		}
		else
		{
			animator.SetBool(animStrings[1], false);
		}

		bool running = Input.GetKey(KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDirection.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		velocityY += Time.deltaTime * gravity;
		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);

		if(controller.isGrounded)
		{
			velocityY = 0;
		}

		//float animationSpeedPercent = ((running) ? 1 : 0.5f) * inputDirection.magnitude;
		//animator.SetFloat(animatorBlendFloat, animationSpeedPercent, speedSmoothTime, Time.deltaTime);
	}
}
