﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamScoreSilver : MonoBehaviour 
{
	public Text silverScoreText;

	public Text winText;

	public GameObject Orb;

	public int silverCount;


	// Use this for initialization
	void Start () 
	{
		silverCount = 0;
		SetSilverScoreText();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		silverScoreText.text = silverCount.ToString();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Silver")
		{
			print("Silver Scored");
			silverCount += 1;
			print(silverCount);
			SetSilverScoreText();

		}
	}

	void SetSilverScoreText()
	{
		silverScoreText.text = "Silver Team: " + silverCount.ToString ();
		if(silverCount >= 5)
		{
			winText.text = "Silver Team Win";
		}
	}
}