using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLightbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = new Vector3(.6f, Random.Range(1.1f, 4.2f), .6f);
        transform.localScale += size;
        transform.rotation = Quaternion.Euler(90,0,0);
    }
}
