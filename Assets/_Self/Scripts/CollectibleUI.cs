using UnityEngine;
using TMPro;

public class CollectibleUI : MonoBehaviour
{
    public int score;
    [SerializeField] private TMP_Text CoinText;
    [SerializeField] private TMP_Text GemText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Awake()
    {
        if (CoinText == null) CoinText = GameObject.Find("CoinText").GetComponent<TMP_Text>();
        if (GemText == null) GemText = GameObject.Find("GemText").GetComponent<TMP_Text>();

    }

    private void OnEnable()
    {
        Collectibles.OnCollectiblesCollected += CollectiblesCollected;
    }

    private void OnDisable()
    {
        Collectibles.OnCollectiblesCollected -= CollectiblesCollected;
    }

    private void CollectiblesCollected(int valueForIncrement, CollectibleType item)
    {
        // Debug.Log($"Increasing amount {valueForIncrement} of {item}");
        if (item == CollectibleType.Coin)
        {
            score += valueForIncrement;
            CoinText.text = score.ToString();
            // Debug.Log(item + " : " + score);
        }

        if (item == CollectibleType.Gem)
        {
            score += valueForIncrement;
            GemText.text = score.ToString();
            // Debug.Log(item + " : " + score);
        }
    }
}