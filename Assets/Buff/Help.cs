using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {
    public TextMesh tm;
    BigSkill bigskill;
    // Use this for initialization
    void Start () {
       
        bigskill = FindObjectOfType<BigSkill>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear"))
        {
            if (other.CompareTag("Player"))
            {
                tm.text = "解锁按F可开起电磁屏障";
                Destroy(tm, 2f);
                bigskill.isHave = true;
                Destroy(this.gameObject);
            }
        }

    }
}
