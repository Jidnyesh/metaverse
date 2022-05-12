using UnityEngine;
using System.Collections;

public class Followmouse : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y+0.1f, 1.0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 newPos = hit.point;
                transform.position = newPos +new Vector3(0, 0, 0.015f);
            if(Input.GetMouseButton(0))
            {
                transform.position = newPos;
            }
            
            
        }
    }
}