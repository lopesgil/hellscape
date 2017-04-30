using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJogador : MonoBehaviour {
    public float velocidade;
    private Rigidbody2D rb;
    
	// Use this for initialization
	public void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(new Vector2(horizontal, vertical)*velocidade, ForceMode2D.Force);
	}
}
