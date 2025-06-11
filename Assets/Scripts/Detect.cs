using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Detect : MonoBehaviour
{
    public TextMeshPro textMesh;
    public int count = 0;
    public int pick = 0;
    private void OnTriggerEnter(Collider other)
    {
        count++;
        textMesh.text = count.ToString(); //showing the number on the displaying board
        pick ++;
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
