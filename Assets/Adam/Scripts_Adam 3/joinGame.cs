using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joinGame : MonoBehaviour 
{

	public int controllerNumber;

	static bool controller1Joined;
	static bool controller2Joined;
	static bool controller3Joined;
	static bool controller4Joined;
	public bool controller1JoinedInspect;
	public bool controller2JoinedInspect;
	public bool controller3JoinedInspect;
	public bool controller4JoinedInspect;

	static bool allControllerJoined;
	public bool allControllerJoinedInspect;

	public KeyCode joinButton;

	public GameObject characterSelectionUI;
	public GameObject characterSelection;

	public GameObject joinGameSign;

	// Use this for initialization
	void Start () 
	{
		characterSelection.SetActive(false);
		characterSelectionUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		controller1JoinedInspect = controller1Joined;
		controller2JoinedInspect = controller2Joined;
		controller3JoinedInspect = controller3Joined;
		controller4JoinedInspect = controller4Joined;

		allControllerJoinedInspect = allControllerJoined;

		if(Input.GetKey(joinButton))
		{
			if(controllerNumber == 1)
			{
				controller1Joined = true;
				joinGameSign.SetActive(false);
				characterSelection.SetActive(true);
				characterSelectionUI.SetActive(true);
			}
			if(controllerNumber == 2)
			{
				controller2Joined = true;
				joinGameSign.SetActive(false);
				characterSelection.SetActive(true);
				characterSelectionUI.SetActive(true);
			}
			if(controllerNumber == 3)
			{
				controller3Joined = true;
				joinGameSign.SetActive(false);
				characterSelection.SetActive(true);
				characterSelectionUI.SetActive(true);
			}
			if(controllerNumber == 4)
			{
				controller4Joined = true;
				joinGameSign.SetActive(false);
				characterSelection.SetActive(true);
				characterSelectionUI.SetActive(true);
			}
		}

		if( controller1Joined == true && controller2Joined == true && controller3Joined == true && controller4Joined == true)
		{
			allControllerJoined = true;
		}
	}
}
