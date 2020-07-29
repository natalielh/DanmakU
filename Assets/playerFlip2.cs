using UnityEngine;
using System.Collections;

public class playerFlip2 : MonoBehaviour {

	public float playerPos;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = Input.mousePosition;
        Vector2 thisPos = Camera.main.WorldToScreenPoint(transform.position);

        //if (mousePos.x < transform.position.x) {
        if (mousePos.x < thisPos.x)
        {

            GetComponent<SpriteRenderer> ().flipX = true;

		}

		else {

			GetComponent<SpriteRenderer>().flipX = false;
		}


	}
}
