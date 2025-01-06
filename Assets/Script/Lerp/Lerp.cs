using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    private Vector3 endPos=new Vector3(7,0,0);
    private Vector3 Starpos;
    private float holeTime=3f;
    // Start is called before the first frame update
    void Start()
    {

        Starpos=transform.position;
        StartCoroutine(moveOver(Starpos, endPos, holeTime));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator moveOver(Vector3 start, Vector3 end,float HoleTime )
    {
        float pased = 0f;

        while (pased < HoleTime)
        {
            pased += Time.deltaTime;
             float t = pased / holeTime;

            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }
}
