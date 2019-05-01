using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Set the x position to loop between 0 and 3
        transform.position = new Vector3(transform.position.x, 20+Mathf.PingPong(Time.time*2, 12.27f), transform.position.z);
    }
}
