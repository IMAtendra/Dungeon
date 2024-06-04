﻿using System;
using UnityEngine;

public interface ICollectible
{
    void Collect();
}

public enum CollectibleType
{
    Coin,
    Gem
}

public class Collectibles : MonoBehaviour, ICollectible
{
    public int IncrementValue;
    public CollectibleType ItemType;
    public static event Action<int, CollectibleType> OnCollectiblesCollected;
    public GameObject destroyEffect;

    public void Collect()
    {
        Debug.Log($"You Have Collected {ItemType}");
        OnCollectiblesCollected?.Invoke(IncrementValue, ItemType);
        Destroy(gameObject);
        
        // Spawn & Destroy Effect
        var temp = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(temp, 2f);
    }
}
