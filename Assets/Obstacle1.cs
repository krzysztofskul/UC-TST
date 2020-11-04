using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Renderer>().material.color = getrandomColor();

        turnOffCanvas();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Color getrandomColor() {
        return new Color(
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f),
                UnityEngine.Random.Range(0f, 1f)
            );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player") {
            this.GetComponent<Renderer>().material.color = getrandomColor();
            turnOnCanvas();
        }
    }

    private void turnOffCanvas() {
            canvas.enabled = false;
    }

    private void turnOnCanvas() {
        canvas.enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            turnOffCanvas();

        }
    }

}
