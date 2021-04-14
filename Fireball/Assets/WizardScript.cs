using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    GameObject Wizard;
    Rigidbody2D rb;
    Collider2D col;
    Animator ani;
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
            if (scale.x < 0)
            {
                if (ManaPot.mana > 0)
                {
                    ani.SetTrigger("attack");
                    GameObject fireball = Instantiate(Resources.Load("fireballLeft")) as GameObject;
                    fireball.transform.position = new Vector3(Wizard.transform.position.x - 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                    ManaPot.mana -= 1;
                }
            }
            else
            {
                if (ManaPot.mana > 0)
                {
                    ani.SetTrigger("attack");
                    GameObject fireball = Instantiate(Resources.Load("fireball")) as GameObject;
                    fireball.transform.position = new Vector3(Wizard.transform.position.x + 1, Wizard.transform.position.y + 1, Wizard.transform.position.z);
                    ManaPot.mana -= 1;
                }
            }


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) <= .5)
            {
                Vector2 up = new Vector2(0, 1400f * Time.deltaTime);
                rb.AddForce(up, ForceMode2D.Impulse);
            }

        }
        Wizard.transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Zombie_Normal")
        {
            HealthPot.health -= 1;
            if (HealthPot.health > 0)
            {
                ani.SetTrigger("hurt");
                Vector2 up = new Vector2(0, 2500f * Time.deltaTime);
                rb.AddForce(up, ForceMode2D.Impulse);
            }
            else
            {
                ani.SetTrigger("die");
            }
        }
    }
}
