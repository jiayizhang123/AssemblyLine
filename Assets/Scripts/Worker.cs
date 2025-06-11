using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public int period = 10;
    public AudioSource voice;
    private DateTime time0;
    private Animator animator;
    private string textToSpeak = "Please check the product's quality and put qualified products on the conveyor belt.";
    // Start is called before the first frame update
    void Start()
    {
        time0 = DateTime.Now;
        animator = GetComponent<Animator>();
        animator.SetInteger("state", 1);
        voice.Play();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = DateTime.Now - time0;
        if (ts.Seconds > period )
        {
            animator.SetInteger("state", 1);
            voice.Play();
            time0 = DateTime.Now;
            
        }
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        //Debug.Log(stateInfo.IsName("Idle")+" "+ animator.GetInteger("state"));
        //if (stateInfo.IsName("Talking") && animator.GetInteger("state") == 1)
        //    animator.SetInteger("state", 0);
    }
}
