using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour {
    public bool aberto;
    private SpriteRenderer spriteRenderer;
    public Text CountText;
    public Sprite portalAberto;
    public Sprite portalFechado;
    public int moedasPraCompletar;
    public float counter;
    public float tempomax04;
    private int controle;
    public int numeroinimigos;

    enum CurrentStage
    {
        ganancia,
        luxuria,
        ira,
        orgulho,
        inveja,
        gula,
        preguica
    }
    [SerializeField]
    CurrentStage currentstage;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        counter = 0;
        controle = 0;
        Setcountext();
	}

    // Update is called once per frame
    void Update() {
        counter += Time.deltaTime;
        Setcountext();
        switch (currentstage)
        {
            case CurrentStage.ganancia:
                if (PlayerPlatformerController.count >= moedasPraCompletar) aberto = true;
                break;
            case CurrentStage.inveja:
                if(counter<=tempomax04)
                {
                    aberto = true;
                }
                break;
            case CurrentStage.gula:
                if(PlayerPlatformerController.gula1 && PlayerPlatformerController.gula2 && PlayerPlatformerController.gula3)
                {
                    aberto = true;
                }
                break;
            case CurrentStage.luxuria:
                if(PlayerPlatformerController.inimigosmortos >0)
                {
                    aberto = false;
                }
                break;
            case CurrentStage.ira:
                if(PlayerPlatformerController.inimigosmortos == numeroinimigos)
                {
                    aberto = true;
                }
                break;
            default:
                break;
        }
        if (aberto)
        {
            spriteRenderer.sprite = portalAberto;
        }
        else
        {
            spriteRenderer.sprite = portalFechado;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string proximaFase;
        switch(currentstage)
        {
            case CurrentStage.ganancia:
                proximaFase = "Fase02";
                break;
            case CurrentStage.luxuria:
                proximaFase = "Fase03";
                break;
            case CurrentStage.ira:
                proximaFase = "Fase04";
                break;
            case CurrentStage.orgulho:
                proximaFase = "Fase05";
                break;
            case CurrentStage.inveja:
                proximaFase = "Fase06";
                break;
            case CurrentStage.gula:
                proximaFase = "Fase07";
                break;
            default:
                proximaFase = "Fase01";
                break;
        }
        if (aberto && collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(proximaFase);
        }
    }
    void Setcountext()
    {
        if(counter - controle >=1)
        {
            controle++;
        }
        CountText.text = controle.ToString();
    }
}
