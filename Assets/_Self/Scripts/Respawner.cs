using UnityEngine;

public class Respawner : MonoBehaviour
{
    private readonly float threshold = -5f;

    public GameObject reswpawnEffect;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold) 
        {
            transform.position = Vector3.zero;
            var temp = Instantiate(reswpawnEffect, transform.position, Quaternion.identity);
            temp.transform.parent = gameObject.transform;
            Destroy(temp, 2f);
        }
    }
}
