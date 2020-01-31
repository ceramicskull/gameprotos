using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 forceVector;
    public float thrust;
    int jumpCounter;
    void Start()
    {
        jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && jumpCounter < 2){

            GetComponent<Rigidbody>().AddForce(forceVector*thrust);
            Debug.Log("jump");
            jumpCounter++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        jumpCounter = 0;
    }
}
