using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextureMatch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject paintboard;
    public Image image;
    private Texture2D texture;

    public void Start()
    {
        paintboard = GameObject.FindGameObjectWithTag("Whiteboard");
        
       
    }

    // Update is called once per frame
    public void Update()
    {
        texture = GetComponent<Image>().material.mainTexture as Texture2D;
        Material mat = paintboard.GetComponent<Material>();
        //Material mat2 = image.GetComponent<Material>();
        //image.material = mat;
    }
}
