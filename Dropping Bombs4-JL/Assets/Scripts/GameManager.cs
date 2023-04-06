using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Spawner spawner;
    public GameObject title;
    private Vector3 screenbounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
    public GameObject splash;
    public GameObject scoreSystem;
    public Text scoreText;
    public int pointsWorth = 1;
    private int score;

    private bool smokeCleared = true;

    int bestScore = 0;
    public Text bestScoreText;
    private bool beatbestScore;

    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        Vector3 bob = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        screenbounds = Camera.main.ScreenToWorldPoint(bob);
        player = playerPrefab;
        scoreText.enabled = false;
        bestScoreText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);

        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }
    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        splash.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;

        scoreText.enabled = true;
        scoreSystem.GetComponent<Score>().score = 0;
        scoreSystem.GetComponent<Score>().Start();

        beatbestScore = false;
        bestScoreText.enabled = true;
    }

    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;

        Invoke("SplashScreen", 2f);

        score = scoreSystem.GetComponent<Score>().score;

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            beatbestScore = true;
            bestScoreText.text = "Best Score: " + bestScore.ToString();
        }
    }

    void SplashScreen()
    {
        smokeCleared = true;
        splash.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
        if (!gameStarted)
        {
            if (Input.anyKeyDown && smokeCleared)
            {
                smokeCleared = false;
                ResetGame();
            }
        }else{
            if (!player)
            {
                OnPlayerKilled();
            }
        }

        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");

        foreach (GameObject bombObject in nextBomb)
        {
            if(!gameStarted)
            {
                Destroy(bombObject);
            } else if (bombObject.transform.position.y < (-screenbounds.y) && gameStarted)
            {
                scoreSystem.GetComponent<Score>().AddScore(pointsWorth);
                Destroy(bombObject);
            }
        }

        if(!gameStarted)
        {
            var textColor = "#323232";

            if (beatbestScore)
            {
                textColor = "#F00";
            }

            bestScoreText.text = "<color=" + textColor + ">Best Score: " + bestScore.ToString() + "</color>";

        }
        else
        {
            bestScoreText.text = "";
        }
    }
}




