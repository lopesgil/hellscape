using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformasSecretas : MonoBehaviour {
    public float tempoMin;
    public GameObject[] plataformas;
    private float counter;
	// Use this for initialization
	void Start () {
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlayerPlatformerController.moving)
        {
            counter += Time.deltaTime;
        } else
        {
            counter = 0;
        }
        if (counter >= 8)
        {
            foreach (GameObject g in plataformas)
            {
                g.SetActive(true);
            }
        }
	}
}
