using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//SITUAÇÃO ATUAL: PRECISO CRIAR UM METODO DE O UI DE TAL MONSTRO PROCURAR SEU PERTENCENTE, ATIVA-LO NO LABORATORIO, DESATIVANDO SUA SPRITE e ATIVA-LO(sprite) no GAMEPLAY

public class LaboratorioController : MonoBehaviour {



    // 0 = Static | 1 = Left | 2 = Right //
    private int currentCam = 0;
    //Sprites das Setinhas
    public GameObject SetaLeft, SetaRight;
    //Variavel do ANIMATOR DA CAMERA
    public Animator anim_camera;
    //Variavel do ANIMATOR DO BANCO DE DADOS
    public Animator anim_Banco_de_dados;
    //Varivel bool para habilitar e desabilitar o Banco de dados
    public bool banco_active = false;

    //Varivel bool para habilitar e desabilitar o botao do banco de dados
    public bool banco_active_button = false;

    //Variavel do ANIMATOR DO BOTAO DE SELEÇÃO DE MONSTRO
    public Animator anim_Banco_de_dados_buttons;

    //Variaveis GAMEOBJECTS dos monstros
    public GameObject Aguia, Mamute, Peixe;
    
    //Variavel que guarda o ultimo monstro "escolhido"
    public string ultimo_Monstro_Escolhido;

    //Se for igual a 0, é nulo ou seja não há monstro // Se for igual a 1, é Aguia // Se for igual a 2, é Mamute// Se for igual a 3, é Peixe
    int monster = 0;
    public GameObject AguiaPrefab, PeixePrefab, MamutePrefab;

    private bool bdStatus;

    //Variavel do script planet Controller
    public PlanetController planetController;
    
    //Variavel text do BD
    public TextMesh vida_text, dano_text, resistencia_text, sorte_text, name_text;
    public GameObject water, wind, fire, earth;

    //BarraDeVida
   public BarraVidaController barraVidaController;

   public ItensController itensController;

   public GameObject HUDItens;

    //Variavel do CAMBIO
    [Header("Cambio")]
   
    public TextMesh CurrentGoldTXT;
    public TextMesh CurrentBronzeTXT;
    public TextMesh CurrentIronTXT;
    public TextMesh CurrentUranioTXT;
    public TextMesh ReceivedCoinTXT;

    public TextMesh ConvertGoldTXT;
    public TextMesh ConvertBronzeTXT;
    public TextMesh ConvertIronTXT;
    public TextMesh ConvertUranioTXT;

    public Animator cambioAnimator;

    public int ConvertGoldNumber, ConvertIronNumber, ConvertUranioNumber, ConvertBronzeNumber;
    public int ConvertedCoin;

    //Script GOLD SCRIPT(ATUALIZAR MESHTEXT)
    public goldScript GoldScript;

    void Start()
    {

       

        Aguia = GameObject.Find("Aguia");
        Mamute = GameObject.Find("Mamute");
        Peixe = GameObject.Find("Peixe");

        AguiaPrefab = GameObject.Find("Aguia2");
        MamutePrefab = GameObject.Find("Mamute2");
        PeixePrefab = GameObject.Find("Peixe2");

        AguiaPrefab.SetActive(true);
        MamutePrefab.SetActive(false);
        PeixePrefab.SetActive(false);

        ultimo_Monstro_Escolhido = "Aguia";
        UltimoMonstroEscolhido();
        

        banco_active = false;
        //A seta que aponta para o lado Right é desativada
        SetaRight.SetActive(false);
        //A Variavel de controle de animação da camera (Estado) é zerada, ou seja modo Estatico
        currentCam = 0;
        monster = 1;

        MoveToPosition();

        LayerOFtextBD();

        itensController = GameObject.Find("Itens").GetComponent<ItensController>();

    }

