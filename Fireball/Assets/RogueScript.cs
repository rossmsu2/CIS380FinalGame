using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueScript : MonoBehaviour
{
    GameObject Rogue;
    Rigidbody2D rb;
    Collider2D col;
    Animator ani;
    public static int health;
    public bool dead;

    // Start is called before the first frame update
    void Start()
    {
        Rogue = GameObject.Find("RogueBoss");
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        health = 5;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Daggers = GameObject.FindGameObjectsWithTag("Dagger");
        Vector2 pos = Rogue.transform.position;
        if (Random.Range(0.0f, 1000.0f) < 10.0f && pos.y < 8.5 && dead == false)
        {
            float jump = 18f;
            rb.velocity = Vector2.up * jump + rb.velocity;
        }
        if (Random.Range(0.0f, 1000.0f) < 2.0f && dead == false) {
            if(Daggers.Length <= 5)
            {
                ani.SetTrigger("attack");
                GameObject dagger = Instantiate(Resources.Load("RogueWeapon")) as GameObject;
                dagger.transform.position = new Vector3(Rogue.transform.position.x - 2, Rogue.transform.position.y + 2, Rogue.transform.position.z);
            }
            
        }
        if (dead == true)
        {
            ani.SetTrigger("die");
            InvokeRepeating("Remove", 1.0f, 1.0f);
        }
        pos = Rogue.transform.position;
        pos.x = 256;
        Rogue.transform.position = pos;
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
