using TMPro;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    // [SerializeField] private TMP_Text statusText;
    public TMP_Text statusText;
    public float transitionTime = 0.25f;


    // private void Start()
    // {
    //     if (statusText == null)
    //     {
    //         statusText = GameObject.Find("DisplayText")
    //                                .GetComponent<TMP_Text>();
    //     }
    //     LeanTween.scale(statusText.gameObject, Vector3.zero, transitionTime);
    // }

    // public void StatusTextDisplay(string displayText)
    // {
    //     if (statusText == null)
    //     {
    //         statusText = GameObject.Find("DisplayText")
    //                                .GetComponent<TMP_Text>();
    //     }

    //     statusText.text = displayText;
    // }

    public void StatusTextDisplay(string displayText, bool display)
    {
        if (statusText == null)
        {
            statusText = GameObject.Find("DisplayText")
                                   .GetComponent<TMP_Text>();
        }
        
        if (display)
        {
            statusText.text = displayText;
            LeanTween.scale(statusText.gameObject, new Vector3(1, 1, 1), transitionTime);
        }
        else
        {
            statusText.text = "";
            LeanTween.scale(statusText.gameObject, Vector3.zero, transitionTime).setCallback();
        }
    }
}