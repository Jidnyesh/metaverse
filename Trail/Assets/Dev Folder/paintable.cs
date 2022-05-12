using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;
using System;

public class paintable : MonoBehaviour { 


    public GameObject Brush;
    public float BrushSize = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            RPC_Draw();
        }
    }


    [Rpc(RpcSources.InputAuthority, RpcTargets.All)]
    private void RPC_Draw()
    {

        Debug.Log("RpcAttribute called");
        var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(Ray, out hit))
        {
        var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
        go.transform.localScale = Vector3.one * BrushSize;
        }
    }

}