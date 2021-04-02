using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject wizard;
    GameObject camera;
    Vector3 wizardPos;
    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.Find("Wizard");
        camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        wizardPos = wizard.transform.position;
        wizardPos.z = -10;
        camera.transform.position = wizardPos;
    }
}
