using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;
    Vector3 f;
    Vector3 p;
    Vector3 oldPos;
    Vector3 lastKnown;
    bool old;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (old)
        {
            oldPos = ball.transform.position;
            old = false;
        }
        else if(ball.transform.position - oldPos == Vector3.zero)
        {
            f = new Vector3(lastKnown.x, 0, lastKnown.z);
            p = new Vector3(lastKnown.z, 0, lastKnown.x);
            transform.RotateAround(ball.transform.position, f, -1.0f * Input.GetAxis("Horizontal"));
            transform.RotateAround(ball.transform.position, p, 1.0f * Input.GetAxis("Vertical"));
            old = true;
        }
        else{
            lastKnown = ball.transform.position - oldPos;
            f = new Vector3(lastKnown.x, 0, lastKnown.z);
            p = new Vector3(lastKnown.z, 0, lastKnown.x);
            transform.RotateAround(ball.transform.position, f, -1.0f * Input.GetAxis("Horizontal"));
            transform.RotateAround(ball.transform.position, p, 1.0f * Input.GetAxis("Vertical"));
            old = true;
        }
    }
}
