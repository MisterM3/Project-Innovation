using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{
    //private Gyroscope phoneGyro;
    //private Quaternion correctionQuaternion;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    phoneGyro = Input.gyro;
    //    phoneGyro.enabled = true;
    //    correctionQuaternion = Quaternion.Euler(90f, 0f, 0f);
    //}

    void Update()
    {
        //GyroModifyCamera();

        Debug.Log(Input.deviceOrientation);

        if(Input.deviceOrientation == DeviceOrientation.Portrait)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        else if (Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    //void GyroModifyCamera()
    //{
    //    Quaternion gyroQuaternion = GyroToUnity(Input.gyro.attitude);
    //    // rotate coordinate system 90 degrees. Correction Quaternion has to come first
    //    Quaternion calculatedRotation = correctionQuaternion * gyroQuaternion;
    //    transform.rotation = calculatedRotation;
    //}

    //private static Quaternion GyroToUnity(Quaternion q)
    //{
    //    return new Quaternion(q.x, q.y, -q.z, -q.w);
    //}
}
