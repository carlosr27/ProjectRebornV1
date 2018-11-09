using UnityEngine;
using System.Collections;

public class MamuteBehaviour : MonoBehaviour {

    public static MamuteBehaviour mamuteBehaviour;
    private BattleController battleController;

    //Prefab do proprio gameObject (para ativar desativar remotamente)
    public GameObject MamutePrefab;
    public Animator mamuteAnimator;


    //UI
    public GameObject HabAtk, HabDef;

    public int vida = 100;
    public int dano = 20;
    public int resistencia = 30;
    public int sorte = 33;
    public int battleLife;
    public string elemento = "Earth";
    public bool load = false;
    public GameObject UI;

    // Use this for initialization
    void Start () {


        battleLife = vida;

        if (mamuteBehaviour == null)
        {
            DontDestroyOnLoad(gameObject);
            mamuteBehaviour = this;
        }
        else if (mamuteBehaviour != this)
        {
            Destroy(gameObject);
        }

        load = false;
       
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Application.loadedLevelName == "PineMountain_Forest")
        {
            if (load == false)
            {
                battleController = GameObject.Find("BattleController").GetComponent<BattleController>();

                if (battleController.monstroAtivo == "Mamute")
                {
                    GameObject.Find("AguiaUI").SetActive(false);
                    GameObject.Find("PeixeUI").SetActive(false);
                }

                load = true;
            }

            /*novo*/
            if (mamuteAnimator.GetBool("animTrigger") == false) //Controle para nao setar o aguia animator a cada frame
            {
                mamuteAnimator.SetBool("animTrigger", true);
            }
           

            // Essa operaçao logica serve para o jogador nao clicar mais de uma vez nos botoes de ataque e defesa
            // se abre um contador e quando o contador chegar a - 0 o contador termina e o jogador estara habito a selecionar ataque e defesa novamente
            // Essa operacao so sera true quando o jogador terminar de apertar as letras
            /*novo*/
            if (battleController.GetComponent<BattleController>().pressButton == false
                && battleController.GetComponent<BattleController>().pressletters == false)
            {
                if (battleController.GetComponent<BattleController>().timerToPlay >= 0)
                {
                    battleController.GetComponent<BattleController>().timerToPlay -= Time.deltaTime;
                }

                if (battleController.GetComponent<BattleController>().timerToPlay <= 0)
                {

                    battleController.GetComponent<DamageController>().enemyRoundDone = false;
                    battleController.GetComponent<BattleController>().penaltyDef = 0;
                    battleController.GetComponent<BattleController>().penaltyAtk = 0;
                    battleController.GetComponent<BattleController>().pressButton = true;
                    battleController.GetComponent<BattleController>().timerToPlay = 3.0f;

                    // essa operaçao logica serve para ao final do timer ele devera mudar o turno do jogador
                    if (battleController.GetComponent<BattleController>().primeiroJogador == false)
                    {
                        battleController.GetComponent<BattleController>().primeiroJogador = true;
                    }
                    else if (battleController.GetComponent<BattleController>().primeiroJogador == true)
                    {
                        battleController.GetComponent<BattleController>().primeiroJogador = false;
                    }


                }

            }    /*NOVO*/
                 // essa variavel serve para a aguia nunca parar de se mexer
            if (!mamuteAnimator.GetCurrentAnimatorStateInfo(0).IsName("Iddle"))
            {
                mamuteAnimator.SetInteger("animCondition", 0);
            }

        }
        else if (Application.loadedLevelName == "LABORATORIO" && mamuteAnimator.GetBool("animTrigger") == true)
        {
            mamuteAnimator.SetBool("animTrigger", false);
        }/*TUDO NOVO*/

    }

    /*NOVO*/
    //Essas funcoes sao funcoes dos botoes de ataque e defesa

    public void Atk1()
    {
        if (battleController.GetComponent<BattleController>().pressButton == true)
        {
            battleController.GetComponent<BattleController>().pressletters = true;
            battleController.GetComponent<BattleController>().pressButton = false;
            battleController.GetComponent<BattleController>().atkPress = 1;

        }
    }
    public void Atk2()
    {
        if (battleController.GetComponent<BattleController>().pressButton == true)
        {
            battleController.GetComponent<BattleController>().pressletters = true;
            battleController.GetComponent<BattleController>().pressButton = false;
            battleController.GetComponent<BattleController>().atkPress = 2;

        }
    }
    public void Def1()
    {
        if (battleController.GetComponent<BattleController>().pressButton == true)
        {
            battleController.GetComponent<BattleController>().pressletters = true;
            battleController.GetComponent<BattleController>().pressButton = false;
            battleController.GetComponent<BattleController>().defPress = 3;
        }
    }
    public void Def2()
    {
        if (battleController.GetComponent<BattleController>().pressButton == true)
        {
            battleController.GetComponent<BattleController>().pressletters = true;
            battleController.GetComponent<BattleController>().pressButton = false;
            battleController.GetComponent<BattleController>().defPress = 4;

        }
    }
}

