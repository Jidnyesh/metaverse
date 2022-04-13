using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Fusion;

public class door : MonoBehaviour
{
    public Animator MapDoor;
    public GameObject offline;
    public GameObject Teacheronline;
    public GameObject Studentonline;
    string checkhost;
    string checktype;
    public NetworkDebugStart runner;
    private string room = "123";
    public GameObject HOST;
    public GameObject CLIENT;

    public void Start()
    {
        HOST.SetActive(false);
        CLIENT.SetActive(false);
        if (PlayerPrefs.GetString("hosted") == "NotDone")
        {
            
                Teacheronline.SetActive(false);
                Studentonline.SetActive(false);
                offline.SetActive(true);
            
            
        }
        else if(PlayerPrefs.GetString("hosted") == "Done")
        {
            if(PlayerPrefs.GetString("type") == "Teacher")
            {
                offline.SetActive(false);
                Teacheronline.SetActive(true);
                Studentonline.SetActive(false);
            } else if (PlayerPrefs.GetString("type") == "Student")
            {
                offline.SetActive(false);
                Teacheronline.SetActive(false);
                Studentonline.SetActive(true);
            }
            checkhost = "NotDone";
            PlayerPrefs.SetString("hosted", checkhost);
        }

       
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Teacher")
        {
            HOST.SetActive(true);
        } else if (other.tag == "Student")
        {
            CLIENT.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Teacher")
        {
            HOST.SetActive(false);
        }
        else if (other.tag == "Student")
        {
            CLIENT.SetActive(false);
        }
    }
  
    public void opendoorhost()
    {
        MapDoor.SetInteger("Open", 1);
        Debug.Log("room1");
        Invoke(nameof(starthost), 2.0f);
    }
    
    public void opendoorclient()
    {
        MapDoor.SetInteger("Open", 1);
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
            Teacheronline.SetActive(true);
        
        PlayerPrefs.SetString("hosted", checkhost);
        PlayerPrefs.SetString("type", checktype);
        runner.detectStudent(room);
    }
}
