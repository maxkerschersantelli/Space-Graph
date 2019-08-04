using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStars : MonoBehaviour
{
    public GameObject node;
    public int width;
    public int height;
    public int starCount;
    public int distanceBetweenStars;

    void Start()
    {
        GameObject newStar;
        for (int x = 0; x < starCount; x++)
        {
            newStar = Instantiate(node, this.transform);
            newStar.transform.position = new Vector3(Random.Range(width/-2, width), Random.Range(height/-2, height), 0) ;
        }

        foreach (Transform child in transform)
        {
            foreach (Transform child2 in transform)
            {
                if(Vector3.Distance(child.position, child2.position) < distanceBetweenStars){
                    child.GetComponent<StarBehavior>().neighbors.Add(child2.gameObject);
                    child2.GetComponent<StarBehavior>().neighbors.Add(child.gameObject);
                }
            }
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<StarBehavior>().DrawNeighbors();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
