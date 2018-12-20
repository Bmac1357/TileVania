using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    //[SerializeField] int initialPlayerLives = 3;

    [SerializeField] int playerLives = 3;

    [SerializeField] float delayLevelTime = 5.0f;

    [SerializeField] int score = 0;

    [SerializeField] FadeOut fadeOut;

    [SerializeField] float levelExitSlowMo = 0.25f;

    [SerializeField] Text scoreText;

    //ScoreText scoreText;

    //[SerializeField] LivesText livesText;

    float defaultTimeValue;

    private void OnDestroy()
    {
          
    }

    private void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numGameSessions > 1)
        {
            Object.Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

            //scoreText = GetComponentInChildren<ScoreText>();
        }

    }

    // Use this for initialization
    void Start ()
    {
        defaultTimeValue = Time.timeScale;

        //scoreText = GetComponentInChildren<ScoreText>();

        //scoreText.UpdateScore(score);

        // Show current score
        scoreText.text = score.ToString();
    }

    public void UpdateScore(int newScore)
    {
        score += newScore;

        //scoreText.UpdateScore(score);     

        scoreText.text = score.ToString();
       
    }

    /*
    public int GetPlayerLives()
    {
        return playerLives;
    }
    */

    public void ProcessPlayerDeath()
    { 
        if (playerLives > 1)
        {
            TakeALife();
        }
        else
        {
            ResetGameSession();
        }

    }

    private void ResetGameSession()
    {
        //playerLives = initialPlayerLives;

        StartCoroutine("ResetCurrentSession");     
    }

    IEnumerator ResetCurrentSession()
    {
        //Time.timeScale = levelExitSlowMo;

        Instantiate(fadeOut, transform.position, Quaternion.identity);

        yield return new WaitForSecondsRealtime(delayLevelTime);

        //Time.timeScale = defaultTimeValue;

        SceneManager.LoadScene(0);

        Destroy(gameObject);
    }


    private void TakeALife()
    {
        playerLives--;

        //livesText.UpdateLives(playerLives);

        StartCoroutine("ResetCurrentLevel");
    }

    IEnumerator ResetCurrentLevel()
    {
        Time.timeScale = levelExitSlowMo;

        Instantiate(fadeOut, transform.position, Quaternion.identity);

        yield return new WaitForSecondsRealtime(delayLevelTime);

        Time.timeScale = defaultTimeValue;

        // Reload current scene
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(buildIndex);
    }

}
