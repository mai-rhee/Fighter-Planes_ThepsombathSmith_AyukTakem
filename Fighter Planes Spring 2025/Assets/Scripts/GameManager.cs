using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemytwooPrefab;
    public GameObject cloudPrefab;
    public GameObject coinPrefab;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;

    public float horizontalScreenSize;
    public float verticalScreenSize;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenSize = 9.6f;
        verticalScreenSize = 6.5f;
        score = 0;
        ChangeScoreText(score);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemy", 1, 3);
        InvokeRepeating("CreateEnemyTwoo", 2, 8);
        InvokeRepeating("CreateCoin", 14, 19);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEnemy()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize)
            * 0.9f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateEnemyTwoo()
    {
        Instantiate(enemytwooPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize)
            * 0.5f, verticalScreenSize, 0), Quaternion.Euler(180, 0, 0));
    }

    void CreateCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize)
             * 0.5f, verticalScreenSize, 0), Quaternion.identity);
    }
    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize),
           Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        ChangeScoreText(score);
    }

    public void ChangeScoreText(int earnedScore)
    {
        scoreText.text = "Score: " + earnedScore;
    }
    public void ChangeLivesText(int currentlives)
    {
        livesText.text = "Lives: " + currentlives;
    }

}
