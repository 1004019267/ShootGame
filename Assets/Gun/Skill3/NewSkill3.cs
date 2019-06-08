using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSkill3 : MonoBehaviour
{
    
    public float moveDistance = 9.7f;
    int layermask;
    public bool isOn = false;
    float t = 5;
    // Use this for initialization
    void Start()
    {
        layermask = 1 << LayerMask.NameToLayer("Mouse");
    }

    // Update is called once per frame
    void Update()
    {      
        release();
    }
    void release()
    {
        t += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E) && isOn == true && t >= 5)
        {         
            t = 0;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;           
            if (Physics.Raycast(ray, out hit, moveDistance, layermask))
            {             
                 Vector3 hitPos = hit.point;
                Vector3 playerPos = transform.position;
               Vector3 dir = (hitPos - playerPos);
                dir = dir.normalized;
                Vector3 targetPos = hit.point-dir ;              
                transform.position = targetPos;
                }            
            else
            {
                Vector3 playerPos = transform.forward * (moveDistance-2) + transform.position;                   transform.position = playerPos;
            }
        }


    }
}
