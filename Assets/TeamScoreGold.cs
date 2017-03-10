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

	public GameObject []Goldpaper;
	public GameObject []Silverpaper;


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
		//goldScoreText.text = "Gold: " + goldCount.ToString ();
		if(goldCount == 1)
		{
			Goldpaper[0].SetActive(true);
		}
		if(goldCount == 2)
		{
			Goldpaper[1].SetActive(true);
		}
		if(goldCount == 3)
		{
			Goldpaper[2].SetActive(true);
		}
		if(goldCount == 4)
		{
			Goldpaper[3].SetActive(true);
		}
		if(goldCount >= 5)
		{
			Goldpaper[4].SetActive(true);
			winText.text = "Gold Team Win";
		}
	}
	void SetSilverScoreText()
	{
		//silverScoreText.text = "Silver: " + silverCount.ToString ();
		if(silverCount == 1)
		{
			Silverpaper[0].SetActive(true);
		}
		if(silverCount == 2)
		{
			Silverpaper[1].SetActive(true);
		}
		if(silverCount == 3)
		{
			Silverpaper[2].SetActive(true);
		}
		if(silverCount == 4)
		{
			Silverpaper[3].SetActive(true);
		}
		if(silverCount >= 5)
		{
			Silverpaper[4].SetActive(true);
			winText.text = "Silver Team Win";
		}
	}
}
