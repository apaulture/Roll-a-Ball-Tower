using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        if (this.gameObject.CompareTag("FloatLevel"))
        {
            for (int i = 0; i <= 300; i++)
            {
                Vector3 position = new Vector3(Random.Range(-28, 28), Random.Range(78, 122), Random.Range(-20, 20));
                Instantiate(prefab, position, Quaternion.identity);
            }
        } else if (this.gameObject.CompareTag("StartLevel"))
        {
            for (int i = 0; i <= 2; i++)
            {
                Vector3 position = new Vector3(Random.Range(-16, 16), 132.5f, Random.Range(-9, 9));
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
        else if (this.gameObject.CompareTag("PickupCarpet"))
        {
            for (int i = 0; i <= 15; i++)
            {
                Vector3 position = new Vector3(0.3f, Random.Range(7,68), 10.65f);
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
        else if (this.gameObject.CompareTag("Lightbar"))
        {
            for (int i = 0; i <= 350; i++)
            {
                Vector3 position = new Vector3(Random.Range(-50, 50), Random.Range(-10, 30), Random.Range(93, 350));
                Instantiate(prefab, position, Quaternion.identity);
            }
        }
    }
}
