using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform checkpoint;
    public Transform destination;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = .45f;
        lineRenderer.endWidth = 0.45f;

    }
	
	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, checkpoint.position);
        lineRenderer.SetPosition(2, destination.position);
    }
}
