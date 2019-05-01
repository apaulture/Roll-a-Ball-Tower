using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private bool levelTrigger = false;
    private int timeRemaining;
    private int count;

    public Text score;
    public Text gameOver;
    public Text textTimer;


    public float time;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;
        updateScore();


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
        }
    }

    void WinGame(Collider other)
    {
        if (other.gameObject.CompareTag("Treasure"))
        {
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            gameOver.text = "Stage complete!";
        }
    }

    void updateScore()
    {
            score.text = "Score: " + count.ToString();
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
