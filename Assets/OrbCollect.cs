using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollect : MonoBehaviour 
{
	public Transform player;
	Transform fromThis;
	public Transform resetPoint;
	public float speed;
	public float rotSpeed = 0.1f;
	public bool isCollected = false;

	public GameObject currentPlayer;

	TeamScoreGold goldScore;

	public string hitTag;
	public string hitTag1;
	void Update()
	{
		player = currentPlayer.transform;
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(isCollected == true)
		{
			transform.position = Vector3.MoveTowards(transform.position , player.position , Time.fixedDeltaTime * speed);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "GoldTeam" && !isCollected) 
		{
			print("Gold picked up");
			isCollected = true;
			this.tag = "Gold";
			currentPlayer = other.gameObject;
		
		}
		if(other.gameObject.tag == "GoldScore")
		{
			//print("Gold scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
		if(other.gameObject.tag == "SilverTeam" && !isCollected) 
		{
			print("Silver picked up");
			isCollected = true;
			this.tag = "Silver";

			currentPlayer = other.gameObject;
		}
		if(other.gameObject.tag == "SilverScore")
		{
			print("Silver scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
		if(other.gameObject.tag == hitTag)
		{
			//print("Silver scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
		if(other.gameObject.tag == hitTag1)
		{
			//print("Silver scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
	}
}

