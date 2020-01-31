using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelJoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FixSuspensionDirection();
    }
    void FixSuspensionDirection()
    {
        WheelJoint2D wheel = GetComponent<WheelJoint2D>();
        JointSuspension2D sus = wheel.suspension;
        Vector2 facingDir = transform.InverseTransformDirection(wheel.connectedBody.transform.right);
        float angleOffset = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;

        sus.angle = angleOffset + 90;
        wheel.suspension = sus;
    }
}
