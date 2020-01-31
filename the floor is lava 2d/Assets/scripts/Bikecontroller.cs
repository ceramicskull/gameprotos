using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bikecontroller : MonoBehaviour
{
    public GameObject wheel1;
    public GameObject wheel2;

    JointMotor2D jointMotor;
    public Sprite[] bikergif; 
    public float speed;
    public float torque;
    private int distance;
    public int frameScale;
    private int frameCounter;
    private float oldPos;
    private bool old;
    private bool dead;
    float[] storedV;
    private bool oldV;
    public Text distanceCounter;
    // Start is called before the first frame update
    void Start()
    {
        jointMotor.maxMotorTorque = 10000;
        old = false;
        dead = false;
        oldV = false;
        storedV = new float[2];
        wheel1.GetComponent<WheelJoint2D>().useMotor = false;
        wheel2.GetComponent < WheelJoint2D >().useMotor = false;
        distance = 0;
        frameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!old) { 
            oldPos = transform.position.x;
            old = true;
        }
        else if(transform.position.x >= oldPos + 1 || transform.position.x <= oldPos - 99)
        {
            distance++;
            old = false;
        }

        float thrust = speed * Input.GetAxis("Vertical");
        float lean = torque * -Input.GetAxis("Horizontal");
        jointMotor.motorSpeed = thrust;

        wheel1.GetComponent<WheelJoint2D>().motor = jointMotor;
        wheel2.GetComponent<WheelJoint2D>().motor = jointMotor;

        if (Input.GetAxisRaw("Vertical").Equals(0)){

            wheel1.GetComponent<WheelJoint2D>().useMotor = false;
            wheel2.GetComponent<WheelJoint2D>().useMotor = false;

        }

        GetComponent<Rigidbody2D>().AddTorque(lean);
        distanceCounter.text = distance + " m";

        if(!dead){
            Biking();
        }



    }
    void Biking(){
        if (Input.GetAxis("Vertical") > 0)
        {
            frameCounter++;
            if (frameCounter < bikergif.Length * frameScale)
            {
                GetComponent<SpriteRenderer>().sprite = bikergif[frameCounter / frameScale];
            }
            else
            {
                frameCounter = 0;
                GetComponent<SpriteRenderer>().sprite = bikergif[frameCounter / frameScale];
            }
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            frameCounter--;
            if (frameCounter > 0)
            {
                GetComponent<SpriteRenderer>().sprite = bikergif[frameCounter / frameScale];
            }
            else
            {
                frameCounter = bikergif.Length * frameScale - 1;
                GetComponent<SpriteRenderer>().sprite = bikergif[frameCounter / frameScale];
            }
        }
    }
    void Dead(){
        dead = true;
    }

}
