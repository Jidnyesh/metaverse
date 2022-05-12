using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Animator Left;
    public Animator Right;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        Left.SetInteger("Open", 1);
        Right.SetInteger("Open", 1);
    }

    void OnTriggerExit(Collider other)
    {
        Left.SetInteger("Open", 0);
        Right.SetInteger("Open", 0);
    }
}
