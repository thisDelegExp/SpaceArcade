using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text  scoreText;
    public Text restartText;
    public Text overText;
    private bool gameOver;
    private bool Restart;
    private int score;

    private void Update()
    {
        if (Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 0, spawnValues.z);
                
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart";
                Restart = true;
                break;
            }
        }
        
   }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void Start()
    {
        gameOver = false;
        Restart = false;
        restartText.text = "";
        overText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    public void GameOver()
    {
        overText.text = "GAME OVER";
        gameOver = true;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score; 
    }
}
