using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public Transform origin;
    public Transform checkpoint;
    public Transform destination;
    private List<Transform> listTransform;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = .45f;
        lineRenderer.endWidth = 0.45f;
        //last in first out
        listTransform = new List<Transform>(new Transform[] {  destination, checkpoint,  origin });
    }
	
	// Update is called once per frame
	void Update () {


        for(int i = 0; i < listTransform.Count;i++)
        {
            lineRenderer.SetPosition(i, listTransform[i].position);
        }
        if (listTransform[listTransform.Count-1].position == listTransform[listTransform.Count - 2].position && listTransform.Count >=2)
        {
            listTransform[listTransform.Count - 2] = listTransform[listTransform.Count - 1];
            listTransform.RemoveAt(listTransform.Count - 1);
            lineRenderer.SetVertexCount(lineRenderer.positionCount - 1);
        }



    }
}
