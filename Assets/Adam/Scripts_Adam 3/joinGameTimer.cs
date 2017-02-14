using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class joinGameTimer : MonoBehaviour 
{

	public Text timerText;
	public float time;

	public string scene;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	// Use this for initialization
	void Start () 
	{
		timerText.gameObject.SetActive(false);
	}

	void text()
	{
		timerText.text = time.ToString("0");
	}

	// Update is called once per frame
	void Update () 
	{
		text();

		if(player1.activeSelf == true && player2.activeSelf == true && player3.activeSelf == true && player4.activeSelf == true)
		{
			timerText.gameObject.SetActive(true);
			time -= 1 * Time.deltaTime;
		}

		if(time <= 0)
		{
			SceneManager.LoadScene(scene);
		}
	}
}
