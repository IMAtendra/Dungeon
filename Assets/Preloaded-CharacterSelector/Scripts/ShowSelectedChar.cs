using UnityEngine;


public class ShowSelectedChar : MonoBehaviour
{
	public GameObject[] charPrefabs;
	private GameObject prefab, clone;
	public Transform spawnHere;

	// To Load All Characters in GameObject Array
	void Awake() => charPrefabs = Resources.LoadAll<GameObject>(path: "Characters");

	void Start()
	{
		// To Get number of your Characters
		int index = PlayerPrefs.GetInt("SelectedCharacters");
		// Load Index Character Number in prefab
		prefab = charPrefabs[index];
		// Get the transform of the camera
		// prefab.transform.SetParent(spawnHere);
		// Now we create clone of your Selected Character
		clone = (GameObject)Instantiate(prefab, transform.position, Quaternion.identity);
	}
}
