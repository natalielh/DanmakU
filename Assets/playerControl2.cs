using UnityEngine;
using System.Collections;

public class playerControl2 : MonoBehaviour {

    public GameObject cam;
    //public Camera camera;

    public float currentSpeed = 8.0f;
    public float fullSpeed = 8.0f;
    public float slowSpeed = 3.0f;
    public float speed = 8.0f;

    float rotSpeed = 100.0f;

    bool camToggleOn = false;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        //camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        //var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        //transform.position += move * speed * Time.deltaTime;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = slowSpeed;
            print("lshift was pressed");
        }
        else
        {
            currentSpeed = fullSpeed;
        }


        if (Input.GetKeyDown(KeyCode.Space) && !camToggleOn) {
            cam.transform.Translate(Vector2.up * 4, Space.Self);
            camToggleOn = true;
            print("space key was pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && camToggleOn) {
            cam.transform.Translate(Vector2.up * -4, Space.Self);
            camToggleOn = false;
            print("space key was pressed");
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxisRaw("Vertical");
        //Get the value of the Vertical input axis.

        int toRot = 0;
        if (Input.GetKey(KeyCode.E)) { toRot = -1; }
        if (Input.GetKey(KeyCode.Q)) { toRot = 1; }

        transform.Rotate(0, 0, toRot * rotSpeed * Time.deltaTime, Space.Self);

        Vector2 toMove = new Vector2(horizontalInput, verticalInput);
        toMove.Normalize();

        //transform.Translate(new Vector2(horizontalInput, verticalInput) * currentSpeed * Time.deltaTime, Space.Self);
        transform.Translate(new Vector2(toMove.x, toMove.y) * currentSpeed * Time.deltaTime, Space.Self);

        //rb.MovePosition(rb.position + toMove * currentSpeed * Time.deltaTime);

    }



    void FixedUpdate()
    {
        
    }



}
