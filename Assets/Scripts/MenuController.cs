using UnityEngine;
using System.Collections;

//Esta classe é um tipo de classe individual para cada cena... Ela só muda os estados da propria cena



public class MenuController : MonoBehaviour {

    

    //Metodo do botão do Menu, Laboratorio (Direciona ao Laboratorio)
    public void button_Laboratorio()
    {
        Application.LoadLevel("LABORATORIO");
    }

    //Metodo do botão Historia, que direciona a cena Historia
    public void button_Historia()
    {
        Application.LoadLevel("HISTORIA");
    }

    //Metodo do botão Creditos que direciona a cena Creditos
    public void button_Creditos()
    {
        Application.LoadLevel("CREDITOS");
    }

    //Metodo Botão sair
    public void button_Sair()
    {
        
    }
	
}
