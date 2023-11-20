using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeCameraRotation : BasicCameraRotation
{
    private float x;
    private float y;

    public bool gyroEnabled = true;
    readonly float sensitivity = 50.0f;
    
    private bool CanMove = true;
    private bool gyroON = true;

    private Gyroscope gyro;

    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }
    void Update()
    {
        gyroON = gyroSlider.gyroON;
        CanMove = DialogManager.CanMove;
        if (CanMove && gyroON)
        {
            gyroEnabled = true;
        }
        else
        {
            gyroEnabled = false;
        }

        if (gyroEnabled)
        {
            GyroRotation();
        }
    }
    void GyroRotation()
    {
        x = Input.gyro.rotationRate.x;
        y = Input.gyro.rotationRate.y;

        float xFiltered = FilterGyroValues(x);
        RotateUpDown(xFiltered * sensitivity);

        float yFiltered = FilterGyroValues(y);
        RotateRightLeft(yFiltered * sensitivity);
    }

    float FilterGyroValues(float axis)
    {
        if (axis < -0.1 || axis > 0.1)
        {
            return axis;
        }
        else
        {
            return 0;
        }
    }
}
