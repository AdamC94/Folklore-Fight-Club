using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class characterSelection : MonoBehaviour 
{
	public int playerNumber;

	public Transform[] images;
	public Transform currentImage;

	public GameObject selection;

	public Image selectionImage;
	public Sprite selectingImg;
	public Sprite lockedSelectionImg;

	public GameObject[] characterList;
	public int index;

	public KeyCode rightToggleButton;
	public KeyCode leftToggleButton;

	public KeyCode confirmedCharacterSelection;
	public bool characterSelected;
	public bool lockSelection;
	public KeyCode unConfirmCharacterSelection;

	public bool inMenu;

	static float joinGameTimer = 30;
	public float joinGameTimerInspect;

	public string scene;

	// Use this for initialization
	void Start () 
	{
		if( inMenu == true)
		{
			selectionImage = selection.GetComponent<Image>();
		}
			
		if(playerNumber == 1)
		{
			index = PlayerPrefs.GetInt("Player1CharacterSelected");
		}
		if(playerNumber == 2)
		{
			index = PlayerPrefs.GetInt("Player2CharacterSelected");
		}
		if(playerNumber == 3)
		{
			index = PlayerPrefs.GetInt("Player3CharacterSelected");
		}
		if(playerNumber == 4)
		{
			index = PlayerPrefs.GetInt("Player4CharacterSelected");
		}

		characterList = new GameObject[transform.childCount];



		for(int i = 0; i < transform.childCount; i++)
		{
			characterList[i] = transform.GetChild(i).gameObject;
		}

		foreach(GameObject character in characterList)
		{
			character.SetActive(false);
		}

		if(characterList[index])
		{
			characterList[index].SetActive(true);
		}
	}

	void RightToggle()
	{
		if(Input.GetKeyDown(rightToggleButton) && lockSelection == false)
		{
			characterList[index].SetActive(false);

			index += 1;

			if(index > characterList.Length - 1)
			{
				index = 0;
			}

			characterList[index].SetActive(true);
		}
	}

	void LeftToggle()
	{
		if(Input.GetKeyDown(leftToggleButton) && lockSelection == false)
		{
			characterList[index].SetActive(false);

			index -= 1;

			if(index < 0)
			{
				index = characterList.Length - 1;
			}

			characterList[index].SetActive(true);
		}
	}

	void confirmSelection()
	{
		if(Input.GetKey(confirmedCharacterSelection) && inMenu == true)
		{
			if(playerNumber == 1)
			{
				lockSelection = true;
				selectionImage.sprite = lockedSelectionImg;
				PlayerPrefs.SetInt("Player1CharacterSelected", index);
			}

			if(playerNumber == 2)
			{
				lockSelection = true;
				selectionImage.sprite = lockedSelectionImg;
				PlayerPrefs.SetInt("Player2CharacterSelected", index);
			}

			if(playerNumber == 3)
			{
				lockSelection = true;
				selectionImage.sprite = lockedSelectionImg;
				PlayerPrefs.SetInt("Player3CharacterSelected", index);
			}

			if(playerNumber == 4)
			{
				lockSelection = true;
				selectionImage.sprite = lockedSelectionImg;
				PlayerPrefs.SetInt("Player4CharacterSelected", index);
			}
		}
	}

	void unConfirmSelection()
	{
		if(Input.GetKey(unConfirmCharacterSelection) && lockSelection == true)
		{
			lockSelection = false;
			selectionImage.sprite = selectingImg;
		}
	}

		
	// Update is called once per frame
	void FixedUpdate () 
	{
		RightToggle();
		LeftToggle();
		confirmSelection();
		unConfirmSelection();

		if(Input.GetKey(KeyCode.Z))
		{
			SceneManager.LoadScene(scene);
		}
		if(inMenu == true)
		{
			currentImage = images[index];
			selection.transform.position = new Vector3(currentImage.transform.position.x, currentImage.transform.position.y, currentImage.transform.position.z);
		}
	}
}
