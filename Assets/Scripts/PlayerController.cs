using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private int timeRemaining;
    private int count;
    public static bool changecam = false;

    public Text score;
    public Text gameOver;
    public Text textTimer;

    public float time;
    public float speed;

    public bool isGrounded;

    private AudioSource source;
    public AudioClip pickupAudio;
    public AudioClip lava;
    public AudioClip treasure;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();

        count = 0;
        updateScore();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    private void Update()
    {
        timeRemaining = (int)(time - Time.time);
        textTimer.text = "Time: " + timeRemaining.ToString() + " seconds";

        if (timeRemaining == 0)
        {
            gameOver.text = "Time's up!";
            this.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }
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
            count++;
            updateScore();
            source.PlayOneShot(pickupAudio,0.7f);
        } 
        else if (other.gameObject.CompareTag("Treasure"))
        {
            source.PlayOneShot(treasure, 1);
            other.gameObject.SetActive(false);
            Destroy(gameObject, .2f);
            gameOver.text = "Stage complete!";
        }
        else if (other.gameObject.CompareTag("Lava"))
        {
            source.PlayOneShot(lava, 0.7f);
            this.gameObject.transform.position = new Vector3(0, 135, 0);
        }
        else if (other.gameObject.CompareTag("Laser"))
        {
            source.PlayOneShot(lava, 0.7f);
            this.gameObject.transform.position = new Vector3(0, 135, 0);
        }
        else if (other.gameObject.CompareTag("Cam"))
        {
            changecam = !changecam;
        }
    }

    void updateScore()
    {
            score.text = "Score: " + count.ToString();
    }
}
