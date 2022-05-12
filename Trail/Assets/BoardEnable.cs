using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEnable : MonoBehaviour
{
    public GameObject Board;

    public void Enable()
    {
        if(Board.activeInHierarchy == false)
        {
            Board.SetActive(true);
        }else if (Board.activeInHierarchy == true)
        {
            Board.SetActive(false);
        }
    }
}
