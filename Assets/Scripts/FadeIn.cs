using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    // FadeIn
    [SerializeField] float fadeTime = 2f;

    public Texture2D fadeTexture;
    public int drawDepth = -1000;

    /*
    public float fadeSpeed = 0.5f;
    

    public float fadeDir = -1;
    */

    private float alpha = 1.0f;

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

        if (alpha <= 0.0f)
        {
            Object.Destroy(gameObject);
        }
        */
    }

    public void Fade()
    {
        alpha = 1.0f - Time.timeSinceLevelLoad / fadeTime;

        //Debug.Log("Alpha = " + alpha);
 
        Color newColor = GUI.color;
        newColor.a = alpha;

        GUI.color = newColor;

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);

        // Fade in has dinished, so destroy object, no longer needed
        if (alpha <= 0.0f)
        {
            Object.Destroy(gameObject);
            return;
        }
    }
}
