using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class JsonData 
{


}
public class Person
{
    public Person()
    {

    }
    public Person(string json) 
    {
        JsonConvert.PopulateObject(json,this);
    }

    [JsonProperty("ghfvghvgh")]
    public string firstName;
    public int age;
    public int id;


}