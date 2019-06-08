using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btter2 : MonoBehaviour {   
    static int count;
    public int damage = 1;
    // Use this for initialization
    void Start () {
        Destroy(gameObject, 3f);
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
                other.GetComponent<Bear>().Hurt(damage);
            }
            if (other.CompareTag("BearBoss"))
            {
                other.GetComponent<BearMove>().Hurt(damage);
            }
        }      
    }
}
