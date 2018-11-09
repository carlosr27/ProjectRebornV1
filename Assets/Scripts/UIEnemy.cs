using UnityEngine;
using System.Collections;

public class UIEnemy : MonoBehaviour {

	// variavel para achar o game object, serve para setar o inimigo
	public GameObject enemy;
	// acha os prefabs dos inimigos para setar na funcao
	private GameObject Aguia2, Peixe2, Mamute2, battleController;
	// acha o animator do inimigo
	public Animator AnimEnemy;
	// acha os game objects dos inimigos
	public Object bird, mamute, fish;
	// sorteio do inimigo q sera instanciado
	public int sorteioEnemy, enemyLife;
    public int forca, sorte, resistencia;


	// Use this for initialization
	void Start () {
		if (!battleController == GameObject.Find ("BattleController")) {battleController = GameObject.Find ("BattleController");}
		enemyLife = 100;

		sorteioEnemy = Random.Range(1 , 60);
		if (sorteioEnemy >= 1 && sorteioEnemy <= 20) 
		{
			InstanceBird();
		} else if (sorteioEnemy >= 21 && sorteioEnemy <= 40) 
		{
			InstanceMamute();
		} else if (sorteioEnemy >= 41 && sorteioEnemy <= 60) 
		{
			InstanceFish();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(!AnimEnemy.GetCurrentAnimatorStateInfo(0).IsName("Iddle"))
		{
			AnimEnemy.SetInteger("animCondition", 0);
		}	
	}
		

	public void InstanceBird()
	{
		enemy = GameObject.Instantiate (bird) as GameObject; 
		enemy.gameObject.transform.position = new Vector3 (75.31f, 15, 47.59f);
		enemy.gameObject.transform.localScale = new Vector3(1, 1, 1);
        enemy.gameObject.transform.rotation = Quaternion.Euler (1, 280f, 0);
		forca = 20; sorte = 28; resistencia = 24;
		AnimEnemy = enemy.GetComponent<Animator> ();
		AnimEnemy.SetBool ("animTrigger", true);
	}

	public void InstanceMamute()
	{
		enemy = GameObject.Instantiate (mamute) as GameObject; 
		enemy.gameObject.transform.position = new Vector3 (74.38f, 15, 47.59f);
		enemy.gameObject.transform.localScale = new Vector3(10.52279f, 10.52279f, 10.52279f);
        forca = 36; sorte = 12; resistencia = 30;
        enemy.gameObject.transform.rotation = Quaternion.Euler (0.9999996f, 80.84277f, 2.134759e-07f);
		AnimEnemy = enemy.GetComponent<Animator> ();
		AnimEnemy.SetBool ("animTrigger", true);
	}

	public void InstanceFish()
	{
		enemy = GameObject.Instantiate (fish) as GameObject; 
		enemy.gameObject.transform.position = new Vector3 (74.73f, 15.51f, 49.17f);
		enemy.gameObject.transform.localScale = new Vector3(5.686542f, 5.686542f, 5.686542f);
        enemy.gameObject.transform.rotation = Quaternion.Euler (1, 280f, 0);
        forca = 16; sorte = 40; resistencia = 3;
        AnimEnemy = enemy.GetComponent<Animator> ();
		AnimEnemy.SetBool ("animTrigger", true);
	}
}