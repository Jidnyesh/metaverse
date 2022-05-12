using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyMat : MonoBehaviour
{
    public GameObject board;

    public void Start()
    {
        
    }
    public void Update()
    {
        Material mat = board.GetComponent<Renderer>().material;
        GetComponent<Renderer>().material.CopyPropertiesFromMaterial(mat);
    }
}
