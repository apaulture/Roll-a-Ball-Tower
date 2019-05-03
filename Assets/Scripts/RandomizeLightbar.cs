using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeLightbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 size = new Vector3(.3f, Random.Range(.67f, 2.8f), .3f);
        transform.localScale += size;
        transform.rotation = Quaternion.Euler(90,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
