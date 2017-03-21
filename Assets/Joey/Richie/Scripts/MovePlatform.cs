using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour 
{
	public Transform farEnd; 
	private Vector3 from;
	private Vector3 to;
	private float secondsForOneLength = 2f;
	public bool isPressed = false;

	void Start()
	{
			from = transform.position;
			to = farEnd.position;
	}

	void Update()
	{
		if(isPressed)
		{
		transform.position = Vector3.Lerp(from, to, Mathf.SmoothStep(0f,1f, Mathf.PingPong(Time.time/secondsForOneLength, 1f)));
		}
	}
}
