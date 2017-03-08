using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health_Damage : MonoBehaviour 
{
	public Animator animator;

	public string[] animStrings;
	public bool[] publicAnimTrigs;
	static bool[] animTrigs;

	public string attackHitBoxTag;

	public int playerIndex;

	public int[] publicHealth;
	static int[] health;

	public bool[] publicHit;
	static bool[] hit;

	public float[] publicHitCooldown;
	static float[] hitCoolown;
	public float startHitCooldown;

	public int damage;

	public Text text;

	// Use this for initialization
	void Start () 
	{
		health = new int[publicHealth.Length];

		animTrigs = new bool[publicAnimTrigs.Length];

		for(int i = 0; i < health.Length; i ++)
		{
			health[i] = publicHealth[i];
		}

		hitCoolown = new float[publicHitCooldown.Length];

		for(int i = 0; i < hitCoolown.Length; i ++)
		{
			hitCoolown[i] = publicHitCooldown[i];
		}

		hit = new bool[publicHit.Length];

		for(int i = 0; i < hit.Length; i ++)
		{
			hit[i] = publicHit[i];
		}

		hitCoolown[playerIndex] = startHitCooldown;

	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == attackHitBoxTag)
		{
			if(hit[playerIndex] == false)
			{
				animTrigs[playerIndex] = true;

				health[playerIndex] -= damage;

				hit[playerIndex] = true;
			}
		}
	}

	void textUpdate()
	{
		text.text = health[playerIndex].ToString();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		textUpdate();

		publicHealth[playerIndex] = health[playerIndex];

		publicHitCooldown[playerIndex] = hitCoolown[playerIndex];

		publicHit[playerIndex] = hit[playerIndex];

		publicAnimTrigs[playerIndex] = animTrigs[playerIndex];

		if(hit[playerIndex] == true)
		{
			hitCoolown[playerIndex] -= 1 * Time.deltaTime;
		}

		if(hitCoolown[playerIndex] <= 0)
		{
			hit[playerIndex] = false;
			hitCoolown[playerIndex] = startHitCooldown;
			animTrigs[playerIndex] = false;
		}

		if(animTrigs[playerIndex] == true)
		{
			animator.SetBool(animStrings[0], true);
		}

		if(animTrigs[playerIndex] == false)
		{
			animator.SetBool(animStrings[0], false);
		}
	}
}