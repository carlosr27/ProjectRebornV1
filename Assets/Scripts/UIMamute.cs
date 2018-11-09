using UnityEngine;
using System.Collections;

public class UIMamute : MonoBehaviour {

    public static UIMamute uIMamute;
    private GameObject battleController;
    public GameObject Habilidades_Ataque, Habilidades_Defesa;
    

	// Use this for initialization
	void Start () {

        this.GetComponent<Camera>().enabled = false;

        if (uIMamute == null)
        {
            DontDestroyOnLoad(gameObject);
            uIMamute = this;
        }
        else if (uIMamute != this)
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

            if (battleController.GetComponent<BattleController>().monstroAtivo == "Mamute")
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
