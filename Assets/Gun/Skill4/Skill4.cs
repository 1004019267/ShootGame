using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int bulletSpeed = 10;
    public bool isHave = false;
    float t = 5;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
                 
            if (Input.GetKeyDown(KeyCode.Q) && t >= 5&& isHave == true)
            {
                var go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                go.GetComponent<Rigidbody>().AddForce(go.transform.forward * bulletSpeed, ForceMode.Impulse);
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletSpeed;
                t = 0;
            }
    }
}
