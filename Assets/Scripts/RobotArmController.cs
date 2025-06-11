using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotArmController : MonoBehaviour
{
    public float basePos = 0f;
    public float armPos = 0f;
    private float basePickPos = -40f;
    private float armPickPos = 19f;
    private float baseDropPos = 40f;
    private float armDropPos = 30f;
    public Detect detect;
    public SuckingEnd suckingEnd;

    // slider value for base platform that goes from -1 to 1.
    public float baseTurnDirection = 1.0f;

    // slider value for upper arm that goes from -1 to 1.
    public float armTurnDirection = 1.0f;

    // These slots are where you will plug in the appropriate arm parts into the inspector.
    public Transform robotBase;
    public Transform upperArm;

    // moving speed
    public float baseTurnRate = 1.0f;
    public float upperArmTurnRate = 1.0f;
    //set the range of base movement
    private float baseYRot = 0.0f;
    public float baseYRotMin = -45.0f;
    public float baseYRotMax = 45.0f;
    //set the range of upperArm movement
    private float upperArmXRot = 0.0f;
    public float upperArmXRotMin = -45.0f;
    public float upperArmXRotMax = 45.0f;
    private bool dropFlag;

    void ProcessMovement()
    {
        if (baseYRot != basePos)
        {
            if (baseYRot > basePos) baseTurnDirection = -1f; //set moving direction
            else baseTurnDirection = 1f;
            //Debug.Log(baseYRot + " " + basePos + " " + baseTurnDirection);

            //rotating base of the robot around the Y axis 
            baseYRot += baseTurnDirection * baseTurnRate;
            baseYRot = Mathf.Clamp(baseYRot, baseYRotMin, baseYRotMax);
            robotBase.localEulerAngles = new Vector3(robotBase.localEulerAngles.x, baseYRot, robotBase.localEulerAngles.z);
        }
        if (upperArmXRot != armPos)
        {
            if (upperArmXRot > armPos) armTurnDirection = -1f; //set moving direction
            else armTurnDirection = 1f;
            //rotating upper arm of the robot around the X axis 
            upperArmXRot += armTurnDirection * upperArmTurnRate;
            upperArmXRot = Mathf.Clamp(upperArmXRot, upperArmXRotMin, upperArmXRotMax);
            upperArm.localEulerAngles = new Vector3(upperArmXRot, upperArm.localEulerAngles.y, upperArm.localEulerAngles.z);
        }
    }


    void Update()
    {

        if (detect.pick > 0)
        {

            //if a product is detected, moving to the picking position
            if (suckingEnd.pickedObject == null)
            {
                basePos = basePickPos;
                armPos = armPickPos;
                dropFlag = false;
            }
            else
            {
                // after picking the product, moving base to dropping position
                //if (upperArmXRot == armPickPos )
                //{
                //    suckingEnd.Picking();
                //    basePos = baseDropPos;
                //    armPos = armDropPos;

                //}
                if (baseYRot == baseDropPos)
                { // moving base and upperarm to target position, then drop
                    if (upperArmXRot == armDropPos)
                    {
                        if (!dropFlag)
                        {
                            suckingEnd.Droping();
                            Debug.Log("number" + detect.pick);
                            //basePos = 0f;
                            //armPos = 0f;
                            detect.pick--;
                            dropFlag = true;
                        }
                    } //during moving upperarm, holding product
                    else suckingEnd.Picking();
                }
                else
                {
                    suckingEnd.Picking();
                    basePos = baseDropPos;
                    armPos = armDropPos;
                }
            }
        }

        ProcessMovement();

    }
}
