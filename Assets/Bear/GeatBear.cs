using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeatBear : MonoBehaviour
{

    // Use this for initialization
    float t;
    public GameObject Bear;
    public GameObject[] BearBorn;
   public bool isBear = true;
    void Start()
    {
        BearBorn = GameObject.FindGameObjectsWithTag("BearBorn");
    }

    // Update is called once per frame
    void Update()
    {   t += Time.deltaTime;
        if (isBear==true)
        {    
            if (t > 2)
            {
                t = 0;
                var go = GameObject.Instantiate(Bear, BearBorn[Random.Range(0, BearBorn.Length)].transform.position, Quaternion.identity);

            }
        }           
    }
}
