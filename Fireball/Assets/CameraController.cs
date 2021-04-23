using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject wizard;
    GameObject camera;
    GameObject rogue;
    Vector3 wizardPos;
    AudioSource audio;
    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.Find("Wizard");
        camera = GameObject.Find("Camera");
        audio = GetComponent<AudioSource>();
        rogue = GameObject.Find("RogueBoss");
    }

    // Update is called once per frame
    void Update()
    {
        wizardPos = wizard.transform.position;
        wizardPos.z = -10;
        wizardPos.y = wizardPos.y + 1;
        camera.transform.position = wizardPos;

        if(audio.clip == clip1)
        {
            if (wizard.transform.position.x >= 215)
            {
                audio.clip = clip2;
                audio.Play();
            }
        }
        if(wizard.transform.position.x >= 275 && done == false)
        {
            done = true;
            audio.clip = clip3;
            audio.Play();
        }

        

    }
}
