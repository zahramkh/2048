using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JSONExample : MonoBehaviour
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Root
    {
        public List<Student> Students { get; set; }
    }

    void Start()
    {
        //string json = File.ReadAllText(Application.dataPath + "/students.json");

        //var data = JsonConvert.DeserializeObject<Root>(json);

        //foreach (var student in data.Students)
        //{
        //    Debug.Log($"Name: {student.Name}, Age: {student.Age} ");
        //}
    }

   
}