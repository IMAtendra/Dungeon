using UnityEngine;
using UnityEngine.SceneManagement;

/*-------------------------------------------------------
 * Owner 		- IMAtendra
 * Project 		- Character Selector
 * Filename 	- CharacterSelector
 * Note 		- This is 'No Copyright Code' cause I'm Owner of this Code.
 *-------------------------------------------------------*/

public class CharacterSelector : MonoBehaviour 
{
	public GameObject[] charsPrefab;
	public int selectedCharater = 0;

	// To Load All Characters in GameObject Array
	void Awake() => charsPrefab = Resources.LoadAll<GameObject>(path: "SelectionCharacters");

	// First Time To Load a Character only Once
	void Start() => PreviewCharacter();

	void PreviewCharacter()
	{
		// To Get index of Character
		int index = selectedCharater;
		// To Target of Parent Object
		Transform temp  = gameObject.transform;
		// Now we create a clone of your Selected Character
		GameObject clone = Instantiate(charsPrefab[index], transform.position, Quaternion.identity);
		// To set your spawn Clone  on parent Object
		clone.transform.SetParent(temp);
	}

	void DeletAll() 
	{
		// Delete All Childs of Parent Object
		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--)
		{
			GameObject.Destroy(transform.GetChild(i).gameObject);
		}
	}

	public void NextCharacter()
	{
		DeletAll();
		selectedCharater = (selectedCharater + 1) % charsPrefab.Length;
		PreviewCharacter();
	}

	public void PreviousCharacter()
	{
		DeletAll();
		selectedCharater--;
		if(selectedCharater < 0) selectedCharater += charsPrefab.Length;
		PreviewCharacter();
	}

	public void StartGame()
	{
		// To Set number of your Characters
		PlayerPrefs.SetInt("SelectedCharacters", selectedCharater);
		// To Load Preview GameScene
		SceneManager.LoadScene("GameMode");
	}

	void OnGUI() 
	{
		// Positions for Buttons
		float HalfScreen_W = Screen.width/2;
		float HalfScreen_H = Screen.height/2;

		// Size for Buttons
		float Btn_Width = 100f;
		float Btn_Height = Btn_Width/2;

		// Create String for Label
		string labelChar = charsPrefab[selectedCharater].name;
		// Now we create a Label to Show Character Name
		GUI.Label(new Rect(HalfScreen_W - 30, 100, Btn_Width, Btn_Height), labelChar);

		// Now we create a button to Delete All Character On Scene
		// if (GUI.Button(new Rect((HalfScreen_W - 50), (Screen.height - 200), Btn_Width, Btn_Height), "Delete")) DeletAll();

		// Now we create a button to choose a Selected char
		if (GUI.Button(new Rect((HalfScreen_W - 50), (Screen.height - 100), Btn_Width, Btn_Height), "Select")) StartGame();

		// Now we create a button to choose a previous char
		if (GUI.Button(new Rect((Screen.width - 220), (HalfScreen_H), Btn_Width, Btn_Height), "Next")) NextCharacter();
		
		// Here we create a button to choose a next char
		if (GUI.Button(new Rect((100), (HalfScreen_H), Btn_Width, Btn_Height), "Previous")) PreviousCharacter();
		
	}
	
}