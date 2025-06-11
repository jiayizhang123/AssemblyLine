using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public float BeltSpeed;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    { //control the belt texture moving speed align with the rigid body
        BeltSpeed = -speed * 0.8f;
    }

    // Update is called once per frame
    void Update()
    {
        //control the belt texture moving speed align with the rigid body
        BeltSpeed = -speed * 0.8f;
    }
}