    void Update()
    {


        //Se o estado RESET é finalizado a variavel de controle é zerada, e o parametro atualizado
        if (this.anim_camera.GetCurrentAnimatorStateInfo(0).IsName("RESET"))
        {
            currentCam = 0;
            anim_camera.SetInteger("CAM_STATUS", currentCam);
        }

        //Se o estado LEFT_MOVE(Movimento para a esquerda) é finalizado a seta apontando para a Direita é ativada e a da esquerda é ativada
        if (this.anim_camera.GetCurrentAnimatorStateInfo(0).IsName("LABORATORIO_CAMERA_LEFTMOV"))
        {
            SetaLeft.SetActive(false);
            SetaRight.SetActive(true);
        }

        //IDEM ^^
         if (this.anim_camera.GetCurrentAnimatorStateInfo(0).IsName("LABORATORIO_CAMERA_RIGHTMOV"))
        {
            SetaLeft.SetActive(true);
            SetaRight.SetActive(false);
        }

        
               
    }

    //Metodo para adicionar a variavel de estado, e atualizar o parametro do animator
    public void Click_Arrow()
    {
        currentCam++;
        anim_camera.SetInteger("CAM_STATUS", currentCam);
        

        if (banco_active_button)
        {   
            banco_active_button = false;
            anim_Banco_de_dados_buttons.SetBool("ACTIVE", banco_active_button);
            

        }
        else
        {
            banco_active_button = true;
            anim_Banco_de_dados_buttons.SetBool("ACTIVE", banco_active_button);
           
        }

        
    }

    private void LayerOFtextBD() {

        vida_text.GetComponent<Renderer>().sortingOrder = 300;
        dano_text.GetComponent<Renderer>().sortingOrder = 300;
        resistencia_text.GetComponent<Renderer>().sortingOrder = 300;
        sorte_text.GetComponent<Renderer>().sortingOrder = 300;
        name_text.GetComponent<Renderer>().sortingOrder = 300;
    }

    public void ShowHideBD()
    {

        
        if (bdStatus)
        {
            bdStatus = false;
            anim_Banco_de_dados.SetBool("Entry", bdStatus);
        }
        else
        {
            bdStatus = true;
            anim_Banco_de_dados.SetBool("Entry", bdStatus);
        }
    }

    
    public void Click_Planet()
    {
        currentCam = 5;
        anim_camera.SetInteger("CAM_STATUS", currentCam);
        SetaLeft.SetActive(false);
        SetaRight.SetActive(false);
        planetController.view = true;
    }

    public void Click_Voltar(){

        AguiaPrefab.SetActive(true);
        PeixePrefab.SetActive(true);
        MamutePrefab.SetActive(true);

        Application.LoadLevel("MAIN_MENU");

    }

    public void Explorar()
    {

   

        //Se for nulo, mande uma mensagem de aviso, pedindo ao jogador que escolha um monstro
        if (ultimo_Monstro_Escolhido == null)
        {
            
        }
        //Se for diferente de nulo, pode ir para a batalha
        if (ultimo_Monstro_Escolhido != null)
        {
            Application.LoadLevel("PineMountain_Forest");
        }
        
    }

    
    //Este metodo serve para carregar o ultimo monstro escolhido Se for nulo, todos os mosntros serão carregados, se não for nulo o if irá tratar da devida maneira ativando o que estava ativo
    void UltimoMonstroEscolhido()
    {
        
        if (ultimo_Monstro_Escolhido == null)
        {
            AguiaPrefab.gameObject.SetActive(true);
            MamutePrefab.gameObject.SetActive(true);
            PeixePrefab.gameObject.SetActive(true);
            
        }

        

        if (ultimo_Monstro_Escolhido == "Aguia")
        {
            AguiaPrefab.gameObject.SetActive(true);
        }

        if (ultimo_Monstro_Escolhido == "Mamute")
        {
            MamutePrefab.gameObject.SetActive(true);
        }

        if (ultimo_Monstro_Escolhido == "Peixe")
        {
            PeixePrefab.gameObject.SetActive(true);
        }
    }

