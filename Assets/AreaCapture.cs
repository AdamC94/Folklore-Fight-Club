using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCapture : MonoBehaviour 
{
	CaptureController capControl; 
	// Use this for initialization
	void Start () 
	{
		capControl = GameObject.Find("CaptureZone").GetComponent<CaptureController>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "GoldTeam")
		{
			capControl.goldTeam = true;
		}
		if(other.gameObject.tag == "SilverTeam")
		{
			capControl.silverTeam = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "GoldTeam")
		{
			capControl.goldTeam = false;
		}
		if(other.gameObject.tag == "SilverTeam")
		{
			capControl.silverTeam = false;
		}
	}
}
