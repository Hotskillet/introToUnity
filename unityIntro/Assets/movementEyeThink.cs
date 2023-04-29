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

    // Start is called before the first frame update
    //so everything in void start is called only once
    //functions are named by what they return
    //this function doesnt return anything, so its defined as void
    //if i wanted this to return a number, then it be int Start(par)
    void Start() {
        myInt = 0;
    }

    // Update is called once per frame
    void Update() {
        myInt = myInt + 1;
        Debug.Log(myInt);
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
    }
}