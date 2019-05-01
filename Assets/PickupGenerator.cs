using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        for (int i = 0; i <= 300; i++)
        {
            Vector3 position = new Vector3(Random.Range(-28, 28), Random.Range(78, 122), Random.Range(-20, 20));
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
