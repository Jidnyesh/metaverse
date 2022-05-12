using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charachterCheck : MonoBehaviour
{
    public GameObject Student;
    public GameObject StudentRIG;
    public GameObject Teacher;
    public GameObject TeacherRIG;
    public Avatar stu;
    public Avatar tea;
    public Animator charach;
    public NetworkCharacterControllerPrototype nt;
    public CharacterController ch;
    public CapsuleCollider Cc;
    public GameObject vis;
    public GameObject host;
    public RuntimeAnimatorController teaAni;
   
    // Start is called before the first frame update
    void Start()

    {
        host = GameObject.FindWithTag("Teacher");
        
        int num = PlayerPrefs.GetInt("number");
        
        if (num == 0)
        {
            //Destroy(Student);
            //Destroy(StudentRIG);
            Debug.Log("number 0");

            Student.transform.SetSiblingIndex(1);
            StudentRIG.transform.SetSiblingIndex(0);
            Teacher.SetActive(false);
            TeacherRIG.SetActive(false);
            Student.SetActive(true);
            StudentRIG.SetActive(true);
            charach.avatar = stu;
            ch.center = new Vector3(0, 1.7f, 0);
            charach.SetInteger("Sit", 1);
            nt.InterpolationTarget = Student.transform;
            //ch.center = new Vector3(0, 2.33f, 0);
            Cc.center = new Vector3(0, 1.7f, 0);
            vis.transform.position = new Vector3(vis.transform.position.x, vis.transform.position.y,vis.transform.position.z);
            //Student.GetComponentInParent<GameObject>().tag = "Student";
            for (int i = 0; i < host.transform.childCount; i++)
            {
                Transform child = host.transform.GetChild(i);
                if (child.tag == "Stu_rig")
                {
                    child.gameObject.SetActive(false);
                    child.SetAsLastSibling();
                }
                else if (child.tag == "Stu_grp")
                {
                    child.gameObject.SetActive(false);
                    child.SetAsLastSibling();
                }
                else if (child.tag == "Tea_grp")
                {
                    child.gameObject.SetActive(true);
                }
                else if (child.tag == "Tea_rig")
                {
                    child.gameObject.SetActive(true);
                }
            }
            host.GetComponent<Animator>().runtimeAnimatorController = teaAni;
            host.GetComponent<Animator>().avatar = tea;
            host.GetComponent<NetworkCharacterControllerPrototype>().InterpolationTarget = Teacher.transform;
            host.GetComponent<CharacterController>().center = new Vector3(0, 1.5f, 0);
            host.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.5f, 0);
            
            

        }
        else if (num == 1)
        {
            //Destroy(Teacher);
            //Destroy(TeacherRIG);
            //charach.SetFloat("Forward", 1);
            Debug.Log("number 1");
            nt.InterpolationTarget = Teacher.transform;
            Student.SetActive(false);
            StudentRIG.SetActive(false);
            Teacher.SetActive(true);
            TeacherRIG.SetActive(true);
            Teacher.transform.SetSiblingIndex(1);
            TeacherRIG.transform.SetSiblingIndex(0);
            charach.avatar = tea;
            ch.center = new Vector3(0, 1.5f, 0);
            Cc.center = new Vector3(0, 1.5f, 0);
            //vis.transform.position = new Vector3(vis.transform.position.x, 2.5f, vis.transform.position.z);
        }
        else if(num == 2)
        {
            PlayerPrefs.SetInt("number", 2);
            Debug.Log("number 2");
            nt.InterpolationTarget = Teacher.transform;
            Student.SetActive(false);
            StudentRIG.SetActive(false);
            Teacher.SetActive(true);
            TeacherRIG.SetActive(true);
            Teacher.transform.SetSiblingIndex(1);
            TeacherRIG.transform.SetSiblingIndex(0);
            charach.avatar = tea;
            ch.center = new Vector3(0, 1.5f, 0);
            Cc.center = new Vector3(0, 1.5f, 0);
            //vis.transform.position = new Vector3(vis.transform.position.x, 1.5f, vis.transform.position.z);
        }

    }

    public void Update()
    {
            
    }
    public void deletehost()
    {
        host.GetComponent<NetworkCharacterControllerPrototype>().InterpolationTarget = Teacher.transform;
        host.GetComponent<CharacterController>().center = new Vector3(0, 1.5f, 0);
        host.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.5f, 0);
        Destroy(Student);
        Destroy(StudentRIG);
        Teacher.SetActive(true);
        TeacherRIG.SetActive(true);

        //host.transform.GetChild(1).gameObject.SetActive(false);

        host.GetComponent<Animator>().avatar = tea;
    }
    // Update is called once per frame
    public void check()
    {
        int num = PlayerPrefs.GetInt("number");
        if (num == 0)
        {
            host.GetComponent<NetworkCharacterControllerPrototype>().InterpolationTarget = Teacher.transform;
            host.GetComponent<CharacterController>().center = new Vector3(0, 1.5f, 0);
            host.GetComponent<CapsuleCollider>().center = new Vector3(0, 1.5f, 0);
            Destroy(host.transform.Find("student").gameObject);
            host.transform.Find("student").gameObject.SetActive(false);
            host.transform.Find("teacher_grp").gameObject.SetActive(true);

            //host.transform.GetChild(1).gameObject.SetActive(false);

            host.GetComponent<Animator>().avatar = tea;


        }
        else if (num == 1)
        {
            //Destroy(Teacher);
            //Destroy(TeacherRIG);
            charach.SetFloat("Forward", 1);

            nt.InterpolationTarget = Teacher.transform;
            Student.SetActive(false);
            StudentRIG.SetActive(false);
            Teacher.transform.SetSiblingIndex(1);
            TeacherRIG.transform.SetSiblingIndex(0);
            charach.avatar = tea;
            ch.center = new Vector3(0, 1.5f, 0);
            Cc.center = new Vector3(0, 1.5f, 0);
            vis.transform.position = new Vector3(vis.transform.position.x, 6f, vis.transform.position.z);

        }
    }

    
}
