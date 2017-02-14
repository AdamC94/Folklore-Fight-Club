using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerTest : MonoBehaviour 
{
	/*static string[] controllers;
	public string[] controllersInspect;
	public bool joined;

	public string controller1;
	public string controller2;
	public string controller3;
	public string controller4;*/

	public Input jump;

	public int padNumber; //--------------------------------------------------------------------------------public int variable that indicates the number of the controller
	private string padNumberString; //----------------------------------------------------------------------private number string used for converting the ^int to a string

	public bool AnalogStick; //-----------------------------------------------------------------------------public bool allows to indicate whether the object is a analog stick
	public string AnalogVerticalAxis; //--------------------------------------------------------------------public string for indicating the name of the vertical axis
	public string AnalogHorizontalAxis; //------------------------------------------------------------------public string for indicating the name of the horizontal axis

	private Vector3 startPos; //----------------------------------------------------------------------------private vector3 for storing the objects start position

	public KeyCode button; //-------------------------------------------------------------------------------public keycode for selecting the input button for the object

	// Use this for initialization
	void Start () 
	{
		startPos = this.transform.position; //--------------------------------------------------------------sets the vector3 start position to the starting position of the gameObject the script is attached to once the game starts

		padNumberString = padNumber.ToString(); //----------------------------------------------------------sets the pad number string to the pad number once converted to a string once the game starts

		/*for(int i = 0; i < controllers.Length; i ++)
		{

			controllers = Input.GetJoystickNames();

			controllersInspect = controllers;

			Debug.Log(controllers[i] + i);
		}*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.GetComponent<Renderer>().enabled = true; //------------------------------------------accesses the renderer of the gameObject that the script is attached to sets the renderer to true every frame
		if(Input.GetKey(button)) //--------------------------------------------------------------------------if the input button public variable is pressed then it runs the following
		{
			this.gameObject.GetComponent<Renderer>().enabled = false; //-------------------------------------When the button is pressed accesses the renderer component of the gameObject and turns the renderer off while the button is pressed
			Debug.Log(button);
		}

		if(AnalogStick == true) //---------------------------------------------------------------------------if the analog stick boolean is set to true it runs the following
		{
			Vector3 inputDirection = Vector3.zero; //--------------------------------------------------------Creates a new Vector3 and sets it to equal to zero
			//inputDirection.x = Input.GetAxis("Pad" + padNumberString + "_" + AnalogHorizontalAxis); //-------sets the inputDirection X axis to equal the input axis of "Pad" plus the pad number string that was converted from the pad number + "_" and the name of the analog horizontal axis to asign the input in the input manager
			//inputDirection.z = Input.GetAxis("Pad" + padNumberString + "_" + AnalogVerticalAxis); //---------sets the inputDirection Y axis to equal the input axis of "Pad" plus the pad number string that was converted from the pad number + "_" and the name of the analog vertical axis to asign the input in the input manager
			inputDirection.x = Input.GetAxis(AnalogHorizontalAxis); //-------sets the inputDirection X axis to equal the input axis of "Pad" plus the pad number string that was converted from the pad number + "_" and the name of the analog horizontal axis to asign the input in the input manager
			inputDirection.z = Input.GetAxis(AnalogVerticalAxis); //---------sets the inputDirection Y axis to equal the input axis of "Pad" plus the pad number string that was converted from the pad number + "_" and the name of the analog vertical axis to asign the input in the input manager
			this.transform.position = startPos + inputDirection; //------------------------------------------sets the position of the gameObject to the start position Vector and adding the input direction to its original position.
		}
	}
}
