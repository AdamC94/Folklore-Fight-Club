using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LepControl : MonoBehaviour {
	
	Animator anim; // Leprechaun Animator

	public bool[] trigs; // Keyboard Input Bools
	public string[] animStrings; // Leprechaun Animator bools stored in Strings for use in for loop.

	void Start () {
		anim = GetComponent<Animator> (); //Leprechaun Animator Component
	}
	

	void Update () {
		for( int i = 0; i < animStrings.Length; i++)
		{ 
			
		// Keyboard Input Bools assigned to keypad 0-9
		trigs[0] = Input.GetKey(KeyCode.Keypad0);
		trigs[1] = Input.GetKey(KeyCode.Keypad1);
		trigs[2] = Input.GetKey(KeyCode.Keypad2);
		trigs[3] = Input.GetKey(KeyCode.Keypad3);
		trigs[4] = Input.GetKey(KeyCode.Keypad4);
		trigs[5] = Input.GetKey(KeyCode.Keypad5);
		trigs[6] = Input.GetKey(KeyCode.Keypad6);
		trigs[7] = Input.GetKey(KeyCode.Keypad7);
		trigs[8] = Input.GetKey(KeyCode.Keypad8);
		trigs[9] = Input.GetKey(KeyCode.Keypad9);

		if (trigs[i]){
			anim.SetBool (animStrings[i], true); // if key is pressed animator bool is on
		} else {
				anim.SetBool (animStrings[i], false); //if not pressed, animator bool is off
		}


	}
}
}

