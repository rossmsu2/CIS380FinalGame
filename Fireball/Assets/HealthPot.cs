using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    GameObject wizard;
    GameObject potion;
    Vector3 wizardPos;
    public static int health;
    public Sprite[] Health;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.Find("Wizard");
        potion = GameObject.Find("HealthPot");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        wizardPos = wizard.transform.position;
        wizardPos.x = wizardPos.x - 0.5f;
        wizardPos.y = wizardPos.y + 3;
        potion.transform.position = wizardPos;
        ChangeSprite();
    }

    void ChangeSprite() {
        spriteRenderer.sprite = Health[health - 1];
    }
}
