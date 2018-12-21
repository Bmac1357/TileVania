using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLives : MonoBehaviour {

    Image[] images;

    // Use this for initialization
    void Start()
    {
        images = GetComponentsInChildren<Image>();

    }
	
	// Update is called once per frame
	public void UpdateLives ()
    {
        GameSession gameSession = GetComponentInParent<GameSession>();

        int lives = gameSession.GetPlayerLives();

        //Debug.Log("Count = " + gameSession.GetPlayerLives());

        int i = 0;

        foreach (Image image in images)
        {
            if (!image.GetComponent<DisplayLives>())
            {

                if (i < lives)
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }

                i++;

                //Debug.Log("image " + i);
            }

        }
    }
}
