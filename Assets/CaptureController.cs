using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureController : MonoBehaviour 
{
	public bool goldTeam = false;
	public bool silverTeam = false;

	private float goldCapPerc = 0;
	private float silverCapPerc = 0;
	public float capSpeed = 2.0f;

	//AREA SHOWN
	public GameObject gold;
	public GameObject silver;
	public GameObject Neutral;


	// Use this for initialization
	void Start () 
	{
		gold.SetActive(false);
		silver.SetActive(false);
		Neutral.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(goldTeam == true)
		{
			goldCapPerc += Time.deltaTime * capSpeed;
			silverCapPerc -= Time.deltaTime * capSpeed;
		}
		if(silverTeam == true)
		{
			goldCapPerc -= Time.deltaTime * capSpeed;
			silverCapPerc += Time.deltaTime * capSpeed;
		}
		if(goldTeam == true && silverTeam == true)
		{
			goldCapPerc = goldCapPerc;
			silverCapPerc = silverCapPerc;
		}
		if(goldCapPerc >= 100)
		{
			goldCapPerc = 100;
			gold.SetActive(true);
			silver.SetActive(false);
			Neutral.SetActive(false);
		}
		if(silverCapPerc >= 100)
		{
			silverCapPerc = 100;
			gold.SetActive(false);
			silver.SetActive(true);
			Neutral.SetActive(false);
		}
		if(goldCapPerc <= 50 && silverCapPerc <= 51)
		{
			gold.SetActive(false);
			silver.SetActive(false);
			Neutral.SetActive(true);
		}
		if(goldCapPerc <= 0)
		{
			goldCapPerc = 0;
		}
		if(silverCapPerc <= 0)
		{
			silverCapPerc = 0;
		}
	}
//	void OnGUI()
//	{
//		GUI.Box(Rect(10, 10, 300, 25), "Gold Cap" + " " + goldCapPerc.ToString(" ") + " " + "Silver Cap" + " " + silverCapPerc.ToString(" "));
//	}
}

