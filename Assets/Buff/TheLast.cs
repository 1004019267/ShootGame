using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLast : MonoBehaviour {
     GameObject tm;
    NewSkill3 newskill3;   
    // Use this for initialization
    void Start () {
        newskill3 = FindObjectOfType<NewSkill3>();
        tm = GameObject.Find("Fire (4)");
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear") || !other.CompareTag("BearMove"))
        {
            if (other.CompareTag("Player"))
            {
                tm.GetComponent<TextMesh>().text = "发现时空跃迁,按E进行牵引";
                Destroy(tm, 2f); 
                newskill3.isOn=true;
                Destroy(this.gameObject);
            }
        }

    }
}
