using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementEyeThink : MonoBehaviour
{   
    //defining some stuff according to the class
    
    //defining an integer called myInt 
    //specifics about public: it affects scope as how i expected it to work.
    //public means we can reference myInt outside of this class
    public float speed = 20.0f;
    public float jumpStrength = 10.0f;
    public float rotationStrength = 10.0f;
    public Transform target;
    //this is defined as a private variable
    //this is because he doesnt want it to show up in inspector
    private Rigidbody rb;

    //defining the position of the mouse 
    //private Vector2 lastMousePosition = new Vector2(0.0f, 0.0f);
    //this is how you define a vector 
    //Vector3 coolVector = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    //so everything in void start is called only once
    //functions are named by what they return
    //this function doesnt return anything, so its defined as void
    //if i wanted this to return a number, then it be int Start(par)
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        transform.rotation = target.transform.rotation * Quaternion.Euler(0, 1, 0);
        Debug.Log(transform.rotation);
        
        Vector3 coolVector = new Vector3(0.0f, 0.0f, 0.0f);



        if (Input.GetKey(KeyCode.W)) {
            coolVector += transform.forward;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            coolVector -= transform.forward;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            coolVector -= transform.right;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            coolVector += transform.right;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        gameObject.transform.Translate(coolVector * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 jumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }

        
    }
}