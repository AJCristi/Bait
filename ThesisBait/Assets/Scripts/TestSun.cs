using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSun : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, time * Time.deltaTime);
        transform.LookAt(Vector3.zero);       
    }
}
