using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2_1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation *= Quaternion.Euler(0, transform.position.y * 3, 0);
    }
}
