using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Fusion;

public class door : MonoBehaviour
{
    public Animator MapDoor;
    public GameObject offline;
    public GameObject Teacheronline;
    
    string checkhost;
    string checktype;
    public NetworkDebugStart runner;
    
    private string room = "123";
    public GameObject HOST;
    public GameObject CLIENT;

    public void Start()
    {
        Teacheronline.SetActive(false);
        
        HOST.SetActive(false);
        CLIENT.SetActive(false);
        
        
        if (PlayerPrefs.GetInt("number")==2)
        {
            offline.transform.SetAsFirstSibling();
            offline.SetActive(true);
            Teacheronline.SetActive(false);
            
        } else
            if (PlayerPrefs.GetInt("number") == 1)
        {
            Teacheronline.transform.SetAsFirstSibling();
            offline.SetActive(false);
            Teacheronline.SetActive(true);
            
        }
     
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Teacher")
        {
           
                HOST.SetActive(true);
                CLIENT.SetActive(true);
            //PlayerPrefs.SetInt("number", 1);


        } else   
        if (other.tag == "Student")
        {

                CLIENT.SetActive(true);
            
        } 

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Teacher")
        {

            HOST.SetActive(false);
            CLIENT.SetActive(false);
            //PlayerPrefs.SetInt("number", 1);


        }
        else
         if (other.tag == "Student")
        {

            CLIENT.SetActive(false);

        }
    }
  
    public void Opendoorhost()
    {
        MapDoor.SetInteger("Open", 1);
        PlayerPrefs.SetInt("number", 1);
        Debug.Log("room1");
        Invoke(nameof(starthost), 2.0f);
    }
    
    public void Opendoorclient()
    {
        MapDoor.SetInteger("Open", 1);
        PlayerPrefs.SetInt("number", 0);
        Invoke(nameof(client), 2.0f);
    }
    public void starthost()
    {
               
        checkhost = "Done";
        checktype = "Teacher";
            offline.SetActive(false);
            Teacheronline.SetActive(true);
            
        PlayerPrefs.SetString("hosted", checkhost);
        PlayerPrefs.SetString("type", checktype);
        runner.detectTeacher(room);   
    }

    
    public void client()
    {
        Debug.Log("room2");

        checkhost = "Done";
        checktype = "Student";
        
            offline.SetActive(false);
            Teacheronline.SetActive(false);
            
        
        PlayerPrefs.SetString("hosted", checkhost);
        PlayerPrefs.SetString("type", checktype);
        PlayerPrefs.SetInt("play", 0);
        runner.detectStudent(room);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("number", 2);
        Debug.Log("exit");
    }

    public void handraise()
    {
        PlayerPrefs.SetInt("Hand", 1);
        Input.GetKeyDown(KeyCode.Q);
        Debug.Log("Q is pressed");
    }
}
