using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour
{

    private GameObject Aguia, Peixe, Mamute, Aguia2, Peixe2, Mamute2, Enemy, DamageTxt;
    public GameObject battleController;
    public bool enemyRoundDone; int dano;
    // Use this for initialization
    void Start()
    {
        enemyRoundDone = false;
        Aguia = GameObject.Find("Aguia"); Peixe = GameObject.Find("Peixe"); Mamute = GameObject.Find("Mamute");
        Aguia2 = GameObject.Find("Aguia2(Clone)"); Peixe2 = GameObject.Find("Peixe2(Clone)"); Mamute2 = GameObject.Find("Mamute2(Clone)");
        Enemy = GameObject.Find("Enemy"); DamageTxt = GameObject.Find("DamageTxt");


        DamageTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void DanoAtk()
    {
        if (enemyRoundDone == false)
        {
            if (GetComponent<BattleController>().monstroAtivo == "Aguia")
            {
                if (GetComponent<BattleController>().penaltyAtk == 0)
                {

                    /*dano = Aguia.GetComponent<AguiaBehaviour>().dano -
                    Aguia.GetComponent<AguiaBehaviour>().sorte +
                    Enemy.GetComponent<UIEnemy>().resistencia; */
                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyAtk > 0)
                {
                    /* dano = (Aguia.GetComponent<AguiaBehaviour>().dano / GetComponent<BattleController>().penaltyAtk) -
                             (Aguia.GetComponent<AguiaBehaviour>().sorte / GetComponent<BattleController>().penaltyAtk) +
                             (Enemy.GetComponent<UIEnemy>().resistencia / GetComponent<BattleController>().penaltyAtk); */
                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;


                }
            }
            else if (GetComponent<BattleController>().monstroAtivo == "Peixe")
            {
                if (GetComponent<BattleController>().penaltyAtk == 0)
                {

                    /*dano = Peixe.GetComponent<PeixeBehaviour>().dano -
                    Peixe.GetComponent<PeixeBehaviour>().sorte +
                    Enemy.GetComponent<UIEnemy>().resistencia; */

                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyAtk > 0)
                {
                    /*dano = (Peixe.GetComponent<PeixeBehaviour>().dano / GetComponent<BattleController>().penaltyAtk) -
                        (Peixe.GetComponent<PeixeBehaviour>().sorte / GetComponent<BattleController>().penaltyAtk) +
                            (Enemy.GetComponent<UIEnemy>().resistencia / GetComponent<BattleController>().penaltyAtk);*/

                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;


                }
            }
            else if (GetComponent<BattleController>().monstroAtivo == "Mamute")
            {
                if (GetComponent<BattleController>().penaltyAtk == 0)
                {

                    /* dano = Mamute.GetComponent<MamuteBehaviour>().dano -
                         Mamute.GetComponent<MamuteBehaviour>().sorte +
                             Enemy.GetComponent<UIEnemy>().resistencia;*/

                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyAtk > 0)
                {
                    /*ano = (Mamute.GetComponent<MamuteBehaviour>().dano / GetComponent<BattleController>().penaltyAtk) -
                         (Mamute.GetComponent<MamuteBehaviour>().sorte / GetComponent<BattleController>().penaltyAtk) +
                             (Enemy.GetComponent<UIEnemy>().resistencia / GetComponent<BattleController>().penaltyAtk);*/

                    dano = 100;
                    Enemy.GetComponent<UIEnemy>().enemyLife = Enemy.GetComponent<UIEnemy>().enemyLife - dano;


                }
            }

            enemyRoundDone = true;
        }
    }


    public void DanoDef()
    {
        if (enemyRoundDone == false)
        {
            if (GetComponent<BattleController>().monstroAtivo == "Aguia")
            {
                if (GetComponent<BattleController>().penaltyDef == 0)
                {
                    /*  dano = Enemy.GetComponent<UIEnemy>().forca - Enemy.GetComponent<UIEnemy>().sorte +
                      Aguia.GetComponent<AguiaBehaviour>().resistencia;*/
                    dano = 100;
                    Aguia.GetComponent<AguiaBehaviour>().battleLife = Aguia.GetComponent<AguiaBehaviour>().battleLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyDef > 0)
                {

                    /*  dano = (Enemy.GetComponent<UIEnemy>().forca / GetComponent<BattleController>().penaltyDef) -
                          (Enemy.GetComponent<UIEnemy>().sorte / GetComponent<BattleController>().penaltyDef) +
                          (Aguia.GetComponent<AguiaBehaviour>().resistencia / GetComponent<BattleController>().penaltyDef);*/
                    dano = 100;
                    Aguia.GetComponent<AguiaBehaviour>().battleLife = Aguia.GetComponent<AguiaBehaviour>().battleLife - dano;

                }

            }
            else if (GetComponent<BattleController>().monstroAtivo == "Peixe")
            {
                if (GetComponent<BattleController>().penaltyDef == 0)
                {
                    /* dano = Enemy.GetComponent<UIEnemy>().forca - Enemy.GetComponent<UIEnemy>().sorte +
                         Peixe.GetComponent<PeixeBehaviour>().resistencia;*/
                    dano = 100;
                    Peixe.GetComponent<PeixeBehaviour>().battleLife = Peixe.GetComponent<PeixeBehaviour>().battleLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyDef > 0)
                {

                    /*  dano = (Enemy.GetComponent<UIEnemy>().forca / GetComponent<BattleController>().penaltyDef) -
                          (Enemy.GetComponent<UIEnemy>().sorte / GetComponent<BattleController>().penaltyDef) +
                              (Peixe.GetComponent<PeixeBehaviour>().resistencia / GetComponent<BattleController>().penaltyDef);*/
                    dano = 100;
                    Peixe.GetComponent<PeixeBehaviour>().battleLife = Peixe.GetComponent<PeixeBehaviour>().battleLife - dano;

                }

            }
            else if (GetComponent<BattleController>().monstroAtivo == "Mamute")
            {
                if (GetComponent<BattleController>().penaltyDef == 0)
                {
                    /*dano = Enemy.GetComponent<UIEnemy>().forca - Enemy.GetComponent<UIEnemy>().sorte +
                        Mamute.GetComponent<MamuteBehaviour>().resistencia;*/
                    dano = 100;
                    Mamute.GetComponent<MamuteBehaviour>().battleLife = Mamute.GetComponent<MamuteBehaviour>().battleLife - dano;

                }
                else if (GetComponent<BattleController>().penaltyDef > 0)
                {

                    /*dano = (Enemy.GetComponent<UIEnemy>().forca / GetComponent<BattleController>().penaltyDef) -
                        (Enemy.GetComponent<UIEnemy>().sorte / GetComponent<BattleController>().penaltyDef) +
                            (Mamute.GetComponent<MamuteBehaviour>().resistencia / GetComponent<BattleController>().penaltyDef);*/
                    dano = 100;
                    Mamute.GetComponent<MamuteBehaviour>().battleLife = Mamute.GetComponent<MamuteBehaviour>().battleLife - dano;

                }

            }

            DamageTxt.SetActive(true);
            DamageTxt.GetComponent<TextMesh>().text = dano.ToString();
            enemyRoundDone = true;
        }
    }



}
