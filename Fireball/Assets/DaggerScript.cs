using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    GameObject[] Rogue;
    GameObject[] Daggers;
    // Start is called before the first frame update
    void Start()
    {
        Rogue = GameObject.FindGameObjectsWithTag("Rogue");
        Daggers = GameObject.FindGameObjectsWithTag("Dagger");
        rb = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(-15.0f, 0);
        rb.AddForce(movement, ForceMode2D.Impulse);
        col = GetComponent<Collider2D>();
        InvokeRepeating("Remove", 5.0f, 5.0f);
        foreach (GameObject dagger in Daggers)
        {
            Physics2D.IgnoreCollision(dagger.GetComponent<Collider2D>(), col);
        }
        foreach (GameObject rogue in Rogue)
        {
            Physics2D.IgnoreCollision(rogue.GetComponent<Collider2D>(), col);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
