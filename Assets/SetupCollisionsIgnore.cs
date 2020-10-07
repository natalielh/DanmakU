using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupCollisionsIgnore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(8, 9);
        Physics.IgnoreLayerCollision(9, 10);
        Physics.IgnoreLayerCollision(9, 11);
    }

}
