using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {  
   public TextMesh tm;
	// Use this for initialization   
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear")&& !other.CompareTag("BearBoss"))
        {
            if (other.CompareTag("Player"))
            {
                tm.text = "解锁按2可更换不稳定量子";
                Destroy(tm, 2f);
                other.GetComponent<Player>().FireSkill();
                Destroy(this.gameObject);
            }
        }
        
    }

}
