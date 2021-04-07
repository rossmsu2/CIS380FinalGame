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
        ani.SetFloat("Speed", velocity_magnitude);
        if(Wizard.transform.position.x + .1 > Zombie.transform.position.x)
        {
            Vector2 right = new Vector2((float)0.03, 0);
            rb.AddForce(right, ForceMode2D.Impulse);
            scale.x = (float)0.5;
        }
        else if(Wizard.transform.position.x < Zombie.transform.position.x + .1)
        {
            Vector2 left = new Vector2((float)-0.03, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
            scale.x = (float)-0.5;
        }
        
        Zombie.transform.localScale = scale;
    }
}
