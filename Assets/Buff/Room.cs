using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public Transform room;
    public bool isOn=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isOn==true)
        {
            room.rotation = Quaternion.Lerp(room.rotation,Quaternion.Euler(room.rotation.x,100,room.rotation.y),Time.deltaTime);
        }
	}
}
