using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardScript : MonoBehaviour
{
    GameObject Wizard;
    Rigidbody2D rb;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        Wizard = GameObject.Find("Wizard");
        rb = GetComponent<Rigidbody2D>();
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
            Vector2 left = new Vector2((float)-0.08, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
            //pos.x = pos.x + 3 * Time.deltaTime;
            //pos.x = pos.x + left.x * Time.deltaTime;
            //Wizard.transform.position.x = pos.x;
            scale.x = (float)-0.5;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ani.SetTrigger("isRun");
            //pos.x = pos.x - 3 * Time.deltaTime;
            Vector2 right = new Vector2((float)0.08, 0);
            rb.AddForce(right, ForceMode2D.Impulse);
            //pos.x = pos.x + right.x * Time.deltaTime;
            //Wizard.transform.position.x = pos.x;
            scale.x = (float)0.5;
        }
        if (Input.GetKey(KeyCode.E))
        {
            ani.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Mathf.Abs(rb.velocity.y) <= .5)
            {
                Vector2 up = new Vector2(0, 15f);
                rb.AddForce(up, ForceMode2D.Impulse);
            }
            
        }
        //Wizard.transform.position = pos;
        Wizard.transform.localScale = scale;
    }
}
