using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public GameObject ball;
    bool old;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = ball.transform.position;
        old = true;
        oldPos = ball.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = ball.transform.position;
        if (old)
        {
            oldPos = ball.transform.position;
            old = false;
        }
        else
        {
            Quaternion rotation = Quaternion.LookRotation(new Vector3(ball.transform.position.x - oldPos.x, 0, ball.transform.position.z - oldPos.z));
            Quaternion current = transform.rotation;

            transform.rotation = Quaternion.Slerp(current, rotation, 0.25f);
            old = true;
        }
    }
}
