using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    public List<GameObject> neighbors = new List<GameObject>();
    LineRenderer lineRenderer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawNeighbors(){
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = neighbors.Count * 2;

        for (int i = 0; i < neighbors.Count; i++){
            lineRenderer.SetPosition((i * 2), transform.position);
            lineRenderer.SetPosition((i * 2) + 1, neighbors[i].transform.position);
            lineRenderer.useWorldSpace = true;
        }
    }
}
