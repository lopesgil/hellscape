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
	}

    // Update is called once per frame
    void Update() {
        switch (currentstage)
        {
            case CurrentStage.ganancia:
                if (PlayerPlatformerController.count >= moedasPraCompletar) aberto = true;
                break;
            case CurrentStage.inveja:
                counter += Time.deltaTime;
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
            default:
                break;
        }
        if (aberto)
        {
            spriteRenderer.sprite = portalAberto;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string proximaFase;
        switch(currentstage)
        {
            case CurrentStage.ganancia:
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
}
