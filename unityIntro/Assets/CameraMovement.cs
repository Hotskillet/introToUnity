using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{ 
    //how far the camera is gonna be away from the player.
    public float offsetDistanceConstant = 1.0f;

    //xOffset and zOffset will be the camera's horizontal offset from the target
    //commented the following 2 lines in favor of writing directly to one offset vector
    //private Vector3 xOffset = new Vector3(0.0f, 0.0f, 0.0f);
    //private Vector3 zOffset = new Vector3 (0.0f, 0.0f, 0.0f);

    //pick the target from the inspector
    public Transform target;
    private Vector3 offset = new Vector3(0.0f, 0.5f, 1.0f);

    //setting the mouse position variables and the rotation points (from dragging mouse)
    //flat rotation points will count the cumulative mouse drag (horizontally)
    private Vector2 lastMousePosition = new Vector2(0.0f, 0.0f);
    public float flatRotationPoints = 0.0f;

    // Start is called before the first frame update
    void Start() {
        lastMousePosition = Input.mousePosition;
    }

    //first, we convert it from radians to degrees by multiplying by 180 and dividing by pi
    //after that, we divide by some denom argument to make it smaller
    //aaaand i just rrealized this function isnt usable because functions take stuff by radians lol
    float ConvertToSmallDegrees(float radianMeasurement, float denom) {
        return ((radianMeasurement * 180) / Mathf.PI) / denom;
    }

    //this function is for checking the movement of the mouse 
    //tracks the difference between where mouse is and was,
    //uses this offset to change where the camera is using trig
    void UpdateOffsets() {


        //setting these following things0:
        //what the mouse position is
        //what the offset beteween where the mouse is and was
        Vector2 currentMousePosition = Input.mousePosition;
        Vector2 mouseOffset = currentMousePosition - lastMousePosition;



        //here, we are converting the offset from vector form to float form
        float changeInX = -mouseOffset.x;
        float changeInY = -mouseOffset.y;

        //so far, rotation points is only gonna affect the xz plane. trig gets complicated otherwise.
        flatRotationPoints += changeInX;


        //convert it using ConvertToSmallDegrees nvm dont i just realized its not doable
        float usableRotationPoints = flatRotationPoints * Mathf.PI / 100;

        //set the offset. right now, y offset is HARD CODED. 
        offset = new Vector3(Mathf.Sin(usableRotationPoints), 0.5f, -Mathf.Cos(usableRotationPoints));
        transform.rotation = Quaternion.Euler(Vector3.down * usableRotationPoints * 180 / Mathf.PI + Vector3.right * 10);

        //update at the end now that we did all the stuff
        //that way, we keep iterating and refreshing
        lastMousePosition = currentMousePosition;
        //mousePosition = lastMousePosition;
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            UpdateOffsets();
        }
        transform.position = target.position + (offset * offsetDistanceConstant);
    }
}
