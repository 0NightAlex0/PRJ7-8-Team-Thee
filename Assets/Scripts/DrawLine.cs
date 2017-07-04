using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;

    public float LineHeight;
    public float Stroke;
    public float CollisionRange;
    public bool CollideOnY = false;
    public Transform origin;
    public Transform destination;
    private List<Transform> listTransform = new List<Transform>();

    // Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = Stroke;
        lineRenderer.endWidth = Stroke;
        //first in last out
        var checkpoints = FindAllCheckpoints();
        var checkpointTransforms = checkpoints.Select(x => x.transform).ToArray();

        listTransform.Add(origin);
        listTransform.AddRange(checkpointTransforms);
        listTransform.Add(destination);

        lineRenderer.positionCount = listTransform.Count;
    }
	
	// Update is called once per frame
	void Update () {
        //set all the input objects in a position
		for(var i = 0; i < listTransform.Count;i++) {        
			var newPos = listTransform[i].position;
            newPos.y = LineHeight;
            lineRenderer.SetPosition(i, newPos);
        }

        if (!(listTransform.Count >= 2))
            return;

        if (InRange(listTransform[0].position, listTransform[1].position,
	            CollisionRange, CollideOnY)) {
	        listTransform.RemoveAt(1);
	        //first in last out
	        lineRenderer.positionCount = lineRenderer.positionCount - 1;
	    }
	}

    bool InRange(Vector3 v1, Vector3 v2, float range, bool evalY) {
        var inX = v1.x <= v2.x + range && v1.x >= v2.x - range;
        var inY = v1.y <= v2.y + range && v1.y >= v2.y - range;
        var inZ = v1.z <= v2.z + range && v1.z >= v2.z - range;
        return inX && (inY || !evalY) && inZ;
    }

    GameObject[] FindAllCheckpoints() {
        var checks = new List<GameObject>();
        for (var i = 0; i < int.MaxValue; i++) {
            var check = GameObject.Find("Checkpoint" + i);
            if (check == null)
                break;
            checks.Add(check);
        }
        return checks.ToArray();
    }
}
