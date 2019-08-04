using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragMove : MonoBehaviour
{
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private Vector3 newCamera;
    private bool Drag = false;

    public CreateStars world; 

    void Start()
    {
        ResetCamera = Camera.main.transform.position;
    }
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            newCamera = Origin - Diference;
            newCamera.x = Mathf.Clamp(newCamera.x, world.height/-2, world.height/2);
            newCamera.y = Mathf.Clamp(newCamera.y, world.width / -2, world.width / 2);

            Camera.main.transform.position = newCamera;

        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = ResetCamera;
        }
    }
}