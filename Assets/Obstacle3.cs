using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3 : MonoBehaviour
{
    public Camera camera;
    Camera camPlayer;
    Vector3 startPosition;
    Color startColor;
    Vector3 newPosition;
    GameObject player;
    Vector3 pos = new Vector3(200, 200, 0);

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startPosition = this.transform.position;
        startColor = this.GetComponent<Renderer>().material.color;
        camera = GetComponent<Camera>();
        camPlayer = Obstacle2Script.getPlayerCamera();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camPlayer.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }

    private void OnMouseDrag()
    {

        if (camPlayer.enabled == true) {

            this.GetComponent<Renderer>().material.color -= Color.white * Time.deltaTime;
            this.GetComponent<Collider>().transform.position = Input.mousePosition;

            RaycastHit raycastHit;

            if (Input.GetMouseButton(0)) {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                Ray ray = camPlayer.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out raycastHit, 100f)) {
                    Debug.DrawLine(player.transform.position, raycastHit.point, Color.cyan, 5f);
                    Debug.DrawRay(player.transform.position, raycastHit.point, Color.magenta, 5f);
                    newPosition = raycastHit.point;
                    newPosition.z = raycastHit.point.z;
                }
            }

        }


    }

    private void OnMouseUp()
    {
        if (camPlayer.enabled == true)
        {
            //this.transform.position = startPosition;
            this.transform.position = newPosition;
            this.GetComponent<Renderer>().material.color = startColor;

        }
    }

}
