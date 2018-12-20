using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinScore = 10;

    [SerializeField] AudioClip coinPickSFX;

    private GameSession gameSession;

    private AudioSource myAudioSource;

    // Use this for initialization
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();

        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only check for player capsule collider, otherwise get two collisions !!
        if (collision is CapsuleCollider2D)
        {
            if (gameSession)
            {
                gameSession.UpdateScore(coinScore);
            }

            AudioSource.PlayClipAtPoint(coinPickSFX, Camera.main.transform.position);

            Object.Destroy(gameObject);
        }
    }

}
