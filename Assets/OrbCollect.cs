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
		
		if(other.gameObject.tag == "RedTeam" && !isCollected) 
		{
			isCollected = true;
			this.tag = "Red";
		}
		if(other.gameObject.tag == "BlueTeam" && !isCollected) 
		{
			isCollected = true;
			this.tag = "Blue";
		}
		if(other.gameObject.tag == "BlueScore")
		{
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
		if(other.gameObject.tag == "RedScore")
		{
			isCollected = false;
			transform.position = resetPoint.position;
			this.tag = "Untagged";
		}
	}
}
