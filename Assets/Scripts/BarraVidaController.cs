using UnityEngine;
using System.Collections;

public class BarraVidaController : MonoBehaviour {

    public LaboratorioController laboratorioController;
    public float totalLife = 100;
    public float escalaTotal = 1;
    public float percentual;

 

    public GameObject barraVida, barraDano, barraResistencia, BarraSorte;
    public float currentLife, currentDamage, currentResist, currentLuck;

    // Use this for initialization
    void Start () {
        
       
        percentual = escalaTotal / totalLife;
        
	}
	
	// Update is called once per frame
	

    public void UpdateBar(float vida, float dano, float resist, float luck)
    {
        currentLife = vida;
        currentDamage = dano;
        currentResist = resist;
        currentLuck = luck;
        barraVida.gameObject.transform.localScale = new Vector3(1, 1, (percentual * currentLife));
        barraDano.gameObject.transform.localScale = new Vector3(1, 1, (percentual * currentDamage));
        barraResistencia.gameObject.transform.localScale = new Vector3(1, 1, (percentual * currentResist));
        BarraSorte.gameObject.transform.localScale = new Vector3(1, 1, (percentual * currentLuck));

    }
}
