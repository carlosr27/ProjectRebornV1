using UnityEngine;
using System.Collections;

public class UIAguia : MonoBehaviour {

    public static UIAguia uIAguia;
    private GameObject battleController;
    public GameObject Habilidades_Ataque, Habilidades_Defesa;


	// Use this for initialization
	void Start () {


        this.GetComponent<Camera>().enabled = false;
        if (uIAguia == null)
        {
            DontDestroyOnLoad(gameObject);
            uIAguia = this;
        }
        else if (uIAguia != this)
        {
            Destroy(this);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName == "LABORATORIO")
        {
            this.GetComponent<Camera>().enabled = false;
        }

        if (Application.loadedLevelName == "PineMountain_Forest")
        {

                if (battleController == null)
               {

                battleController = GameObject.Find("BattleController");

               }

                 if (battleController.GetComponent<BattleController>().monstroAtivo == "Aguia")
                 {


                this.GetComponent<Camera>().enabled = true;

                if (battleController.GetComponent<BattleController>().primeiroJogador)
                {
                    Habilidades_Ataque.SetActive(true);
                    Habilidades_Defesa.SetActive(false);
                }
                else
                {
                    Habilidades_Ataque.SetActive(false);
                    Habilidades_Defesa.SetActive(true);
                }

            }
                

        }


    }   
	
	}
