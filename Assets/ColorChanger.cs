using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{


    private Renderer rend;
    Color lerpedColor = Color.white;

    void Start()
    {
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1,1), Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1), Mathf.PingPong(Time.time, 3));
        rend.material.SetColor("_Color", lerpedColor);
    }   
}
