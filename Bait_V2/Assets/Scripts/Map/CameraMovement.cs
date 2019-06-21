using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;

    public float minZoom, maxZoom;

    public float scrollSpeed;

    Vector3 zoom;
    private void Start()
    {
        
    }

    void Update()
    {
        //Add Borders

        Zoom();

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(dragOrigin - Input.mousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);           
       
    }

    void Zoom()
    {
        zoom = transform.position;
        

        if (zoom.y < minZoom)
        {
            Debug.Log("Min");
            zoom.y = minZoom;
            //transform.position = zoom;
        }

        if (zoom.y > maxZoom)
        {
            Debug.Log("Max");
            zoom.y = maxZoom;
            //transform.position = zoom;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKey(KeyCode.Alpha2))
        {
            if (zoom.y < maxZoom)
            {
                transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKey(KeyCode.Alpha1))
        {
            if (zoom.y > minZoom)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed);
            }
        }

        
    }
}
