using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    Vector3 position;
    Quaternion newRotation = Quaternion.Euler(0, 0, 0);

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        position = new Vector3(0, 0, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.changecam)
        {

            this.transform.position = player.transform.position + offset;
        }
        else if (PlayerController.changecam)
        {
            this.transform.position = Vector3.SmoothDamp(transform.position, player.transform.position - position,ref velocity,1);
            transform.rotation = Quaternion.Slerp(transform.rotation,newRotation,Time.deltaTime * 3);
        }
    }
}
