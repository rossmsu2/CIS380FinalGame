using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(5.0f, 0);
        rb.AddForce(movement, ForceMode2D.Impulse);
        col = GetComponent<Collider2D>();
        Destroy(gameObject, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Zombie_Normal")
        {
            transform.SetParent(collision.gameObject.transform);
            Destroy(collision.gameObject);
            ManaPot.mana += 1;
        }
        else
        {
            Destroy(gameObject);
            ManaPot.mana += 1;
        }
    }
}
