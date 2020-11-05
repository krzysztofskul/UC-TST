using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Script : MonoBehaviour
{

    private int clicks = 0;
    Camera currentCamera;
    Vector3 clickedPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = Camera.current;
        currentCamera = getCurrentCamera();
        clickedPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            countClicks();

            showClickPositionUsingScreenToWorldPoint();

            showClickPositionUsingRaycast();



        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked crate using void OnMouseButton()! Position registered: " + this.transform.position);
    }

    Camera getCurrentCamera() {
        Camera[] cameras = Camera.allCameras;
        Camera currentCamera = Camera.current;

        foreach(Camera camera in cameras) {
            if (camera.enabled == true) {
                return camera;
            }
        }

        return currentCamera;
    }

    void showClickPositionUsingScreenToWorldPoint() {

        currentCamera = getCurrentCamera();
        Debug.Log("Camera current: " + currentCamera.name);

        clickedPosition = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Clicked position using ScreenToWorldPoint: " + clickedPosition);
    }

    void showClickPositionUsingRaycast() {

        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(currentCamera.transform.position, Input.mousePosition + new Vector3(0,0,10f), Color.red);

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit)) {
            Debug.Log("Clicked in: " + raycastHit.collider.name + " using RaycastHit!" + 
                " Position registred: " + raycastHit.collider.transform.position
            );

            Debug.DrawRay(currentCamera.transform.position, raycastHit.collider.transform.position, Color.yellow);

        }

    }

    void countClicks() {
        ++clicks;
        print("---- \nClicks registered already: " + clicks);
    }

}
