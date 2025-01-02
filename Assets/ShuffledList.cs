using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleStrings : MonoBehaviour
{
    List<string> names = new List<string> { "Ali", "Mohammad", "Hossein", "Sajad", "Majid", "Yasin", "Zara" };
    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
    void ShuffleListName(List<string> inputList)
    {
        for (int i = inputList.Count - 1; i > 0; i--) 
        {
            int randomIndex = Random.Range(0, i + 1); 
            string temp = inputList[i];
            inputList[i] = inputList[randomIndex];
            inputList[randomIndex] = temp;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Before  => " + string.Join(", ", names));
            ShuffleListName(names);
            Debug.Log("After  => " + string.Join(", ", names));
            Debug.Log("--------------------------------------");
            Debug.Log("Before  => " + string.Join(", ", numbers));
            ShuffleListNumber(numbers);
            Debug.Log("After  => " + string.Join(", ", numbers));
        }

    }

    void ShuffleListNumber(List<int> inputList)
    {
        for (int i = inputList.Count - 1; i >=0 ; i--) 
        {
            int randomIndex = Random.Range(0, i + 1); 
            int temp = inputList[i];
            inputList[i] = inputList[randomIndex];
            inputList[randomIndex] = temp;
        }
    }
}