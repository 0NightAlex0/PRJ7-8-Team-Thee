using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public float Stroke;
    public float LineHeight;
    public Transform origin;
    public Transform checkpoint;
    public Transform destination;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = Stroke;
        lineRenderer.endWidth = Stroke;

    }
	
	// Update is called once per frame
	void Update () {
        lineRenderer.SetPosition(0, getAdjustedVector(origin.position));
        lineRenderer.SetPosition(1, getAdjustedVector(checkpoint.position));
        lineRenderer.SetPosition(2, getAdjustedVector(destination.position));
    }

    Vector3 getAdjustedVector(Vector3 v) {
        var newPos = v;
        newPos.y = LineHeight;
        return newPos;
    }
}
