using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhoGula2 : MonoBehaviour
{

    private SpriteRenderer spriterenderer;
    public Sprite Espinhoazul;
    public static bool muda;
    public Sprite Espinho;
    // Use this for initialization
    void Start()
    {
        muda = false;
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (muda)
        {
            MudaSprite();
        }
        else
        {
            spriterenderer.sprite = Espinho;
        }
    }
    void MudaSprite()
    {
        spriterenderer.sprite = Espinhoazul;
    }
}
