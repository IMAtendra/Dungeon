using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneActiveObjectChecker : MonoBehaviour
{
    // public TMP_Text statusText;

    private void Start()
    {
        // statusText = GameObject.Find("StatusText").GetComponent<TMP_Text>();
        // CheckActivePickupObjects();
    }
    public void CheckActivePickupObjects()
    {
        var foundObjects = Object.FindObjectsOfType<Collectibles>();
        int count = foundObjects.Length;
        // Debug.Log($"Now You have to Collect {count} Coin");


        if (count == 0)
        {
            // Debug.LogWarning("Yeah! You Have Collected All Collectibles");
            // statusText.text = "Good Job !!!";
            // FindAnyObjectByType<StatusText>().StatusTextDisplay(StringHandler.Text_Win);
        }
        // else
            // statusText.text = "";
            // FindAnyObjectByType<StatusText>().StatusTextDisplay("");


    }

    // void LateUpdate() => CheckActivePickupObjects();
}
