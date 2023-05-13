using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour 
{ 
    //how far the camera is gonna be away from the player.
    public int offsetConstant = 1;

    //xOffset and zOffset will be the camera's horizontal offset from the target
    private Vector3 xOffset = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 zOffset = new Vector3 (0.0f, 0.0f, 0.0f);

    //pick the target from the inspector
    public Transform target;
    private Vector3 offset;

    //setting the mouse position variables and the rotation points (from dragging mouse)
    private Vector2 lastMousePosition = new Vector2(0.0f, 0.0f);
    public float rotationPoints = 0.0f;

    // Start is called before the first frame update
    void Start() {
        lastMousePosition = Input.mousePosition;
    }

    void UpdateOffsets() {
        //setting these following things:
        //what the mouse position is
        //what the offset beteween where the mouse is and was
        private Vector2 currentMousePosition = Input.mousePosition;
        private Vector2 mouseOffset = currentMousePosition - lastMousePosition;

        //here, we are converting the offset from vector form to float form
        private float changeInX = mouseOffset.x;
        //private float changeInY = mouseOffset.y;

        //so far, rotation points is only gonna affect the xz plane. trig gets complicated otherwise.
        rotationPoints = rotationPoints + changeInX;


        //set the offset. right now, y offset is HARD CODED. 
        offset = new Vector3(Math.Sin(rotationPoints), 2, -Math.Cos(rotationPoints));

        lastMousePosition = currentMousePosition;\2\
    }

    // Update is called once per frame
    void Update() {
        transform.position = target.position + offset;
    }
}
