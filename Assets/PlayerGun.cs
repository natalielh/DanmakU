using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    //https://www.gamedevelopment.blog/unity-2d-game-tutorial-2019-bullets/

    public GameObject bulletPrefab;     // the prefab of our bullet

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            // if the player pressed left mouse button
            GameObject go = Instantiate(bulletPrefab, gameObject.transform);
            PlayerBullet bullet = go.GetComponent<PlayerBullet>();
            //bullet.targetVector = new Vector3(1, 1, 0);
            bullet.targetVector = transform.right;
        }
    }
}
