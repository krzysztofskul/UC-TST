using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera[] allCameras;

    // Start is called before the first frame update
    void Start()
    {
        allCameras = Camera.allCameras;

        //
        print("Camera controller test ok!");
        print("Found: " + allCameras.Length + " cameras!");
    }

    // Update is called once per frame
    void Update()
    {
        cameraSwitch();
    }

    private void cameraSwitch() {
        if (Input.GetKeyUp(KeyCode.K)) {

            int pointer = 0;

            for (int i = 0; i < allCameras.Length; i++) {
                if (allCameras[i].enabled == true) {
                    pointer = i;
                }
            }

            if (pointer < allCameras.Length - 1)
            {
                allCameras[pointer].enabled = false;
                allCameras[pointer + 1].enabled = true;
            }
            else {
                allCameras[pointer].enabled = false;
                allCameras[0].enabled = true;
                pointer = 0;
            }

        }
    }

}
