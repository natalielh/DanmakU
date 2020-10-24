using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public Transform transformToLookAt;

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(transformToLookAt, Vector3.forward);

        Vector2 direction = transformToLookAt.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}
