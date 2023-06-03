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

    //predefining some direction vectors to replace transform.whatever
    private Vector3 rightVector;
    private Vector3 backVector;
    private Vector3 leftVector;
    private Vector3 frontVector;
    private Vector3 diffVector;


    // Start is called before the first frame update
    //so everything in void start is called only once
    //functions are named by what they return
    //this function doesnt return anything, so its defined as void
    //if i wanted this to return a number, then it be int Start(par)
    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    //the purpose of this function is to give rotated vectors
    //you would input a vector3, and it outputs a rotated vector3
    //uses normal vector knowledge to do it   
    Vector3 giveRotationVector(Vector3 goop, string rotat) {

        //defining a thing vector
        //maybe not the best idea? mightve been able to juust return newv Vector3
        //oh well

        Vector3 thing = new Vector3(0, 0, 0);

        //switch statement for which rotation direction
        //directions are relative to the goop vector, which we treat as "forward"
        switch (rotat) {
            case "right":
                thing = new Vector3(goop.z, 0, -goop.x);
                break;
            case "left":
                thing = new Vector3(-goop.z, 0, goop.x);
                break;
            case "backward":
                thing = new Vector3(-goop.x, 0, -goop.z);
                break;
        }
        return thing;
    }

    //this function will make produce the replacements for transform.whatever
    void makeTurnVectors() {

        //we get the difference in position between the camera and the player
        //player is meant to be stuck moving on the xz plane
        //so thus we multiply by (1, 0, 1) to take out the y

        diffVector = Vector3.Scale((transform.position - target.transform.position), new Vector3(1, 0, 1));
        
        //now we normalize so that our step size is 1. 
        //this is also why we took out y, so that it wouldnt interfere with normaliziation.
        backVector = (Vector3.Normalize(diffVector));

        //for some reason, backVector is our left instead of our backwards. 
        //so now we gotta rotate it left. baffles me why to be honest.

        backVector = giveRotationVector(backVector, "left");
        

        frontVector = giveRotationVector(backVector, "backward");
        rightVector = giveRotationVector(frontVector, "right");
        leftVector = giveRotationVector(frontVector, "left");
        
    }

    
    // Update is called once per frame
    void Update() {
        
        Vector3 coolVector = new Vector3(0.0f, 0.0f, 0.0f);

        makeTurnVectors();

        if (Input.GetKey(KeyCode.W)) {
            coolVector += frontVector;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S)) {
            coolVector += backVector;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)) {
            coolVector += leftVector;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D)) {
            coolVector += rightVector;
            //gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        gameObject.transform.Translate(coolVector * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 jumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }

        
    }
}