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

    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        Vector3 bob = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        screenbounds = Camera.main.ScreenToWorldPoint(bob);
        player = playerPrefab;
        scoreText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
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
    }

    void OnPlayerKilled()
    {
        spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);
    }

  


    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
        if (Input.anyKeyDown)
        {
                ResetGame();
        }
        }else
        {
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
    }
}





