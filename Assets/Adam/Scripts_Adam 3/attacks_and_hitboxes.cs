using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attacks_and_hitboxes : MonoBehaviour 
{

	Animator animator;

	public KeyCode attack1;
	public KeyCode attack2;

	public string[] animStrings;
	public bool[] trigs;

	public GameObject[] attackHitBoxes;

	public string layerMaskName;

	public bool attacking;
	//public float masterCooldown;

	public float[] attackCooldowns;
	public float[] startAttackCoolDowns;
	public bool[] checkForAttackHits;

	public int attackIndex;

	// each attack has to have its own cool down aswell as

	// Use this for initialization
	void Start () 
	{

		animator = GetComponent<Animator>();

		trigs = new bool[animStrings.Length];

		attackCooldowns = new float[animStrings.Length];

		checkForAttackHits = new bool[animStrings.Length];

		for(int i = 0; i < attackHitBoxes.Length; i ++)
		{
			attackHitBoxes[i].SetActive(false);
		}

	}

	void AttackIndex()
	{
		if(Input.GetKeyDown(attack1) && attacking == false)
		{
			attackIndex = 0;
			attacking = true;
		}

		if(Input.GetKeyDown(attack2) && attacking == false)
		{
			attackIndex = 1;
			attacking = true;
		}
	}

	// Update is called once per frame
	void Update () 
	{

		AttackIndex();

		if(attackCooldowns[attackIndex] <= 0 && attacking == true)
		{
			trigs[attackIndex] = true;

			attackCooldowns[attackIndex] = startAttackCoolDowns[attackIndex];

			checkForAttackHits[attackIndex] = true;

			if(trigs[attackIndex] == true)
			{
				animator.SetBool(animStrings[attackIndex], true);
			}
		}
		else
		{
			animator.SetBool(animStrings[attackIndex], false);
		}

		if(checkForAttackHits[attackIndex] == true)
		{
			attackHitBoxes[attackIndex].SetActive(true);
		}
		if(attacking == true)
		{
			attackCooldowns[attackIndex] -= 1 * Time.deltaTime;

			if(attackCooldowns[attackIndex] <= 0)
			{
				attacking = false;
				attackHitBoxes[attackIndex].SetActive(false);
				checkForAttackHits[attackIndex] = false;
			}
		}
	}
}


