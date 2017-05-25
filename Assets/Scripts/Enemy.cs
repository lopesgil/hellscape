using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float velocidade;
    public bool direcao;

  
    // Use this for initialization
    void Start () {
        direcao = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (direcao)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "colisorInimigo")
        {
            direcao = !direcao;
        }
    }
}
