using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamScoreGold : MonoBehaviour 
{
	public Text goldScoreText;
	public Text silverScoreText;
	public Text winText;

	public GameObject Orb;

	private int goldCount;
	private int silverCount;

	// Use this for initialization
	void Start () 
	{
		
		goldCount = 0;
		SetGoldScoreText();
		silverCount = 0;
		SetSilverScoreText();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Gold")
		{
			print("Gold Scored");
			goldCount += 1;
			SetGoldScoreText();
		}
		if(other.gameObject.tag == "Silver")
		{
			print("Silver Scored");
			silverCount += 1;
			SetSilverScoreText();
		}
			
	}
	void SetGoldScoreText()
	{
		goldScoreText.text = "Gold: " + goldCount.ToString ();
		if(goldCount >= 5)
		{
			winText.text = "Gold Team Win";
		}
	}
	void SetSilverScoreText()
	{
		silverScoreText.text = "Silver: " + silverCount.ToString ();
		if(silverCount >= 5)
		{
			winText.text = "Silver Team Win";
		}
	}
}
