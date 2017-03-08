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

	public Collider[] attackHitBoxes;

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

	bool hit;

	void attack(Collider col)
	{
		hit = false;
		Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask(layerMaskName));
		foreach(Collider c in cols)
		{
			if(hit == false)
			{
				Debug.Log(c.name);
				checkForAttackHits[attackIndex] = false;
				hit = true;
			}
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
			attack(attackHitBoxes[attackIndex]);
		}
		if(attacking == true)
		{
			attackCooldowns[attackIndex] -= 1 * Time.deltaTime;

			if(attackCooldowns[attackIndex] <= 0)
			{
				attacking = false;
				checkForAttackHits[attackIndex] = false;
			}
		}
	}
}


