using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    GameObject Wizard;
    Rigidbody2D rb;
    Collider2D col;
    Animator ani;
    public static bool InputEnabled = true;
    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        Wizard = GameObject.Find("Wizard");
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Wizard.transform.position;
        Vector2 scale = Wizard.transform.localScale;
        float velocity_magnitude = Mathf.Abs(rb.velocity.x);
        float jumping_magnitude = Mathf.Abs(rb.velocity.y);
        ani.SetFloat("speed", velocity_magnitude);
        ani.SetFloat("jump", jumping_magnitude);


        if(InputEnabled == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ani.SetTrigger("isRun");
                Vector2 left = new Vector2((float)-32.0 * Time.deltaTime, 0);
                rb.AddForce(left, ForceMode2D.Impulse);
                scale.x = (float)-0.5;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                ani.SetTrigger("isRun");
                Vector2 right = new Vector2((float)32.0 * Time.deltaTime, 0);
                rb.AddForce(right, ForceMode2D.Impulse);
                scale.x = (float)0.5;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ani.SetTrigger("attack");
                if (scale.x < 0)
                {
                    if (ManaPot.mana > 0)
                    {
                        
                        GameObject fireball = Instantiate(Resources.Load("fireballLeft")) as GameObject;
                        fireball.transform.position = new Vector3(Wizard.transform.position.x - 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                        ManaPot.mana -= 1;
                    }
                    else
                    {
                        GameObject smoke = Instantiate(Resources.Load("SmokePuff")) as GameObject;
                        smoke.transform.position = new Vector3(Wizard.transform.position.x - 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                    }
                }
                else
                {
                    if (ManaPot.mana > 0)
                    {
                        
                        GameObject fireball = Instantiate(Resources.Load("fireball")) as GameObject;
                        fireball.transform.position = new Vector3(Wizard.transform.position.x + 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                        ManaPot.mana -= 1;
                    }
                    else
                    {
                        GameObject smoke = Instantiate(Resources.Load("SmokePuff")) as GameObject;
                        smoke.transform.position = new Vector3(Wizard.transform.position.x + 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                    }
                }


            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Mathf.Abs(rb.velocity.y) <= .5)
                {
                    float jump = 16f;
                    //Vector2 up = new Vector2(0, 1400f * Time.deltaTime);
                    //rb.AddForce(up, ForceMode2D.Impulse);
                    rb.velocity = Vector2.up * jump + rb.velocity;
                }

            }
        }
        

        if(Wizard.transform.position.x >= 295 && win == false)
        {
           ani.SetTrigger("lookUp");
           InputEnabled = false;
            InvokeRepeating("Win", 2.0f, 2.0f);
            win = true;
        }
        Wizard.transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie" || collision.gameObject.tag == "Rogue")
        {
            if (HealthPot.health > 1)
            {
                ani.SetTrigger("hurt");
                Vector2 up = new Vector2(0, 45f);
                rb.AddForce(up, ForceMode2D.Impulse);
                HealthPot.health -= 1;
            }
            else
            {
                ani.SetTrigger("die");
                InputEnabled = false;
            }
        }
        if (collision.gameObject.tag == "Dagger") {
            if (HealthPot.health > 1)
            {
                ani.SetTrigger("hurt");
                Vector2 back = new Vector2(-20f, 0);
                rb.AddForce(back, ForceMode2D.Impulse);
                HealthPot.health -= 1;
            }
            else
            {
                ani.SetTrigger("die");
                InputEnabled = false;
            }
        }
    }

    void Win()
    {
        int direction = Random.Range(0, 2);
        Vector2 scale = Wizard.transform.localScale;
        if (direction == 0)
        {
            scale.x = (float)-0.5;
        }
        else if(direction == 1)
        {
            scale.x = (float)0.5;
        }
        int action = Random.Range(0, 3);
        if(action == 0)
        {
            if (Mathf.Abs(rb.velocity.y) <= .5)
            {
                float jump = 16f;
                rb.velocity = Vector2.up * jump + rb.velocity;
            }
        }
        else if(action == 1)
        {
            ani.SetTrigger("attack");
        }
        else
        {
            ani.SetTrigger("lookUp");
        }


        Wizard.transform.localScale = scale;

    }
}
