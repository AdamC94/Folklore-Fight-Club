using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour 
{
	public int playerNumber;

	public Animator anim;

	public Rigidbody myRB;

	public string[] animStrings;
	public bool[] trigs;
	public KeyCode[] buttons;

	public KeyCode jumpButton;
	public float jumpForce;

	public string horizontalAxis;
	public float movementSpeed;

	public bool grounded;

	// Use this for initialization
	void Start () 
	{
		anim = this.GetComponent<Animator>();
		myRB = this.GetComponent<Rigidbody>();

		trigs = new bool[animStrings.Length];
	}


	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Ground")
		{
			grounded = true;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < animStrings.Length; i ++)
		{
			trigs[i] = Input.GetKey(key:(buttons[i]));

			if (trigs[i])
			{
				anim.SetBool (animStrings[i], true);
			} 
			else 
			{
				anim.SetBool (animStrings[i], false);
			}
		}


		//moving right
		if(Input.GetAxis(horizontalAxis) > 0)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward);
			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
			anim.SetBool(animStrings[1], true);
		}

		//moving left
		if(Input.GetAxis(horizontalAxis) < 0)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.back);

			transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

			anim.SetBool(animStrings[1], true);
		}

		if(Input.GetKeyDown(jumpButton) && grounded == true)
		{
			myRB.AddForce(transform.up * jumpForce);
			anim.SetBool(animStrings[2], true);
			grounded = false;
		}
	}
}
