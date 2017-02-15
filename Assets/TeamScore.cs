using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamScore : MonoBehaviour 
{
	public Text redScoreText;
	public Text blueScoreText;

	public GameObject Orb;

	private int redCount;
	private int blueCount;

	// Use this for initialization
	void Start () 
	{
		redCount = 0;
		SetRedScoreText();
		blueCount = 0;
		SetBlueScoreText();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Red")
		{
			print("Red Scored");
			redCount += 1;
			SetRedScoreText();
			other.GetComponent<OrbCollect>().isCollected = false;
		}
		if(other.gameObject.tag == "Blue")
		{
			print("Blue Scored");
			blueCount += 1;
			SetBlueScoreText();
			other.GetComponent<OrbCollect>().isCollected = false;
		}
	}

	void SetRedScoreText()
	{
		redScoreText.text = "Red Team: " + redCount.ToString ();
//		if(redCount >= 100)
//		{
//			winText.text = "You deciphered the code!";
//		}
	}
	void SetBlueScoreText()
	{
		blueScoreText.text = "Blue Team: " + blueCount.ToString ();
//		if(count >= 100)
//		{
//			winText.text = "You deciphered the code!";
//		}
	}
}
