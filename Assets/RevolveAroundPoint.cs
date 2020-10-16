using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveAroundPoint : MonoBehaviour
{

    //[Range(-3.0f, 3.0f)]
    //public float speed;

    [Range(-360.0f, 360.0f)]
    public float degreesPerSecond;

    public Vector3 point = new Vector3();

    // Use this for initialization
    void Start()
    {

        //point = new Vector3(0,0,0);

    }

    // Update is called once per frame
    void Update()
    {

        // Spin the object around the specified point at degrees_per_second degrees/second.
        transform.RotateAround(point, Vector3.forward, degreesPerSecond * Time.deltaTime);

    }
}
