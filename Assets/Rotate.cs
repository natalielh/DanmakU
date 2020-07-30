using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //[Range(-20.0f, 20.0f)]
    //public float x_degrees_per_second;

    //[Range(-20.0f, 20.0f)]
    //public float y_degrees_per_second;

    //[Range(-20.0f, 20.0f)]
    //public float z_degrees_per_second;

    /*
        In this Vector3,
        x is the angles per second rotation around the x-axis
        y is the angles per second rotation around the y-axis
        z is the angles per second rotation around the z-axis
    */

    public Vector3 rotation_speed = new Vector3();



    // Use this for initialization
    void Start()
    {

        //rotation_speed = new Vector3();

    }

    // Update is called once per frame
    void Update()
    {

        //// Rotate the object around World's X axis at x_degrees_per_second degrees/second
        //transform.Rotate(Vector3.right * Time.deltaTime);

        //// ...also rotate around the World's Y axis
        //transform.Rotate(Vector3.up * Time.deltaTime, Space.World);

        transform.Rotate(rotation_speed * Time.deltaTime, Space.Self);

    }

}
