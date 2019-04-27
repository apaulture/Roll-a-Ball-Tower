using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public bool levelTrigger = false;
    public float timer = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0, moveV);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
        } else if (other.gameObject.CompareTag("Level") && timer > 5)
        {
            levelTrigger = !levelTrigger;
        }
    }

    private void OnGUI()
    {
        if (levelTrigger)
        {
            GUI.skin.label.fontSize = 100;

            GUI.Label(new Rect(Screen.width / 2.5f, Screen.height / 6.5f, 500, 500), "Level 1");
        }
    }
}
