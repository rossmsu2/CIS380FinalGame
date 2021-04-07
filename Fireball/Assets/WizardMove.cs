using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardMove : MonoBehaviour
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
        //Vector2 pos = Wizard.transform.position;
        Vector2 scale = Wizard.transform.localScale;
        if (Input.GetKey(KeyCode.A)) {
            ani.SetTrigger("isRun");
            Vector2 left = new Vector2((float) -0.15, 0);
            rb.AddForce(left, ForceMode2D.Impulse);
            //pos.x = pos.x + 3 * Time.deltaTime;
            scale.x = (float) 0.5;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ani.SetTrigger("isRun");
            //pos.x = pos.x - 3 * Time.deltaTime;
            Vector2 right = new Vector2((float) 0.15, 0);
            rb.AddForce(right, ForceMode2D.Impulse);
            scale.x = (float) -0.5;
        }
        if (Input.GetKey(KeyCode.E))
        {
            ani.SetTrigger("isAttack");
        }
        //Wizard.transform.position = pos;
        Wizard.transform.localScale = scale;
    }
}
