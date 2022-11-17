using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct Student
{
    public int idStudent;
    public string nameStudent;
}
public class ClassTest : MonoBehaviour
{

    public Student[] stu = new Student[5];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            stu[i].idStudent = i;
            stu[i].nameStudent = "fajar " + i;
        }

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(stu[i].idStudent);
            Debug.Log(stu[i].nameStudent);
        }
    }
}
