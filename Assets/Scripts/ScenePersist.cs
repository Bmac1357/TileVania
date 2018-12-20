using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour {

    int buildStartIndex;

    private void Awake()
    {
        int numScenePersist = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersist > 1)
        {
            Object.Destroy(gameObject);
        }
        else
        {      
            DontDestroyOnLoad(gameObject);
        }

    }

    // Use this for initialization
    void Start ()
    {
        buildStartIndex = SceneManager.GetActiveScene().buildIndex;


    }

    // Update is called once per frame
    void Update ()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex != buildStartIndex)
        {
            Object.Destroy(gameObject);
        }
    }
}
