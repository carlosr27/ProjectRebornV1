using UnityEngine;
using System.Collections;

public class HUDControllerBehaviour : MonoBehaviour {

    public BattleController battleController;
    public AguiaBehaviour aguiaBehaviour;
    public MamuteBehaviour mamuteBehaviour;
    public PeixeBehaviour peixeBehaviour;

    public float totalLife;
    public float escalaTotal = 1;
    public float percentual;

    public float currentLife, currentDamage, currentResist, currentLuck;
    public GameObject barraVida;

    //Variaveis das labels

    public TextMesh currentLifeLabel, totalLifeLabel, damageTXT, LuckTXT, resistTXT;

    //Sprites
    public Sprite aguiaSprite, mamuteSprite, peixeSprite;
    public SpriteRenderer iconPersonagem;
    


    // Use this for initialization
    void Start () {

        battleController = GameObject.Find("BattleController").GetComponent<BattleController>();
        aguiaBehaviour = GameObject.Find("Aguia").GetComponent<AguiaBehaviour>();
        mamuteBehaviour = GameObject.Find("Mamute").GetComponent<MamuteBehaviour>();
        peixeBehaviour = GameObject.Find("Peixe").GetComponent<PeixeBehaviour>();

        if (battleController.monstroAtivo == "Aguia")
        {   
            currentLife = aguiaBehaviour.battleLife;
            totalLife = aguiaBehaviour.vida;
            currentLifeLabel.text = ""+currentLife;
            totalLifeLabel.text = "" + totalLife;

            damageTXT.text =""+ aguiaBehaviour.dano;
            LuckTXT.text = "" + aguiaBehaviour.sorte;
            resistTXT.text = "" + aguiaBehaviour.resistencia;

            iconPersonagem.sprite = aguiaSprite;

        }
        else if(battleController.monstroAtivo == "Mamute")
        {
            currentLife = mamuteBehaviour.battleLife;
            totalLife = mamuteBehaviour.vida;
            currentLifeLabel.text = "" + currentLife;
            totalLifeLabel.text = "" + totalLife;

            damageTXT.text = "" + mamuteBehaviour.dano;
            LuckTXT.text = "" + mamuteBehaviour.sorte;
            resistTXT.text = "" + mamuteBehaviour.resistencia;

            iconPersonagem.sprite = mamuteSprite;


        }

        else if (battleController.monstroAtivo == "Peixe")
        {
            currentLife = peixeBehaviour.battleLife;
            totalLife = peixeBehaviour.vida;
            currentLifeLabel.text = "" + currentLife;
            totalLifeLabel.text = "" + totalLife;

            damageTXT.text = "" + peixeBehaviour.dano;
            LuckTXT.text = "" + peixeBehaviour.sorte;
            resistTXT.text = "" + peixeBehaviour.resistencia;
            iconPersonagem.sprite = peixeSprite;

        }

        percentual = escalaTotal / totalLife;

    }
	
	// Update is called once per frame
	void Update () {

        if (battleController.monstroAtivo == "Aguia")
        {
            currentLife = aguiaBehaviour.battleLife;
            totalLife = aguiaBehaviour.vida;
            currentLifeLabel.text = "" + currentLife;
            totalLifeLabel.text = "" + totalLife;
        }
        else if (battleController.monstroAtivo == "Mamute")
        {
            currentLife = mamuteBehaviour.battleLife;
            totalLife = mamuteBehaviour.vida;
            currentLifeLabel.text = "" + currentLife;
            totalLifeLabel.text = "" + totalLife;

        }
        else if (battleController.monstroAtivo == "Peixe")
        {
            currentLife = peixeBehaviour.battleLife;
            totalLife = peixeBehaviour.vida;
            currentLifeLabel.text = "" + currentLife;
            totalLifeLabel.text = "" + totalLife;
        }

            barraVida.gameObject.transform.localScale = new Vector3((percentual * currentLife), 1,1);

    }
}
