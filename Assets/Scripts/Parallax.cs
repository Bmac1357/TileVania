using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    [SerializeField] public float backGroundSize = 5f;
    [SerializeField] public float parallaxSpeed = 0.25f;

    private Transform cameraTransform;

    private float lastCameraX, lastCameraY;

    [SerializeField] public float viewZone = 10.0f;

    // Use this for initialization
    void Start ()
    {
        cameraTransform = Camera.main.transform;

        lastCameraX = cameraTransform.position.x;
        lastCameraY = cameraTransform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //float deltaX = cameraTransform.position.x - lastCameraX;
        float deltaY = cameraTransform.position.y - lastCameraY;

        //lastCameraX = cameraTransform.position.x;
        lastCameraY = cameraTransform.position.y;

        //transform.position += ( (Vector3.right * deltaX * parallaxSpeed) + (Vector3.up * deltaY * parallaxSpeed) );
        //transform.Translate((Vector3.up * deltaY * parallaxSpeed));
        transform.Translate((Vector3.up * deltaY * parallaxSpeed));

        //Debug.Log("c = " + cameraTransform.position.x + " l = " + backgroundLayers[leftIndex].position.x + " r = " + backgroundLayers[rightIndex].position.x + " k = " + (backgroundLayers[leftIndex].position.x  + viewZone));

        /*
        if (cameraTransform.position.y < (transform.position.y + viewZone))
        {
            //Debug.Log("ScrollLeft");
            ScrollLeft();
        }

        if (cameraTransform.position.y > (transform.position.y - viewZone))
        {

            // Debug.Log("ScrollRight");
            ScrollRight();
        }
        */
    }


    private void ScrollRight()
    {
        //int lastRight = rightIndex;

        //float posX = Vector3.right.x * transform.position.x + backGroundSize;
        transform.Translate(Vector3.up);

        //backgroundLayers[leftIndex].position = new Vector3(posX, transform.position.y, transform.position.z);
        //transform.position = new Vector3(posX, posY, transform.position.z);

        /*
        rightIndex = leftIndex;

        if (leftIndex + 1 >= backgroundLayers.Length)
        {
            leftIndex = 0;
        }
        else
        {
            leftIndex++;
        }
        */
    }

    private void ScrollLeft()
    {
        //int lastLeft = leftIndex;

        //float posX = Vector3.right.x * transform.position.x - backGroundSize;
        //float posY = transform.position.y;

        transform.Translate(Vector3.down);

        //backgroundLayers[rightIndex].position = new Vector3(posX, transform.position.y, transform.position.z);
        //transform.position = new Vector3(posX, posY, transform.position.z);

        /*
        leftIndex = rightIndex;

        if (rightIndex - 1 < 0)
        {
            rightIndex = backgroundLayers.Length - 1;
        }
        else
        {
            rightIndex--;
        }
        */
    }

}
