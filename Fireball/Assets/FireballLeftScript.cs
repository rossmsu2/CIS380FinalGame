using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLeftScript : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-4.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
