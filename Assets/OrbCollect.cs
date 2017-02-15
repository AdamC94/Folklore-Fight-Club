using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollect : MonoBehaviour 
{

	public Transform fromThis;
	public Transform toThis;
	public Transform resetPoint;
	public float speed;
	public float rotSpeed = 0.1f;
	public bool isCollected = false;

	// Use this for initialization
	void Start () 
	{
		toThis = resetPoint;
	}

	// Update is called once per frame
	void Update () 
	{
		//transform.rotation = Quaternion.Slerp(fromThis.rotation, toThis.rotation, Time.deltaTime * rotSpeed); 
		transform.position = Vector3.MoveTowards(fromThis.position , toThis.position , Time.deltaTime * speed);

		if(isCollected == false)
		{
			toThis = resetPoint;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			isCollected = true;
			toThis = other.gameObject.transform;
		}else{
			isCollected = false;

		}
	}
}
