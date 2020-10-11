using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnPress : MonoBehaviour
{

    public float delay = 0;
    private bool keyPressed = false;

    public int sceneToLoad;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            keyPressed = true;
            
        }

        if (keyPressed) {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }


    }
}
