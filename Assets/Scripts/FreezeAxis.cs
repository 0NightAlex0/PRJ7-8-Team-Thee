using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeAxis : MonoBehaviour {
    public bool FreezeX;
    public bool FreezeY;
    public bool FreezeZ;
    private Vector3 originPos;

	// Use this for initialization
	void Start () {
	    originPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 newPos = transform.position;
	    if (FreezeX) {
	        newPos.x = originPos.x;
	    }
	    if (FreezeY) {
	        newPos.y = originPos.y;
	    }
	    if (FreezeZ) {
	        newPos.z = originPos.z;
	    }
        transform.position = newPos;
	}
}
