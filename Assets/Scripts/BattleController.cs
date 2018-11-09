using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {

    //GameObjects ou Classes dos Monstros do PLAYER(Não é do bot);
    public GameObject Aguia, Peixe, Mamute;
    //GameObjects ou Classes dos monstros do PLAYER(PREFAB DA ANIMAÇÃO);
    public GameObject AguiaPrefab, PeixePrefab, MamutePrefab;
    //Variavel do sorteio, criei a variavel de sorteio para que possa ter um numero maior, e ter mais chances na hr de escolher o jogador
    //Se primeiro sorteioPrimeiro for > 10 {primeiro jogador = true, ou seja jogador vai atacar primeiro e maquina depois}.
    int sorteioPrimeiro; public bool primeiroJogador; public string monstroAtivo;

    /*NOVO*/
    public GameObject Enemie, B, C, E, J, N, O, P, R, T, HabDef, HabAtk;
    // a variavel round serve para o controle de round para a inteligencia artificial do jogo
    // as variaveis atk1, atk2, def1, def2 servem para a inteligencia artificial se adptar aos ataques do jogador
    //atkPress e defPress serve para chamar o ataque e defesa depois que PressLetters for desativado
    public int round = 1, atk1, atk2, def1, def2, atkPress, defPress;
    // a variavel pressButton serve para o jogador nao clicar mais de uma vez nos botoes de ataque e defesa
    //PressLetters serve para o jogo habilitar a rodada de pressionar as letras para o ataque sair bem sucedido
    public bool pressButton = true, pressletters = false, clicked = false;
    // a variavel timerdoplay e um countdown para deixar o jogador atacar ou defender
    // a variavek clickControl serve para depois que todas as letras forem pressionadas ele saia desse modo
    public float timerToPlay = 3.0f, timerLetters = 5.0f; int clickControl = 0;
    //Se o jogador escolher a tatica errada ou nao conseguir apertar as letras ele recebera uma punicao no ataque ou na defesa
    public int penaltyAtk, penaltyDef;

    //VidaDosMonstros
    public int vidaPlayer, vidaEnemy;



    // Use this for initialization
    void Start () {

        
        //Metodo para tirar os GameObject de batalha
        FindLetters();
        /*NOVO*/

        //Metodo para gerar o primeiro jogador
        PrimeiroJogador();

        //Metodo para buscar os monstros
        GetMonsters();

        //Metodo para verificar qual mostro esta ativo(Mudança só para nós(desenvolvedores) sem isso apareceria uma mensagem de erro
        VerifyActiveMonster();

        //Setar Posições dos monstros
        SetPositions();

        if(monstroAtivo == "Aguia")
        {
            HabAtk = GameObject.FindGameObjectWithTag("AUIA");
            HabDef = GameObject.FindGameObjectWithTag("AUID");
        }
        else if(monstroAtivo == "Mamute")
        {
            HabAtk = GameObject.FindGameObjectWithTag("MUIA");
            HabDef = GameObject.FindGameObjectWithTag("MUID");
        }
        else
        {
            HabAtk = GameObject.FindGameObjectWithTag("PUIA");
            HabDef = GameObject.FindGameObjectWithTag("PUID");
        }
        

    }
	
	// Update is called once per frame
	void Update () {

        vidaEnemy = Enemie.gameObject.GetComponent<UIEnemy>().enemyLife;

        if (monstroAtivo == "Aguia")
        {

            vidaPlayer = Aguia.GetComponent<AguiaBehaviour>().battleLife;

        }
        else if (monstroAtivo == "Mamute")
        {

            vidaPlayer = Mamute.GetComponent<MamuteBehaviour>().battleLife;

        }
        else
        {

            vidaPlayer = Peixe.GetComponent<PeixeBehaviour>().battleLife;

        }

        //VERIFICAR A DERROTA
        if (vidaEnemy <= 0)
        {
            Aguia.GetComponent<AguiaBehaviour>().AguiaPrefab.SetActive(false);
            Mamute.GetComponent<MamuteBehaviour>().MamutePrefab.SetActive(false);
            Peixe.GetComponent<PeixeBehaviour>().peixePrefab.SetActive(false);

            Peixe.GetComponent<PeixeBehaviour>().UI.SetActive(false);
            Aguia.GetComponent<AguiaBehaviour>().UI.SetActive(false);
            Mamute.GetComponent<MamuteBehaviour>().UI.SetActive(false);

            HabAtk.SetActive(false);
            HabDef.SetActive(false);

            Peixe.GetComponent<PeixeBehaviour>().load = false;
            Aguia.GetComponent<AguiaBehaviour>().load = false;
            Mamute.GetComponent<MamuteBehaviour>().load = false;


            Application.LoadLevel("GAME_OVER");

        }

        else if (vidaPlayer <= 0)
        {
            Aguia.GetComponent<AguiaBehaviour>().AguiaPrefab.SetActive(false);
            Mamute.GetComponent<MamuteBehaviour>().MamutePrefab.SetActive(false);
            Peixe.GetComponent<PeixeBehaviour>().peixePrefab.SetActive(false);

            Peixe.GetComponent<PeixeBehaviour>().UI.SetActive(false);
            Aguia.GetComponent<AguiaBehaviour>().UI.SetActive(false);
            Mamute.GetComponent<MamuteBehaviour>().UI.SetActive(false);

            HabAtk.SetActive(false);
            HabDef.SetActive(false);

            Peixe.GetComponent<PeixeBehaviour>().load = false;
            Aguia.GetComponent<AguiaBehaviour>().load = false;
            Mamute.GetComponent<MamuteBehaviour>().load = false;

           
            Application.LoadLevel("GAME_OVER");
        }

        //====================== VERIFICAR A DERROA FIM

        if (Input.GetKey(KeyCode.Escape))
        {
            Aguia.GetComponent<AguiaBehaviour>().AguiaPrefab.SetActive(true);
            Mamute.GetComponent<MamuteBehaviour>().MamutePrefab.SetActive(true);
            Peixe.GetComponent<PeixeBehaviour>().peixePrefab.SetActive(true);

            Peixe.GetComponent<PeixeBehaviour>().UI.SetActive(true);
            Aguia.GetComponent<AguiaBehaviour>().UI.SetActive(true);
            Mamute.GetComponent<MamuteBehaviour>().UI.SetActive(true);

            HabAtk.SetActive(true);
            HabDef.SetActive(true);

            Peixe.GetComponent<PeixeBehaviour>().load = false;
            Aguia.GetComponent<AguiaBehaviour>().load = false;
            Mamute.GetComponent<MamuteBehaviour>().load = false;

            Application.LoadLevel("LABORATORIO");
        }

        /*TUDO NOVO*/
        if (pressletters == true)
        {
            HabAtk.SetActive(false);
            HabDef.SetActive(false);
            PressLetters();

            //Essa operaçao serve para começar o timer
            if (clicked == false && timerLetters > 0)
            {

                timerLetters -= Time.deltaTime;

            }
            //Essa operaçao sera verdeira se o jogador nao conseguir clicar em todas as letras
            if (clicked == false && timerLetters <= 0)
            {

                if (primeiroJogador == true)
                {
                    penaltyAtk = penaltyAtk + 2;
                }
                if (primeiroJogador == false)
                {
                    penaltyDef = penaltyDef + 2;
                }

                SetLetters();
                timerLetters = 4.0f;
                pressletters = false;
                clickControl = 0;
            }

            //Essa operacao serve para quando o jogador conseguir clicar em todas as letras
            if (clickControl > 6 && clicked == true)
            {
                clickControl = 0;
                timerLetters = 4.0f;
                SetLetters();
                pressletters = false;
            }

        }
        if (pressButton == false && pressletters == false)
        {

            if (atkPress == 1)
            {
                if (monstroAtivo == "Aguia")
                {
                    AguiaPrefab.GetComponent<Animator>().SetInteger("animCondition", 1);
                }
                else if (monstroAtivo == "Peixe")
                {
                    PeixePrefab.GetComponent<Animator>().SetInteger("animCondition", 1);
                }
                else if (monstroAtivo == "Mamute")
                {
                    MamutePrefab.GetComponent<Animator>().SetInteger("animCondition", 1);
                }
                atk1++;
                round++;
                atkPress = 0;

            }
            else if (atkPress == 2)
            {
                if (monstroAtivo == "Aguia")
                {
                    AguiaPrefab.GetComponent<Animator>().SetInteger("animCondition", 2);
                }
                else if (monstroAtivo == "Peixe")
                {
                    PeixePrefab.GetComponent<Animator>().SetInteger("animCondition", 2);
                }
                else if (monstroAtivo == "Mamute")
                {
                    MamutePrefab.GetComponent<Animator>().SetInteger("animCondition", 2);
                }
                atk2++;
                round++;
                atkPress = 0;
            }


            if (defPress == 3)
            {
                if (monstroAtivo == "Aguia")
                {
                    AguiaPrefab.GetComponent<Animator>().SetInteger("animCondition", 3);
                }
                else if (monstroAtivo == "Peixe")
                {
                    PeixePrefab.GetComponent<Animator>().SetInteger("animCondition", 3);
                }
                else if (monstroAtivo == "Mamute")
                {
                    MamutePrefab.GetComponent<Animator>().SetInteger("animCondition", 3);
                }
                def1++;
                round++;
                defPress = 0;

            }
            else if (defPress == 4)
            {
                if (monstroAtivo == "Aguia")
                {
                    AguiaPrefab.GetComponent<Animator>().SetInteger("animCondition", 4);
                }
                else if (monstroAtivo == "Peixe")
                {
                    PeixePrefab.GetComponent<Animator>().SetInteger("animCondition", 4);
                }
                else if (monstroAtivo == "Mamute")
                {
                    MamutePrefab.GetComponent<Animator>().SetInteger("animCondition", 4);
                }
                def2++;
                round++;
                defPress = 0;
            }
        }

    }

    //Metodo que atribui um gameObject(Já carregado do laboratorio), ele procura um objeto que tenha o nome Aguia,Peixe ou Mamute CASO~O MOSTRO ESTEJA DESATIVADO ELE ENVIA UMA MENSAGEM NO DEBUG(VISTA SOMENTE PELO DEV)
    public void GetMonsters()
    {

        Aguia = GameObject.Find("Aguia");

        Peixe = GameObject.Find("Peixe");

        Mamute = GameObject.Find("Mamute");

        AguiaPrefab = GameObject.Find("Aguia2");

        MamutePrefab = GameObject.Find("Mamute2");

        PeixePrefab = GameObject.Find("Peixe2");

    }

    //Metodo para verificar se esta ativo(Visivel só para os devs)
    public void VerifyActiveMonster()
    {

        if (PeixePrefab == null && AguiaPrefab == null)
        {
            monstroAtivo = "Mamute";
            Debug.Log("Peixe e Aguia não esta em jogo");
            
            //monstroAtivo_gameObject = Mamute;

        }
        
        if (MamutePrefab == null && AguiaPrefab == null)
        {
            monstroAtivo = "Peixe";
            Debug.Log("Aguia e Mamute não esta em jogo");
           
            // monstroAtivo_gameObject = Peixe;
        }

        if (MamutePrefab == null && PeixePrefab == null)
        {
            monstroAtivo = "Aguia";
            Debug.Log("Mamute e Peixe não esta em jogo");
            
            // monstroAtivo_gameObject = Aguia;
        }
    }

    

    //Metodo para gerar o primeiro atacante
    void PrimeiroJogador()
    {
        sorteioPrimeiro = Random.Range(0, 20);
        if (sorteioPrimeiro > 10)
        {
            //jogador ataca primeiro, maquina dps
            primeiroJogador = true;
            GameObject.Find("adversarioAtaca").SetActive(false);
        }
        else
        {
            primeiroJogador = false;
            GameObject.Find("voceAtaca").SetActive(false);
        }
    }

    void SetPositions()
    {
        if (monstroAtivo == "Aguia")
        {
            AguiaPrefab.gameObject.transform.position = new Vector3(68.31f, 15, 47.59f);
            AguiaPrefab.gameObject.transform.localScale = new Vector3(1, 1, 1);
            AguiaPrefab.gameObject.transform.rotation = Quaternion.Euler(0, 85.19204f, 0);
        }

        if (monstroAtivo == "Mamute")
        {
            MamutePrefab.gameObject.transform.position = new Vector3(68.56f, 14.925f, 47.82f);
            MamutePrefab.gameObject.transform.localScale = new Vector3(10.52279f, 10.52279f, 10.52279f);
            MamutePrefab.gameObject.transform.rotation = Quaternion.Euler(0, 270.2925f, 0);

        }

        if (monstroAtivo == "Peixe")
        {
            PeixePrefab.gameObject.transform.position = new Vector3(67.85218f, 15.854f, 50.69657f);
            PeixePrefab.gameObject.transform.localScale = new Vector3(7.787099f, 7.787099f, 7.787099f);
            PeixePrefab.gameObject.transform.rotation = Quaternion.Euler(0, 90.76683f, 0);

        }
      
    }

    /*NOVO*/

    private void FindLetters()
    {

        B = GameObject.Find("B");
        C = GameObject.Find("C");
        E = GameObject.Find("E");
        J = GameObject.Find("J");
        N = GameObject.Find("N");
        O = GameObject.Find("O");
        P = GameObject.Find("P");
        R = GameObject.Find("R");
        T = GameObject.Find("T");
        SetLetters();
    }

    private void SetLetters()
    {
        //if (Filter.activeInHierarchy) {Filter.SetActive (false);}
        if (B.activeInHierarchy) { B.SetActive(false); }
        if (C.activeInHierarchy) { C.SetActive(false); }
        if (E.activeInHierarchy) { E.SetActive(false); }
        if (J.activeInHierarchy) { J.SetActive(false); }
        if (N.activeInHierarchy) { N.SetActive(false); }
        if (O.activeInHierarchy) { O.SetActive(false); }
        if (P.activeInHierarchy) { P.SetActive(false); }
        if (R.activeInHierarchy) { R.SetActive(false); }
        if (T.activeInHierarchy) { T.SetActive(false); }
    }

    public void PressLetters()
    {
        int sortLetters; float x, y;
        sortLetters = Random.Range(1, 1);




        switch (sortLetters)
        {
            case 1:
                //PROJECT 
                if (clickControl == 0)
                {
                    if (!P.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        P.gameObject.transform.position = new Vector3(x, y, 45.57f);

                    }
                    P.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 1)
                {

                    P.SetActive(false);
                    if (!R.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        R.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    R.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 2)
                {
                    R.SetActive(false);
                    if (!O.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        O.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    O.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 3)
                {
                    O.SetActive(false);
                    if (!J.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        J.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    J.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 4)
                {
                    J.SetActive(false);
                    if (!E.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        E.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    E.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 5)
                {
                    E.SetActive(false);
                    if (!C.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        C.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    C.SetActive(true);
                    clicked = false;
                }
                else if (clickControl == 6)
                {
                    C.SetActive(false);
                    if (!T.activeInHierarchy)
                    {
                        x = Random.Range(68.55f, 74.77f); y = Random.Range(15.02f, 17.72f);
                        T.gameObject.transform.position = new Vector3(x, y, 45.57f);
                        timerLetters += 1f;
                    }
                    T.SetActive(true);
                    clicked = false;
                }

                break;
        }

    }

    public void Clicked()
    {
        if (clicked == false)
        {
            clickControl++;
            clicked = true;
        }
    }



}

