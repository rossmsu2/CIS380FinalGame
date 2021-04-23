using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    GameObject wizard;
    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.Find("Wizard");
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0.0f, 1000.0f) < 3.0f && wizard.transform.position.x < 250)
        {
            GameObject zombie = Instantiate(Resources.Load("Zombie_Normal")) as GameObject;
            zombie.transform.position =
                   new Vector3(Random.Range(wizard.transform.position.x + 17, 230), Random.Range(wizard.transform.position.y - 10, wizard.transform.position.y + 5), wizard.transform.position.z);
        }
    }
}