    //Metodo para escolher o monstro
    public void ChoseMonsterDir()
    {
        
        //Se for igual a 0, é nulo ou seja não há monstro // Se for igual a 1, é Aguia // Se for igual a 2, é Mamute// Se for igual a 3, é Peixe

        if (ultimo_Monstro_Escolhido == null)
        {
            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(false);
        }

        monster++;

        if (monster == 0) {
            monster = 1;
        }
        if (monster > 3)
        {
            monster = 1;
        }
        if (monster == 1 || monster == -1)
        {
            ultimo_Monstro_Escolhido = "Aguia";
        }
        else if (monster == 2 || monster == -2)
        {
            ultimo_Monstro_Escolhido = "Mamute";
        }
        else if (monster == 3 || monster == -3)
        {
            ultimo_Monstro_Escolhido = "Peixe";
        }

        

        if (ultimo_Monstro_Escolhido == "Aguia")
        {
            AguiaPrefab.gameObject.SetActive(true);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(false);
        }

        if (ultimo_Monstro_Escolhido == "Mamute")
        {
            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(true);
            PeixePrefab.gameObject.SetActive(false);
        }

        if (ultimo_Monstro_Escolhido == "Peixe")
        {
            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(true);
        }
        
    }

    public void ChoseMonsterEsq()
    {


        if (ultimo_Monstro_Escolhido == null)
        {
            

            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(false);
        }

        monster--;
        if (monster == 0) {
            monster = -1;
        }

        if (monster <  -3)
        {
            monster = -1;
        }

        if (monster == -1 || monster == 1)
        {
            ultimo_Monstro_Escolhido = "Aguia";
        }
        else if (monster == -2 || monster == 2)
        {
            ultimo_Monstro_Escolhido = "Mamute";
        }
        else if (monster == -3 || monster == 3)
        {
            ultimo_Monstro_Escolhido = "Peixe";
        }



        if (ultimo_Monstro_Escolhido == "Aguia")
        {
            AguiaPrefab.gameObject.SetActive(true);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(false);
        }

        if (ultimo_Monstro_Escolhido == "Mamute")
        {
            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(true);
            PeixePrefab.gameObject.SetActive(false);
        }

        if (ultimo_Monstro_Escolhido == "Peixe")
        {
            AguiaPrefab.gameObject.SetActive(false);
            MamutePrefab.gameObject.SetActive(false);
            PeixePrefab.gameObject.SetActive(true);
        }
       

    }

    void MoveToPosition()
    {
        //Esse enable do Animator foi necessario pelo fato de que há uma animação com uma posição já importada na animação da aguia...
        //AguiaPrefab.GetComponent<Animator>().enabled = false;
        AguiaPrefab.gameObject.transform.position = new Vector3(766.2f, 394.5f, 268f);
        AguiaPrefab.gameObject.transform.localScale = new Vector3(13.70741f, 13.70741f, 13.70741f);
        AguiaPrefab.gameObject.transform.rotation = Quaternion.Euler(26.97f, 87.76065f, 0.4800034f);

        // MamutePrefab.GetComponent<Animator>().enabled = false;
        MamutePrefab.gameObject.transform.localScale = new Vector3(127.3566f, 127.3566f, 127.3566f);

        MamutePrefab.gameObject.transform.position = new Vector3(764.3f, 391.54f, 275.3f);
       
        MamutePrefab.gameObject.transform.rotation = Quaternion.Euler(353.3f, 204.6024f, 9.7f);

       // PeixePrefab.GetComponent<Animator>().enabled = false;
        PeixePrefab.gameObject.transform.position = new Vector3(766, 400.3f , 262.9348f);
        PeixePrefab.gameObject.transform.localScale = new Vector3(58.82705f, 58.82705f, 58.82705f);
        PeixePrefab.gameObject.transform.rotation = Quaternion.Euler(9.400011f, 151.17f, 22.98f);
    }

   

