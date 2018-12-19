using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float delayLevelTime = 2.0f;
    [SerializeField] float levelExitSlowMo = 0.25f;

    [SerializeField] FadeOut fadeOut;

    float defaultTimeValue;

    private void Start()
    {
        defaultTimeValue = Time.timeScale;
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // leave by exit

        //StartCoroutine("ExitLevel");

        StartCoroutine("WaitForTime");
    }

    IEnumerator ExitLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        buildIndex++;

        yield return new WaitForSeconds(delayLevelTime);

        SceneManager.LoadScene(buildIndex);
    }

    IEnumerator WaitForTime()
    {
        Time.timeScale = levelExitSlowMo;

        Instantiate(fadeOut, transform.position, Quaternion.identity);

        yield return new WaitForSecondsRealtime(delayLevelTime);

        Time.timeScale = defaultTimeValue;

        int buildIndex = SceneManager.GetActiveScene().buildIndex;

        buildIndex++;
       
        //if (buildIndex <  SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(buildIndex);
        }
    }


}
