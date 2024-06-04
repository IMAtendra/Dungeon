using UnityEngine;
using UnityEngine.UI;

public class SetUIText : MonoBehaviour
{
    public Text textRef;
    private object Speed;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        textRef = GetComponent <Text> ();
        textRef.text = "Speed " + Speed.ToString() + " km/h";
        // textRef.text = Speed.ToString("#.00");
        // textRef.text = string.Format("{0} km/h", Speed);
        // textRef.text = string.Format("{0:#.00} km/h", Speed);
        // textRef.text = "Speed " + Speed.ToString() + " km/h";
    }

}