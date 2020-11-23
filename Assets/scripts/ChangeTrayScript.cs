using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTrayScript : MonoBehaviour
{
    int TIME_LIMIT = 45;            // Time to solve each problem, in seconds

    int price, payment, solution;   // Used to generate problems
    bool isProblemActive = false;   // Tracks if problem and timer are active
    int score, lives;               // Used to track gamestate
    float timeRemaining;            // Used to track time left
    Collider2D changeTrayCollider;  // Collider on changeTray, used for checking solution

    // TODO proper implementation
    GameObject paymentCheat;
    // Sprites for various payment configurations
    public Sprite payment30;
    public Sprite payment45;
    public Sprite payment50;

    //TODO break up into own script
    // Text on register
    TextMeshPro priceText, timerText, scoreText, livesText;  // TODO heart icons
    // Register Gameobject and sprites
    GameObject register;
    public Sprite registerBlank;
    public Sprite registerHappy;
    public Sprite resgisterSad;

    // Start is called before the first frame update
    void Start()
    {
        paymentCheat = GameObject.Find("Payment Cheat");
        changeTrayCollider = gameObject.GetComponent<Collider2D>();
        priceText = GameObject.Find("Price Text").GetComponent<TextMeshPro>();
        register = GameObject.Find("Register");
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshPro>();
        livesText = GameObject.Find("Lives Text").GetComponent<TextMeshPro>();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshPro>();

        startGame();
    }

    private void startGame()
    {
        score = 0;
        scoreText.text = "Score: 0";
        lives = 3;
        livesText.text = "Lives: 3";

        createProblem();

        priceText.alignment = TextAlignmentOptions.Left;
        priceText.fontSize = 8;
    }

    private void createProblem()
    {
        // Create a price, a payment and a expected change
        price = Random.Range(20, 45);
        if (price > 45)
        {
            payment = 50;
            paymentCheat.GetComponent<SpriteRenderer>().sprite = payment50;
        }
        else if (price > 25)
        {
            payment = 45;
            paymentCheat.GetComponent<SpriteRenderer>().sprite = payment45;
        }
        else
        {
            payment = 30;
            paymentCheat.GetComponent<SpriteRenderer>().sprite = payment30;
        }
        solution = payment - price;
        priceText.text = "$" + price + ".00";
        timeRemaining = TIME_LIMIT;
        timerText.text = "Time: " + TIME_LIMIT;
        isProblemActive = true;
    }

    public void Update()
    {
        // Update proposed solution
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            GameObject[] billObjects = GameObject.FindGameObjectsWithTag("Bill");
            int proposedSolution = 0;

            foreach (GameObject bill in billObjects)
            {
                Collider2D billCollider = bill.GetComponent<Collider2D>();
                if (billCollider.bounds.Intersects(changeTrayCollider.bounds))
                {
                    proposedSolution += bill.GetComponent<BillScript>().value;
                }
            }

            // Check solution
            print(proposedSolution);
            if (proposedSolution == solution)
            {
                // Start transition into new problem
                isProblemActive = false;
                StartCoroutine(transitionCoroutine(1, 3f)); // Success
            }
        }

        // Check if time limit expired
        if(isProblemActive)
        {
            timeRemaining -= Time.deltaTime;
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = "Time: " + seconds;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerText.text = "Time: 0";
                isProblemActive = false;
                StartCoroutine(transitionCoroutine(2, 3f)); // Failure
            }
        }
    }

    IEnumerator transitionCoroutine(int state, float delay)
    {
        // Hide register price and payment
        priceText.enabled = false;
        paymentCheat.SetActive(false);
        // Clean up change tray
        GameObject[] billObjects = GameObject.FindGameObjectsWithTag("Bill");
        foreach (GameObject bill in billObjects)
        {
            Collider2D billCollider = bill.GetComponent<Collider2D>();
            if (billCollider.bounds.Intersects(changeTrayCollider.bounds))
            {
                Destroy(bill);
            }
        }

        // Switch register to appropiate face and wait a second
        // TODO use switch statement
        if (state == 1) {
            register.GetComponent<SpriteRenderer>().sprite = registerHappy;
            score++;
            scoreText.text = "Score: " + score;
        }
        else {
            register.GetComponent<SpriteRenderer>().sprite = resgisterSad;
            lives--;
            livesText.text = "Lives: " + lives;
        }
        yield return new WaitForSeconds(delay);

        // If lives are still left, continue game
        if (lives > 0)
        {
            // Prepare play area for next problem
            register.GetComponent<SpriteRenderer>().sprite = registerBlank;
            priceText.enabled = true;
            paymentCheat.SetActive(true);
            createProblem();
        }

        else
        {
            register.GetComponent<SpriteRenderer>().sprite = registerBlank;
            priceText.enabled = true;
            priceText.text = "GAME OVER";
            priceText.alignment = TextAlignmentOptions.Center;
            priceText.fontSize = 6;
        }
    }
}
