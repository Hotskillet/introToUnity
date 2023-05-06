using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEyeThink : MonoBehaviour
{   
    //defining some stuff according to the class
    
    //defining an integer called myInt 
    //specifics about public: it affects scope as how i expected it to work.
    //public means we can reference myInt outside of this class
    public int myInt;
    public float speed = 20.0f;
    public float jumpStrength = 10.0f;
    public float rotationStrength = 10.0f;

    //this is defined as a private variable
    //this is because he doesnt want it to show up in inspector
    private Rigidbody rb;

    //defining the position of the mouse 
    private Vector2 lastMousePosition = new Vector2(0.0f, 0.0f);
    //this is how you define a vector 
    //Vector3 coolVector = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    //so everything in void start is called only once
    //functions are named by what they return
    //this function doesnt return anything, so its defined as void
    //if i wanted this to return a number, then it be int Start(par)
    void Start() {
        myInt = 0;
        rb = gameObject.GetComponent<Rigidbody>();
        lastMousePosition = Input.mousePosition;

    }

    void RotateCamera() {
        Vector2 currentMousePosition = Input.mousePosition;
        Vector2 mouseDistance = currentMousePosition - lastMousePosition;

        Vector3 cameraRotation = new Vector3(0.0f, mouseDistance.x * Time.deltaTime, 0.0f);
        transform.Rotate(cameraRotation * rotationStrength);


        lastMousePosition = currentMousePosition;
    }

    // Update is called once per frame
    void Update() {

        Vector3 coolVector = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W)) {
            coolVector += Vector3.forward;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            coolVector -= Vector3.forward;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            coolVector += Vector3.left;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            coolVector += Vector3.right;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        gameObject.transform.Translate(coolVector * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 jumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButton(0)) {
            RotateCamera();
        }
    }
}