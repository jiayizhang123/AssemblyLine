using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConveyorAnimation : MonoBehaviour
{
    public SpeedControl speedControl;
    public StartButton startButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {  //moving the texture of the belt
        if (startButton.start)
        {
            float Transition = Time.time * speedControl.BeltSpeed;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Transition, 0);
        }
    }
}
