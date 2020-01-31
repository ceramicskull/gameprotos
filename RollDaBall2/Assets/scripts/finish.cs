using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    // Start is called before the first frame update
    float x;
    float y;
    float z;
    Vector3 startPosBall;
    Vector3 startPosWld;
    Quaternion startRot;
    public GameObject ball;
    public GameObject world;

    void Start()
    {
        startPosBall = ball.transform.position;
        startRot = world.transform.rotation;
        startPosWld = world.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        x += 1.0f;
        y += 1.0f;
        z += 1.0f;

        transform.eulerAngles = new Vector3(x, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == ball){
            Win();
        }
    }
    private void Win(){
        ball.transform.position = startPosBall;
        world.transform.rotation = startRot;
        world.transform.position = startPosWld;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
