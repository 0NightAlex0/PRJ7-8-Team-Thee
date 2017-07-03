using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public float LineHeight;
    public float Stroke;
    public float CollisionRange;
    public bool CollideOnY = false;
    public Transform origin;
    public Transform checkpoint;
    public Transform destination;
    private List<Transform> listTransform;

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = Stroke;
        lineRenderer.endWidth = Stroke;
        //last in first out
        listTransform = new List<Transform>(new Transform[] {  destination, checkpoint,  origin });
    }
	
	// Update is called once per frame
	void Update () {

        //set all the input objects in a position
        for(int i = 0; i < listTransform.Count;i++) {
            var newPos = listTransform[i].position;
            newPos.y = LineHeight;
            lineRenderer.SetPosition(i, newPos);
        }
        //if camera is in a certain range of a object, then the current route should be destroyed
        if (InRange(listTransform[listTransform.Count - 1].position, listTransform[listTransform.Count - 2].position, CollisionRange, CollideOnY)  && listTransform.Count >=2)
        {
            Debug.Log("Removing Checkpoint");
            listTransform[listTransform.Count - 2] = listTransform[listTransform.Count - 1];
            listTransform.RemoveAt(listTransform.Count - 1);
            //last in first out
            lineRenderer.SetVertexCount(lineRenderer.positionCount - 1);
        }
    }
    //check if 2 vectors are in a certain range
    bool InRange(Vector3 v1, Vector3 v2, float range, bool evalY) {
        var inX = v1.x <= v2.x + range && v1.x >= v2.x - range;
        Debug.Log(string.Format("[X] point: {0} | lower bound: {1} | upper bound: {2} | in bounds: {3}", v1.x, v2.x - range, v2.x + range, inX));
        var inY = v1.y <= v2.y + range && v1.y >= v2.y - range;
        Debug.Log(string.Format("[Y] point: {0} | lower bound: {1} | upper bound: {2} | in bounds: {3}", v1.y, v2.y - range, v2.y + range, inY));
        var inZ = v1.z <= v2.z + range && v1.z >= v2.z - range;
        Debug.Log(string.Format("[Z] point: {0} | lower bound: {1} | upper bound: {2} | in bounds: {3}", v1.z, v2.z - range, v2.z + range, inZ));
        return inX && (inY || !evalY) && inZ;
    }
}
