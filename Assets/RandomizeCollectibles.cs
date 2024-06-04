using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCollectibles : MonoBehaviour
{

    // Program for Spawn Random Objects and Random Position with Random Rotation
    [SerializeField] private GameObject _previewObj;
    public GameObject[] prefab;

    private void Start()
    {
        GetLoadObject();
    }

    void GetLoadObject()
    {
        var index = Random.Range(0, prefab.Length);
        var pos = transform.position;
        var rot = Quaternion.identity;

        // if (_previewObj != null) 
        // {
        //     Destroy(_previewObj, 2f);
        //     Debug.Log(prefab[index].name + " is Eliminate");
        // }

        _previewObj = Instantiate(prefab[index],
                                  pos,
                                  rot);


        _previewObj.transform.SetParent(transform);
    }
}
