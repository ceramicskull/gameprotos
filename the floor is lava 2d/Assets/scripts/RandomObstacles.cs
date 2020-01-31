using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomObstacles : MonoBehaviour
{
    public GameObject[] obstacles;
    private System.Random random;
    private int next;
    public GameObject bike;
    public GameObject clouds1;
    public GameObject clouds2;
    private float oldX;
    public float scaleSize;
    private bool objPlaced;
    public float distanceTillRepeat;
   
    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();
        oldX = bike.transform.position.x;
        objPlaced = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bike.transform.position.x >= distanceTillRepeat)
        {
            bike.transform.position -= new Vector3(distanceTillRepeat, 0, 0);
            oldX = bike.transform.position.x;
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].transform.position -= new Vector3(distanceTillRepeat, 0, 0);
            }
            Debug.Log("reset position");
        }

        if (bike.transform.position.x > oldX + 11.0f)
        {
            oldX = bike.transform.position.x;
            objPlaced = false;
        }
        else if (bike.transform.position.x > oldX + 10.0f && !objPlaced)
        {
            next = random.Next(0, obstacles.Length);
            Vector3 testpoint = GetComponent<Camera>().WorldToViewportPoint(obstacles[next].transform.position);
            if (testpoint.x <= 0)
            {

                GameObject nextObj = obstacles[next];
                nextObj.transform.position = new Vector3(transform.position.x + 28f, nextObj.transform.position.y, nextObj.transform.position.z);
                float scl = (float)random.NextDouble() * scaleSize;
                nextObj.transform.localScale = new Vector3(nextObj.transform.localScale.x * scl + 0.5f, nextObj.transform.localScale.y * scl + 0.5f, 1);

            }
            objPlaced = true;
        }


        


    }

}
