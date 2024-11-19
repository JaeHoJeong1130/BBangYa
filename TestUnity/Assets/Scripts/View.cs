using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {

    public Camera normalCam;
    public Camera zoomCam;

    private void Start()
    {
        normalCam.enabled = true;
        zoomCam.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            normalCam.enabled = false;
            zoomCam.enabled = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            normalCam.enabled = true;
            zoomCam.enabled = false;
        }
    }
}
