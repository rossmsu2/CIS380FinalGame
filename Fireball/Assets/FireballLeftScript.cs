using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLeftScript : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D col;
    GameObject Wizard;
    GameObject[] Balls;
    // Start is called before the first frame update
    void Start()
    {
        Wizard = GameObject.Find("Wizard");
        Balls = GameObject.FindGameObjectsWithTag("FireBall");
        rb = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(-5.0f, 0);
        rb.AddForce(movement, ForceMode2D.Impulse);
        col = GetComponent<Collider2D>();
        InvokeRepeating("Remove", 5.0f, 5.0f);
        Physics2D.IgnoreCollision(Wizard.GetComponent<Collider2D>(), col);
        foreach (GameObject ball in Balls)
        {
            Physics2D.IgnoreCollision(ball.GetComponent<Collider2D>(), col);
        }
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

    void Remove()
    {
        Destroy(gameObject);
        ManaPot.mana += 1;
    }
}
