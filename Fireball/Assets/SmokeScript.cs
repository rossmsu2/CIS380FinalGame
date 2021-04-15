using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Remove", 3.5f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Remove()
    {
        Destroy(gameObject);
        
    }
}
