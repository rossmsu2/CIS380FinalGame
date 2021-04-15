using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    GameObject Wizard;
    GameObject Zombie;
    Rigidbody2D rb;
    Animator ani;
    // Start is called before the first frame update

    public bool dead;

    void Start()
    {
        Wizard = GameObject.Find("Wizard");
        Zombie = GameObject.Find("Zombie_Normal");
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Zombie.transform.position;
        Vector2 scale = Zombie.transform.localScale;
        float velocity_magnitude = Mathf.Abs(rb.velocity.x);
        float distance = Mathf.Abs(Wizard.transform.position.x - transform.position.x);
        ani.SetFloat("Speed", velocity_magnitude);
        ani.SetFloat("Dist", distance);
        if(Wizard.transform.position.x + .1 > transform.position.x)
        {
            Vector2 right = new Vector2((float)12.0 * Time.deltaTime, 0);
            rb.AddForce(right, ForceMode2D.Impulse);
            scale.x = (float)0.4;
        }
        else if(Wizard.transform.position.x < transform.position.x + .1)
        {
            Vector2 left = new Vector2((float)-12.0 * Time.deltaTime, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
            scale.x = (float)-0.4;
        }
        if(transform.position.y < -30)
        {
            Destroy(gameObject);
        }
        if(dead == true)
        {
            ani.SetTrigger("die");
            InvokeRepeating("Remove", 1.0f, 1.0f);
        }
        
        transform.localScale = scale;
    }

    void Remove()
    {
        Destroy(gameObject);
    }
}
