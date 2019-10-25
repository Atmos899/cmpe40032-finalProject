using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 targetPos;
    public float yIncrement;

    public float speed;

    public float maxHeight;
    public float minHeight;

    private bool moving = false;

    public int health = 3;

    public GameObject effect;
    public GameObject gameOver;
    public GameObject moveSound;
    public GameObject spawner;
    

    public Text hpDisplay;

    public int score = 0;
    private float rawScore = 0;
    public Text scoreDisp;
    public Text currentScore;
    public Text highScore;

    public float multiplier = 1;

    void Scorer()
    {
        rawScore += (multiplier * Time.deltaTime);
        score = (int)rawScore;
        scoreDisp.text = score.ToString();
        if (score > PlayerPrefs.GetInt("Highscore",0))
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScore.text = score.ToString();
        }
    }

    private void Start()
    {
        targetPos = new Vector2(transform.position.x, transform.position.y);
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }


    void Update()
    {
        Scorer();
        currentScore.text = score.ToString();
        hpDisplay.text = health.ToString();



        if (health <= 0)
        {
            gameOver.SetActive(true);
            spawner.SetActive(false);
            gameObject.SetActive(false);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (moving == false)
        {
            if (Input.GetKeyDown(KeyCode.S) && transform.position.y == maxHeight)
            {
                Instantiate(moveSound, transform.position, Quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
                moving = true;
                Instantiate(effect, transform.position, Quaternion.identity);
                PosChecker();
            }
            else if (Input.GetKeyDown(KeyCode.W) && transform.position.y == minHeight)
            {
                Instantiate(moveSound, transform.position, Quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
                Instantiate(effect, transform.position, Quaternion.identity);
                moving = true;
                PosChecker();
            }else if (Input.GetKeyDown(KeyCode.S) && transform.position.y == 0)
            {
                Instantiate(moveSound, transform.position, Quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
                Instantiate(effect, transform.position, Quaternion.identity);
                moving = true;
                PosChecker();
            }
            else if (Input.GetKeyDown(KeyCode.W) && transform.position.y == 0)
            {
                Instantiate(moveSound, transform.position, Quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
                Instantiate(effect, transform.position, Quaternion.identity);
                moving = true;
                PosChecker();
            }
        }
    } 

    void PosChecker()
    {
        if (transform.position.y == maxHeight && moving == true)
        {
            moving = false;
        }
        else if (transform.position.y == minHeight && moving == true)
        {
            moving = false;
        }
        else if (transform.position.y == 0 && moving == true)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }
}
