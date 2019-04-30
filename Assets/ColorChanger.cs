using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    float duration = 1.5f;
    private float t = 0;
    private Renderer rend;
    Color lerpedColor = Color.white;

    void Start()
    {
        //Fetch the Renderer from the GameObject
        rend = GetComponent<Renderer>();

        //Set the main Color of the Material to green
        rend.material.shader = Shader.Find("_Color");

        //Find the Specular shader and change its Color to red
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_SpecColor", Color.red);
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1,1), Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1), Mathf.PingPong(Time.time, 3));
        rend.material.SetColor("_Color", lerpedColor);
    }


   /*void ColorChangerr()
    {
        if (this.tag == "Barrier")
        {
            rend.material.SetColor = Color.Lerp(Color.green, Color.red, t);

            if (t < 1)
            {
                t += Time.deltaTime / duration;
            }

        }

    }
    */   
}
