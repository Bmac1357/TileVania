using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFadeOut : MonoBehaviour {

    // FadeOut
    [SerializeField] float fadeTime = 2f;

    public Texture2D fadeTexture;
    public int drawDepth = -1000;


    public float fadeSpeed = 0.5f;


    public float fadeDir = 1;


    private float alpha = 0.0f;
    //private float fadeDir = -1;

    private float elapsedTime = 0f;

    public void OnGUI()
    {
        Fade();

        /*
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        
        if (alpha >= 1.0f)
        {
            //Object.Destroy(gameObject);
        }
        */
    }

    public void Fade()
    {
        alpha = elapsedTime / fadeTime;

        // Cant use time since loaded, need timer
        //if (alpha <= 1.0f)
        {
            Color newColor = GUI.color;
            newColor.a = alpha;

            GUI.color = newColor;

            GUI.depth = drawDepth;

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

            // !! Dont destroy so hides transition to next screen loading
            if (alpha >= 1.0f)
            {
                //Object.Destroy(gameObject);
                //return;
            }

            elapsedTime += Time.deltaTime;
        }

    }
}
