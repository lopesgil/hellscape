using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    public bool aberto;
    private SpriteRenderer spriteRenderer;
    public Sprite portalAberto;
    public int moedasPraCompletar;
    public float counter;
    public float tempomax04;
	// Use this for initialization
	void Start () {
        aberto = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("Moeda") != null)
        {
            if (PlayerPlatformerController.count >= moedasPraCompletar) aberto = true;
        }
        else
        {
            string faseAtual = SceneManager.GetActiveScene().name;
            if (faseAtual == "Fase04")
            {
                counter += Time.deltaTime;
            }
            if(counter<=tempomax04)
            {
                aberto = true;
            }
        }
        if (aberto)
        {
            spriteRenderer.sprite = portalAberto;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string proximaFase;
        string faseAtual = SceneManager.GetActiveScene().name;
        if (faseAtual == "Fase01")
        {
            proximaFase = "Fase04";
        } else if(faseAtual == "Fase04")
        {
            proximaFase = "Fase07";
        }
        else
        {
            proximaFase = "Fase01";
        }
        if (aberto && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(proximaFase);
        }
    }
}