    void Att()
    {

        name_text.text = ultimo_Monstro_Escolhido;

        wind.SetActive(true);
        fire.SetActive(true);
        water.SetActive(true);
        earth.SetActive(true);

        if (ultimo_Monstro_Escolhido == "Aguia")
        {
            vida_text.text = (""+Aguia.GetComponent<AguiaBehaviour>().vida);
            dano_text.text = ("" + Aguia.GetComponent<AguiaBehaviour>().dano);
            resistencia_text.text = ("" + Aguia.GetComponent<AguiaBehaviour>().resistencia);
            sorte_text.text = ("" + Aguia.GetComponent<AguiaBehaviour>().sorte);
            wind.SetActive(false);
            barraVidaController.UpdateBar(Aguia.GetComponent<AguiaBehaviour>().vida, 
                                          Aguia.GetComponent<AguiaBehaviour>().dano, 
                                          Aguia.GetComponent<AguiaBehaviour>().resistencia, 
                                          Aguia.GetComponent<AguiaBehaviour>().sorte);
        }
        else if (ultimo_Monstro_Escolhido == "Mamute")
        {
            vida_text.text = (""+Mamute.GetComponent<MamuteBehaviour>().vida);
            dano_text.text = ("" + Mamute.GetComponent<MamuteBehaviour>().dano);
            resistencia_text.text = ("" + Mamute.GetComponent<MamuteBehaviour>().resistencia);
            sorte_text.text = ("" + Mamute.GetComponent<MamuteBehaviour>().sorte);
            earth.SetActive(false);
            barraVidaController.UpdateBar(Mamute.GetComponent<MamuteBehaviour>().vida,
                                          Mamute.GetComponent<MamuteBehaviour>().dano,
                                          Mamute.GetComponent<MamuteBehaviour>().resistencia,
                                          Mamute.GetComponent<MamuteBehaviour>().sorte);
        }
        else if (ultimo_Monstro_Escolhido == "Peixe")
        {
            vida_text.text = (""+ Peixe.GetComponent<PeixeBehaviour>().vida);
            dano_text.text = ("" + Peixe.GetComponent<PeixeBehaviour>().dano);
            resistencia_text.text = ("" + Peixe.GetComponent<PeixeBehaviour>().resistencia);
            sorte_text.text = ("" + Peixe.GetComponent<PeixeBehaviour>().sorte);
            water.SetActive(false);
            barraVidaController.UpdateBar(Peixe.GetComponent<PeixeBehaviour>().vida,
                                          Peixe.GetComponent<PeixeBehaviour>().dano,
                                          Peixe.GetComponent<PeixeBehaviour>().resistencia,
                                          Peixe.GetComponent<PeixeBehaviour>().sorte);
        }


    }

    public void ShowCambio()
    {
        //Mudar a LAYER DOS TEXTS
        CurrentUranioTXT.GetComponent<Renderer>().sortingOrder = 200;
        CurrentGoldTXT.GetComponent<Renderer>().sortingOrder = 200;
        CurrentIronTXT.GetComponent<Renderer>().sortingOrder = 200;
        CurrentBronzeTXT.GetComponent<Renderer>().sortingOrder = 200;

        ConvertUranioTXT.GetComponent<Renderer>().sortingOrder = 200;
        ConvertGoldTXT.GetComponent<Renderer>().sortingOrder = 200;
        ConvertIronTXT.GetComponent<Renderer>().sortingOrder = 200;
        ConvertBronzeTXT.GetComponent<Renderer>().sortingOrder = 200;

        ReceivedCoinTXT.GetComponent<Renderer>().sortingOrder = 200;
        //==================

        //Setar os valores dos TEXTS
        CurrentUranioTXT.text = itensController.uranio.ToString();
        CurrentGoldTXT.text = itensController.ouro.ToString();
        CurrentIronTXT.text = itensController.ferro.ToString();
        CurrentBronzeTXT.text = itensController.bronze.ToString();

        ConvertBronzeNumber = 0; ConvertIronNumber = 0; ConvertUranioNumber = 0; ConvertGoldNumber = 0;
        ConvertedCoin = 0;

        ConvertUranioTXT.text = ConvertUranioNumber.ToString();
        ConvertGoldTXT.text = ConvertGoldNumber.ToString();
        ConvertIronTXT.text = ConvertIronNumber.ToString();
        ConvertBronzeTXT.text = ConvertBronzeNumber.ToString();

        cambioAnimator.SetBool("Trigger", true);

        HUDItens.SetActive(false);


    }

