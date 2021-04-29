using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    Quaternion target;
    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * -tiltAngle;

        // Rotate the cube by converting the angles into a quaternion.
        target = Quaternion.Euler(target.x + tiltAroundX, target.y + tiltAroundY, 0);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
