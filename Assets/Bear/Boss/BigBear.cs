using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBear : MonoBehaviour {

    // Use this for initialization
    public Transform firePoint;
    public GameObject bulletPrefab;
    [Header("射速")]
    public float fireRate = 1f;
    [Header("子弹速度")]
    public int bulletSpeed = 10;
    protected float fireInterval;
    protected float lastFireTime;
    void Start () {
        fireInterval = 1f / fireRate;
    }
	
	// Update is called once per frame
	void Update () {
        Fire();
	}
    public virtual void Fire()
    {
        if (Time.time - lastFireTime > fireInterval)
        {
            lastFireTime = Time.time;
            var go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * bulletSpeed, ForceMode.Impulse);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletSpeed;
        }
    }
}
