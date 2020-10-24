using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObj : MonoBehaviour
{

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Use this one for FX
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //This one works when FX is not used
        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //transform.LookAt(mousePos); //only works for 3d

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

    }
}
