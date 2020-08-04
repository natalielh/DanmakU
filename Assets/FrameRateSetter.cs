using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Make the game run at a certain framerate
        Application.targetFrameRate = 60;
        //Application.targetFrameRate = 120;

    }

}
