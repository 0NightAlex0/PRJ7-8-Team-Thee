using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform destination;
    //test beacon
    //private Vector3 beacon = new Vector3(0.0f, 18.5f, 80f);
    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = .45f;
        lineRenderer.endWidth = 0.45f;

    }
	
	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, destination.position);
    }
}
