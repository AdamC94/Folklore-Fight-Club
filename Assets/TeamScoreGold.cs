using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamScoreGold : MonoBehaviour 
{
	
	public Text blueScoreText;
	public Text winText;

	public GameObject Orb;


	public int goldCount;

	// Use this for initialization
	void Start () 
	{
		;
		goldCount = 0;
		SetBlueScoreText();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		blueScoreText.text = goldCount.ToString();
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Gold")
		{
			print("Gold Scored");
			goldCount += 1;
			print(goldCount);
			SetBlueScoreText();
		}
			
	}
	void SetBlueScoreText()
	{
		blueScoreText.text = "Gold Team: " + goldCount.ToString ();
		if(goldCount >= 5)
		{
			winText.text = "Gold Team Win";
		}
	}
}
