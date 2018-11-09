using UnityEngine;
using System.Collections;

public class AguiaBehaviour : MonoBehaviour {

    public static AguiaBehaviour aguiaBehaviour;
    private BattleController battleController;
    public LaboratorioController labController;

    //Prefab do proprio gameObject (para ativar desativar remotamente)
    public GameObject AguiaPrefab;

    public string elemento = "Wind";
    public bool load = false;
    public GameObject UI;

    //UI
    public GameObject HabAtk, HabDef;

    //CONTEUDO PARTE DO CARLOS
    public int vida = 100;
    public int dano = 20;
    public int resistencia = 24;
    public int sorte = 28;
    public int battleLife;
    public Animator aguiaAnimator;

    void Start () {

        /*Carlos*/
        
        battleLife = vida;
        
        /*Carlos*/

        if (aguiaBehaviour == null)
        {
            DontDestroyOnLoad(gameObject);
            aguiaBehaviour = this;
        }
        else if (aguiaBehaviour != this)
        {
            Destroy(gameObject);
        }

        load = false;
        
	
	}

    // Update is called once per frame
    void Update() {

        if (Application.loadedLevelName == "PineMountain_Forest")
        {
            if (load == false)
            {
                battleController = GameObject.Find("BattleController").GetComponent<BattleController>();

                if (battleController.monstroAtivo == "Aguia")
                {
                    GameObject.Find("MamuteUI").SetActive(false);
                    GameObject.Find("PeixeUI").SetActive(false);
                }

                load = true;
            }

            /*novo*/
            if (aguiaAnimator.GetBool("animTrigger") == false) //Controle para nao setar o aguia animator a cada frame
            {
                aguiaAnimator.SetBool("animTrigger", true);
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


            }/*NOVO*/
             // essa variavel serve para a aguia nunca parar de se mexer
            if (!aguiaAnimator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Iddle"))
            {
                aguiaAnimator.SetInteger("animCondition", 0);
            }

        }
        else if (Application.loadedLevelName == "LABORATORIO" && aguiaAnimator.GetBool("animTrigger") == true)
        {
            aguiaAnimator.SetBool("animTrigger", false);
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

