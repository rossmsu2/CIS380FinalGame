using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPot : MonoBehaviour
{
    GameObject wizard;
    GameObject potion;
    Vector3 wizardPos;
    public static int mana;
    public Sprite[] Mana;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        wizard = GameObject.Find("Wizard");
        potion = GameObject.Find("ManaPot");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mana = 1;
    }

    // Update is called once per frame
    void Update()
    {
        wizardPos = wizard.transform.position;
        wizardPos.x = wizardPos.x + 0.5f;
        wizardPos.y = wizardPos.y + 3;
        potion.transform.position = wizardPos;
        ChangeSprite();
    }

    void ChangeSprite()
    {
        spriteRenderer.sprite = Mana[mana];
    }
}
