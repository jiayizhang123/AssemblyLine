using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltPhysics : MonoBehaviour
{
    public SpeedControl speedControl;
    public StartButton startButton;
    Rigidbody conv;
    private float currentRot;
    private int orientation;

    // Start is called before the first frame update
    void Start()
    {
        //set the belt moving direction according to the current direction
        conv = GetComponent<Rigidbody>();
        Quaternion rot = transform.rotation;
        currentRot = rot.eulerAngles.y;
        //Debug.Log(currentRot);
        if (currentRot == 0 || currentRot % 360 == 0)
        {
            orientation = 0;
        }
        else if (currentRot == 90)
        {
            orientation = 1;
        }
        else if (currentRot == 180)
        {
            orientation = 2;
        }
        else if (currentRot == 270)
        {
            orientation = 3;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startButton.start)
        {
            Vector3 pos = conv.position;
            //according to the direction, moving the belt
            if (orientation == 0)
            {
                conv.position = conv.position + Vector3.right * speedControl.speed * Time.fixedDeltaTime;
            }
            else if (orientation == 1)
            {
                conv.position = conv.position + Vector3.back * speedControl.speed * Time.fixedDeltaTime;
            }
            else if (orientation == 2)
            {
                conv.position = conv.position + Vector3.left * speedControl.speed * Time.fixedDeltaTime;
            }
            else if (orientation == 3)
            {
                conv.position = conv.position + Vector3.forward * speedControl.speed * Time.fixedDeltaTime;
            }

            conv.MovePosition(pos);

        }

    }

}
