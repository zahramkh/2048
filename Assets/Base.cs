using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public GameObject square;
    public Base(GameObject squarePrefab)
    {
        this.square = squarePrefab;
    }
}
