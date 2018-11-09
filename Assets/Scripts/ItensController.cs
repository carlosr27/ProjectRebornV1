using UnityEngine;
using System.Collections;

public class ItensController : MonoBehaviour {

    public static ItensController itensController;

    public int ferro, ouro, uranio, bronze, prata;
    public int coin;

	// Use this for initialization
	void Start () {


        if (itensController == null)
        {
            DontDestroyOnLoad(gameObject);
            itensController = this;
        }
        else if (itensController != this)
        {
            Destroy(gameObject);
        }

        
        ferro = 1; ouro = 1; uranio = 1; bronze = 1;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName == "LABORATORIO")
        {

        }
	
	}
}
