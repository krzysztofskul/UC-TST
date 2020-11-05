using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // TEST
        //this.GetComponent<Renderer>().material.color = Color.red;

        rigidBody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        moveControl();
        moveControlByForce();
    }

    private void moveControl() {

        float moveUnit = 0.1f;

        if (Input.GetKey(KeyCode.UpArrow)) {
            this.transform.position += new Vector3(0, 0, moveUnit);
            rotate("forward");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position += new Vector3(0, 0, -moveUnit);
            rotate("back");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += new Vector3(-moveUnit, 0, 0);
            rotate("left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(moveUnit, 0, 0);
            rotate("right");
        }

    }

    private void rotate(string direction) {

        float rotationUnit = 10f;

        if ("forward".Equals(direction))
        {
            this.transform.Rotate(new Vector3(rotationUnit, 0, 0));
        }

        if ("back".Equals(direction))
        {
            this.transform.Rotate(new Vector3(-rotationUnit, 0, 0));
        }

        if ("left".Equals(direction))
        {
            this.transform.Rotate(new Vector3(0, 0, rotationUnit));
        }

        if ("right".Equals(direction)) {
            this.transform.Rotate(new Vector3(0, 0, -rotationUnit));
        }
    }

    private void moveControlByForce() {

        float forceUnit = 5f;

        if (Input.GetKey(KeyCode.W)) {
            rigidBody.AddForce(new Vector3(0, 0, forceUnit), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidBody.AddForce(new Vector3(-forceUnit, 0, 0), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddForce(new Vector3(forceUnit, 0, 0), ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidBody.AddForce(new Vector3(0, 0, -forceUnit), ForceMode.Force);
        }
    }

}
