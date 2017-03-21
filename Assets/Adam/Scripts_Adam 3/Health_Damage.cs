using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health_Damage : MonoBehaviour 
{
	public int health; //----------------------------------------playerHealth
	private int maxHealth; //------------------------------------players Health for reset whe the player re spawns

	public int damage; //----------------------------------------amount of damage done to the player when they are hit

	public string hitBoxTag; //----------------------------------The tag of the enemy attack hit box

	public Text healthText; //-----------------------------------public text to display health value

	public bool gold; //-----------------------------------------public gold bool for indicating that player is on the gold team, silver bool must be false if this is true
	public bool silver; //---------------------------------------public silver bool for indicating that player is on the silver team, gold bool must be false if this is true

	static int silverLivePool = 5; //----------------------------collective silver team live count
	public int publicSilverLivePool; //--------------------------public variable to show static silver team live count in the inspector
	public Text silverPoolText; //-------------------------------public text to display the collective silver team lives

	static int goldLivePool = 5; //------------------------------collective gold team live count
	public int publicGoldLivePool; //----------------------------public variable to show static gold team live count in the inspector
	public Text goldPoolText; //---------------------------------public text to display the collective gold team lives

	Animator anim; //--------------------------------------------the animator

	public string[] animStrings; //------------------------------animation strings in animator
	public bool[] animTrigs; //----------------------------------animation triggers to trigger the animations in the animator

	public bool dead; //-----------------------------------------shows whether the player is dead or not
	public string teamTag;
	public float reSpawnTime; //---------------------------------re spawn timer
	private float startRespawn; //-------------------------------players respawn time for resetting the re spawn time

	// Use this for initialization
	void Start ()
	{
		maxHealth = health; //-----------------------------------sets the max health variable to equal the health for resetting

		animTrigs = new bool[animStrings.Length]; //-------------sets the animTrigs bool array length to equal the the length of the animStrings array

		anim = this.gameObject.GetComponent<Animator>(); //------the the animator variable to the animator of the object that the script is attached to

		startRespawn = reSpawnTime; //---------------------------sets the start respawn time to equal the re spawn time for resetting
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == hitBoxTag && health > 0) //------if the other gameObjects tag is equal to the hitBox tag string and the players health is greater than 0
		{
			health -= damage; //----------------------------------minus the health by the damage

			animTrigs[0] = true; //-------------------------------set the animTrigs bool at index 0 to equal true
		}
	}

	void OnCollisionExit(Collision other)
	{
		if(other.collider.tag == hitBoxTag && health > 0) //------if the other gameObjects tag is equal to the hitbox tag string an dthe players health is greater than 0
		{
			animTrigs[0] = false; //------------------------------sets the animTrigs bool at index 0 to equal false
		}
	}

	void textUpdate() //------------------------------------------text update method
	{
		healthText.text = health.ToString(); //-------------------sets the players health text object to equal the health variable

		goldPoolText.text = goldLivePool.ToString(); //-----------sets the gold live pool text object to equal the gold team live pool
		silverPoolText.text = silverLivePool.ToString(); //------ sets the silver live pool text object to equal the silver team live pool
	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		publicGoldLivePool = goldLivePool; //----------------------sets the public gold live pool variable to equal the goldLive pool to view the static value in the inspector
		publicSilverLivePool = silverLivePool; //------------------sets the public silver live pool variable to equal the silverLive pool to view the static value in the inspector

		textUpdate(); //-------------------------------------------textUpdate method running in update

		if(gold == true) //----------------------------------------if gold bool equals true
		{
			if(health <= 0) //-------------------------------------if the health is less than or equal to 0
			{
				dead = true; //------------------------------------set dead to equal to true
			
				if(dead == true) //--------------------------------if dead bool is equal to true
				{
					anim.SetBool(animStrings[1], true); //---------set the anim animator boolean that is called the string at animStrings index 1 to equal true
					gameObject.tag = "DEATH";

					reSpawnTime -= 1 * Time.deltaTime; //----------reSpawn timer - 1 per second

					if(reSpawnTime <= 0) //------------------------if the reSpawn time is less than or equal to 0
					{
						gameObject.tag = "friendliesGOLD";
						goldLivePool -= 1; //----------------------gold live pool minuses 1

						dead = false; //-------------------------- set dead to equal false
						health = maxHealth; //---------------------health is equal to the max Health
						reSpawnTime = startRespawn; //-------------reSpawn time is equal to the start Respawn
						anim.SetBool(animStrings[1], false); //----set the anim animator boolean that is called the string at animStrings index 1 to equal false
					}
				}
			}
		}

		if(silver == true) //---------------------------------------if silver bool equals true
		{
			if(health <= 0) //--------------------------------------if the health is less than or equal to 0
			{
				dead = true; //-------------------------------------set dead to equal to true

				if(dead == true) //---------------------------------if dead bool is equal to true
				{
					anim.SetBool(animStrings[1], true); //----------set the anim animator boolean that is called the string at animStrings index 1 to equal true
					gameObject.layer = 27;
					reSpawnTime -= 1 * Time.deltaTime; //-----------reSpawn Timer - 1 per second

					if(reSpawnTime <= 0) //-------------------------if reSpawn time is less thn or equal to 0
					{
						gameObject.layer = 26;
						silverLivePool -= 1; //---------------------silver live pool minuses 1
						dead = false; //----------------------------set dead to equal to false
						health = maxHealth; //----------------------health is equal to the max Health
						reSpawnTime = startRespawn; //--------------reSpawn time is equal to the start reSpawn
						anim.SetBool(animStrings[1], false); //-----set the anim animator boolean that is called the string at animStrings index 1 to equal false
					}
				}
			}
		}

		if(animTrigs[0] == true) //----------------------------------if the bool at animTrigs index 0 is true
		{
			anim.SetBool(animStrings[0], true); //-------------------set the anim animator boolean that is called the string at animStrings index 0 to equal true
		}

		else if(animTrigs[0] == false) //----------------------------if the bool at animTrigs index 0 is false
		{
			anim.SetBool(animStrings[0], false); //------------------set the animAnimator boolean that is called the string at animStrings index 0 to equal false
		}
	}
}