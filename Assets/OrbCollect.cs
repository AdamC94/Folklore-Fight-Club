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

	void Update()
	{
		player = currentPlayer.transform;
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(isCollected == true)
		{
			
		//transform.rotation = Quaternion.Slerp(fromThis.rotation, toThis.rotation, Time.deltaTime * rotSpeed); 
			transform.position = Vector3.MoveTowards(transform.position , player.position , Time.fixedDeltaTime * speed);
		}
		else {
			//transform.position = resetPoint.position;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "GoldTeam" && !isCollected) 
		{
			
			print("Gold picked up");
			isCollected = true;
			this.tag = "Gold";
			//player.position = other.gameObject.transform.position;
			currentPlayer = other.gameObject;
		}
		if(other.gameObject.tag == "GoldScore")
		{
			print("Gold scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
			//player = null;
		}
		if(other.gameObject.tag == "SilverTeam" && !isCollected) 
		{
			
			print("Silver picked up");
			isCollected = true;
			this.tag = "Silver";
			//player.position = other.gameObject.transform.position;
			currentPlayer = other.gameObject;
		}
		if(other.gameObject.tag == "SilverScore")
		{
			print("Silver scored");
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
			//player = null;
		}
	}
}

