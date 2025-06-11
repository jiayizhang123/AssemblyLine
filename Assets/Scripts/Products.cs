using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using System;

public class Products : MonoBehaviour
{
    public int period = 4;
    public GameObject productPrefab;
    public StartButton startButton;
    private DateTime time0;
    //public int productTotal = 3;
    private int productCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        time0 = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    { //generate a product in a period
        TimeSpan ts = DateTime.Now - time0;
        if (ts.Seconds > period && startButton.start)
        {
            Vector3 pos = new Vector3(-14.71194315f, 3.83989716f, -1.4796715f);
            //GameObject productInstance = Instantiate(productPrefab);
            GameObject productInstance = Instantiate(productPrefab, pos,Quaternion.identity,transform);
            time0 = DateTime.Now;
            productCount++;
        }
        
    }
}
