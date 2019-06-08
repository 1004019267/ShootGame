using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            if (other.CompareTag("Bear"))
            {
                other.GetComponent<Bear>().Hurt(3);
            }
            if (other.CompareTag("BearBoss"))
            {
                other.GetComponent<BearMove>().Hurt(3);
            }
        }
    }
}
