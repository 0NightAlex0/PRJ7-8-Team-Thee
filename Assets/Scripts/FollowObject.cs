using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {
    public GameObject ToFollow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    Vector3 v = new Vector3(ToFollow.transform.position.x, transform.position.y, ToFollow.transform.position.z);

	    transform.LookAt(v);
	}
}
