using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    //defiining some player stuff
    //includes player speed

    
    public float playerSpeedFactor = 1.0f;
    public float playerJumpPowerFactor = 10.0f;
    
    //intiating layer detection and declaring the rigidbody of the player
    private int layerMask;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //defining rigidbody and layer here. not sure why.
        rb = gameObject.GetComponent<Rigidbody2D>();
        layerMask = LayerMask.GetMask("Ground");
    }
    
    bool isGrounded() {
        
        //cast out rays to detect collision.

        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = Vector2.down;
        float distance = 0.7f;
        return Physics2D.Raycast(origin, direction, distance, layerMask);
        
    }

    // Update is called once per frame
    void Update() 
    {

        //set baseline  vector for x direction

        
        Vector3 coolerVector = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.D)) {
            coolerVector += new Vector3(1.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.A)) {
            coolerVector -= new Vector3(1.0f, 0.0f, 0.0f);
        }

            
        transform.position += coolerVector * Time.deltaTime * playerSpeedFactor;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded()) {
            Vector2 jumpForce = new Vector2(0.0f, 1*playerJumpPowerFactor);
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
