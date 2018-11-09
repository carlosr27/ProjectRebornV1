using UnityEngine;
using System.Collections;

public class BattleAIBehaviour : MonoBehaviour
{
    //Acha os gameObejects dos inimigos e do jogador
    private GameObject battleController, Aguia, Peixe, Mamute, enemy, Aguia2, Peixe2, Mamute2;
    // essa string para verificar qual inimigo esta ativo.
    // string para verificar se o ataque foi bem sucedido ou nao.
    public string inimigoAtivo;
    public int lastAtk, lastDef;



    // Use this for initialization
    void Start()
    {


        battleController = GameObject.Find("BattleController"); enemy = GameObject.Find("Enemy");
        Aguia2 = GameObject.Find("Aguia2(Clone)"); Peixe2 = GameObject.Find("Peixe2(Clone)");
        Mamute2 = GameObject.Find("Mamute2(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        Aguia = GameObject.Find("Aguia"); Peixe = GameObject.Find("Peixe"); Mamute = GameObject.Find("Mamute");

        if (Peixe2 == null && Aguia2 == null) { inimigoAtivo = "Mamute"; }
        if (Aguia2 == null && Mamute2 == null) { inimigoAtivo = "Peixe"; }
        if (Mamute2 == null && Peixe2 == null) { inimigoAtivo = "Aguia"; }

        // aqui verifica qul funcao deve chamar comparada a variavel PrimeiroJogador, ou seja se for true sera a vez de defender e se for false devera atacr

        if (battleController.GetComponent<BattleController>().primeiroJogador == true
            && battleController.GetComponent<BattleController>().pressButton == false
            && battleController.GetComponent<BattleController>().pressletters == false
            )
        {
            defender();

        }
        else if (battleController.GetComponent<BattleController>().primeiroJogador == false
                   && battleController.GetComponent<BattleController>().pressButton == false
                   && battleController.GetComponent<BattleController>().pressletters == false
                   )
        {
            attack();
        }

        if (lastAtk != 0 && battleController.GetComponent<BattleController>().defPress != 0
            && battleController.GetComponent<BattleController>().penaltyDef <= 2)
        {
            if (lastAtk == 1 && battleController.GetComponent<BattleController>().defPress == 3 ||
               lastAtk == 2 && battleController.GetComponent<BattleController>().defPress == 4)
            {
                battleController.GetComponent<BattleController>().penaltyDef = battleController.GetComponent<BattleController>().penaltyDef + 2;
            }
        }
        else if (lastDef != 0 && battleController.GetComponent<BattleController>().atkPress != 0
                 && battleController.GetComponent<BattleController>().penaltyAtk <= 2)
        {
            if (lastDef == 3 && battleController.GetComponent<BattleController>().atkPress == 1 ||
                lastDef == 4 && battleController.GetComponent<BattleController>().atkPress == 2)
            {
                battleController.GetComponent<BattleController>().penaltyAtk = battleController.GetComponent<BattleController>().penaltyAtk + 2;
            }
        }

    }

    // tanto na ataque quanto na defesa o primeiro round devera ser um sorteio pra saber qual ataque ou defesa o inimigo fara
    // apos o primeiro round sera avaliado o que o jogador fez, qual ataque ele utilizou e etc
    // dependendo das escolhas o inimigo verificara qual e a melhor jogada nessa rodada.

    public void defender()
    {

        if (battleController.GetComponent<BattleController>().round == 1
            && battleController.GetComponent<BattleController>().pressButton == false)
        {
            int raffle;
            raffle = Random.Range(1, 10);
            if (raffle >= 1 && raffle <= 5)
            {
                enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 3);
                lastDef = 3;
            }
            else
            {
                enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 4);
                lastDef = 4;
            }


        }




        if (battleController.GetComponent<BattleController>().round > 1
            && battleController.GetComponent<BattleController>().pressButton == false
            && battleController.GetComponent<BattleController>().timerToPlay <= 2.9f)
        {
            if (battleController.GetComponent<BattleController>().atk1 > battleController.GetComponent<BattleController>().atk2)
            {
                int raffle;
                raffle = Random.Range(1, 15);
                if (raffle >= 1 && raffle <= 6 || raffle > 10 && raffle <= 15)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 3);
                    lastDef = 3;
                }
                else if (raffle >= 7 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 4);
                    lastDef = 4;
                }



            }

            else if (battleController.GetComponent<BattleController>().atk1 < battleController.GetComponent<BattleController>().atk2)
            {
                int raffle;
                raffle = Random.Range(1, 15);
                if (raffle >= 7 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 3);
                    lastDef = 3;
                }
                else if (raffle >= 1 && raffle <= 6 || raffle > 10 && raffle <= 15)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 4);
                    lastDef = 4;
                }


            }

            else if (battleController.GetComponent<BattleController>().atk1 == battleController.GetComponent<BattleController>().atk2)
            {
                int raffle;
                raffle = Random.Range(1, 10);
                if (raffle >= 1 && raffle <= 5)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 3);
                    lastDef = 3;
                }
                else if (raffle >= 6 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 4);
                    lastDef = 4;
                }


            }
        }

        battleController.GetComponent<DamageController>().DanoAtk();

    }





    public void attack()
    {

        if (battleController.GetComponent<BattleController>().round == 1 && battleController.GetComponent<BattleController>().pressButton == false
             )
        {
            int raffle;
            raffle = Random.Range(1, 10);
            if (raffle >= 1 && raffle <= 5)
            {
                enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 1); lastAtk = 1;
            }
            else
            {
                enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 2); lastAtk = 2;
            }


        }



        if (battleController.GetComponent<BattleController>().round > 1 && battleController.GetComponent<BattleController>().pressButton == false
            && battleController.GetComponent<BattleController>().timerToPlay <= 2.7f)
        {
            if (battleController.GetComponent<BattleController>().def1 > battleController.GetComponent<BattleController>().def2)
            {
                int raffle;
                raffle = Random.Range(1, 15);
                if (raffle >= 1 && raffle <= 6 || raffle > 10 && raffle <= 15)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 1);
                    lastAtk = 1;
                }
                else if (raffle >= 7 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 2);
                    lastAtk = 2;
                }
            }
            else if (battleController.GetComponent<BattleController>().def1 < battleController.GetComponent<BattleController>().def2)
            {
                int raffle;
                raffle = Random.Range(1, 15);
                if (raffle >= 7 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 1);
                    lastAtk = 1;
                }
                else if (raffle >= 1 && raffle <= 6 || raffle > 10 && raffle <= 15)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 2);
                    lastAtk = 2;
                }
            }
            else if (battleController.GetComponent<BattleController>().def1 == battleController.GetComponent<BattleController>().def2)
            {
                int raffle;
                raffle = Random.Range(1, 10);
                if (raffle >= 1 && raffle <= 5)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 1);
                    lastAtk = 1;
                }
                else if (raffle >= 6 && raffle <= 10)
                {
                    enemy.GetComponent<UIEnemy>().AnimEnemy.SetInteger("animCondition", 2);
                    lastAtk = 2;
                }
            }
        }

        battleController.GetComponent<DamageController>().DanoDef();

    }


}
