using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public TextMesh tm;
    Skill4 skill4;

    // Use this for initialization
    void Start()
    {
        
        skill4 = FindObjectOfType<Skill4>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bear")|| !other.CompareTag("BearMove"))
        {
            if (other.CompareTag("Player"))
            {
                tm.text = "解锁按Q可投射量子团";
                Destroy(tm, 2f);
                skill4.isHave = true;
                Destroy(this.gameObject);
            }
        }

    }
}