    public void HideCambio()
    {
        ConvertBronzeNumber = 0; ConvertIronNumber = 0; ConvertUranioNumber = 0; ConvertGoldNumber = 0;
        ConvertedCoin = 0;

        ConvertUranioTXT.text = ConvertUranioNumber.ToString();
        ConvertGoldTXT.text = ConvertGoldNumber.ToString();
        ConvertIronTXT.text = ConvertIronNumber.ToString();
        ConvertBronzeTXT.text = ConvertBronzeNumber.ToString();
        ReceivedCoinTXT.text = ConvertedCoin.ToString();

        cambioAnimator.SetBool("Trigger", false);

        HUDItens.SetActive(true);
    }

    public void AttMinusPlus(GameObject button)
    {

        //OURO
        if(button.gameObject.name == "plusGOLD" && ConvertGoldNumber < itensController.ouro)
        {

            ConvertGoldNumber++;
            ConvertGoldTXT.text = ConvertGoldNumber.ToString();

            ConvertedCoin += 10;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

        }
        else if(button.gameObject.name == "minusGOLD" && ConvertGoldNumber > 0)
        {
            ConvertGoldNumber--;
            ConvertGoldTXT.text = ConvertGoldNumber.ToString();

            ConvertedCoin -= 10;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();
        }
        //BRONZE
        if (button.gameObject.name == "plusBRONZE" && ConvertBronzeNumber < itensController.bronze)
        {

            ConvertBronzeNumber++;
            ConvertBronzeTXT.text = ConvertBronzeNumber.ToString();

            ConvertedCoin += 1;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

        }
        else if (button.gameObject.name == "minusBRONZE" && ConvertBronzeNumber > 0)
        {
            ConvertBronzeNumber--;
            ConvertBronzeTXT.text = ConvertBronzeNumber.ToString();

            ConvertedCoin -= 1;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();
        }
        //FERRO
        if (button.gameObject.name == "plusIRON" && ConvertIronNumber < itensController.ferro)
        {

            ConvertIronNumber++;
            ConvertIronTXT.text = ConvertIronNumber.ToString();

            ConvertedCoin += 2;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

        }
        else if (button.gameObject.name == "minusIRON" && ConvertIronNumber > 0)
        {
            ConvertIronNumber--;
            ConvertIronTXT.text = ConvertIronNumber.ToString();

            ConvertedCoin -= 2;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();
        }
        //URANIO
        if (button.gameObject.name == "plusURANIO" && ConvertUranioNumber < itensController.uranio)
        {

            ConvertUranioNumber++;
            ConvertUranioTXT.text = ConvertUranioNumber.ToString();

            ConvertedCoin += 100;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

        }
        else if (button.gameObject.name == "minusURANIO" && ConvertUranioNumber > 0)
        {
            ConvertUranioNumber--;
            ConvertUranioTXT.text = ConvertUranioNumber.ToString();

            ConvertedCoin -= 100;
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

        }
    }

    public void Convert()
    {

        if(ConvertedCoin > 0)
        {
            itensController.ouro -= ConvertGoldNumber;
            itensController.ferro -= ConvertIronNumber;
            itensController.bronze -= ConvertBronzeNumber;
            itensController.uranio -= ConvertUranioNumber;

            itensController.coin += ConvertedCoin;


            ConvertBronzeNumber = 0; ConvertIronNumber = 0; ConvertUranioNumber = 0; ConvertGoldNumber = 0;
            ConvertedCoin = 0;

            ConvertUranioTXT.text = ConvertUranioNumber.ToString();
            ConvertGoldTXT.text = ConvertGoldNumber.ToString();
            ConvertIronTXT.text = ConvertIronNumber.ToString();
            ConvertBronzeTXT.text = ConvertBronzeNumber.ToString();
            ReceivedCoinTXT.text = ConvertedCoin.ToString();

            HUDItens.SetActive(true);
            GoldScript.AttGold();
            HUDItens.SetActive(false);

        }

    }
   
  

}
