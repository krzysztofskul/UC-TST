using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Script : MonoBehaviour
{

    private int clicks = 0;
    GameObject player;
    Camera currentCamera, mainCamera;
    Vector3 clickedPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        //currentCamera = Camera.current;
        currentCamera = getPlayerCamera();
        mainCamera = Camera.main;
        //Debug.Log("currentCamera init.: " + currentCamera.name);
        Debug.Log("mainCamera init.: " + mainCamera.name);

        currentCamera = getCurrentCamera();
        Debug.Log("currentCamera after getCurrentCamera(): " + currentCamera.name);


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

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 1000f)) {
            Debug.Log("Clicked in: " + raycastHit.collider.name + " using RaycastHit!" + 
                " Position registred: " + raycastHit.point
            );

            Debug.DrawLine(player.transform.position, raycastHit.point, Color.red, 1f);
            Debug.DrawRay(player.transform.position, raycastHit.point, Color.yellow, 2f);

        }

    }

    void countClicks() {
        ++clicks;
        print("---- \nClicks registered already: " + clicks);

        if (clicks == 10) {
            Destroy(GameObject.Find("Obstacle2"));
        }

    }

    public static Camera getPlayerCamera() {
        Camera[] cameras = Camera.allCameras;

        foreach (Camera camera in cameras)
        {
            if (camera.name == "PlayerCamera")
            {
                return camera;
            }

        }

        return Camera.main;
    }

}
