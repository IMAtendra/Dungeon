using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterLoader : MonoBehaviour
{
	public GameObject[] charsPrefab;
	public int selectedCharater = 0;

	public TMP_Text charLabel;
	public Button previousBtn, nextBtn, selectBtn, backtoMenuBtn;

	// To Load All Characters in GameObject Array
	void Awake() => Init();

	// First Time To Load a Character only Once
	// void Start() => PreviewCharacter();

	void Init()
	{
		charsPrefab = Resources.LoadAll<GameObject>(path: "SelectionCharacters");
		if (charLabel == null) charLabel = GameObject.Find(StringHandler.Text_CharacterName).GetComponent<TMP_Text>();
		if (previousBtn == null) previousBtn = GameObject.Find(StringHandler.Btn_Previous).GetComponent<Button>();
		if (nextBtn == null) nextBtn = GameObject.Find(StringHandler.Btn_Next).GetComponent<Button>();
		if (selectBtn == null) selectBtn = GameObject.Find(StringHandler.Btn_Select).GetComponent<Button>();
		if (backtoMenuBtn == null) backtoMenuBtn = GameObject.Find(StringHandler.Btn_Back).GetComponent<Button>();

		// Implement Button Onclick
		previousBtn.onClick.AddListener(PreviousCharacter);
		nextBtn.onClick.AddListener(NextCharacter);
		selectBtn.onClick.AddListener(StartGame);
		backtoMenuBtn.onClick.AddListener(BackToMenu);

	}

	public void PreviewCharacter()
	{
		// To Get index of Character
		int index = selectedCharater;
		// To Target of Parent Object
		Transform temp = gameObject.transform;
		// Now we create a clone of your Selected Character
		GameObject clone = Instantiate(charsPrefab[index], transform.position, Quaternion.identity);
		// To set your spawn Clone  on parent Object
		clone.transform.SetParent(temp);

		// Get and Set Chracter Name
		charLabel.text = charsPrefab[selectedCharater].name;
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
		if (selectedCharater < 0) selectedCharater += charsPrefab.Length;
		PreviewCharacter();
	}

	public void StartGame()
	{
		// To Set number of your Characters
		PlayerPrefs.SetInt("SelectedCharacters", selectedCharater);

		FindAnyObjectByType<GameController>().PlayGame();

	}

	public void Choose()
	{
		// To Set number of your Characters
		PlayerPrefs.SetInt("SelectedCharacters", selectedCharater);
	}
	
	private void BackToMenu()
	{
		DeletAll();
		FindAnyObjectByType<CanvasManager>().SwitchCanvas(CanvasType.MainMenu);
	}

}