using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {


    [SerializeField] float flySpeed;
    [SerializeField] float xLimit;

    Vector3 startPos;

	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector3(Vector2.right.x * flySpeed * Time.deltaTime, 0f, 0f));	

        if (transform.position.x > xLimit)
        {
            transform.position = startPos;
        }
	}
}
