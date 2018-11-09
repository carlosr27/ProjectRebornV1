using UnityEngine;
using System.Collections;

public class goldScript : MonoBehaviour {

    public TextMesh coinTXT, coinTXTShadow;
    public ItensController itensController;

	// Use this for initialization
	void Start () {

        itensController = GameObject.Find("Itens").GetComponent<ItensController>();

        coinTXT.text = ""+itensController.coin;
        coinTXTShadow.text = "" + itensController.coin;

    }
	
	public void AttGold()
    {
        coinTXT.text = "" + itensController.coin;
        coinTXTShadow.text = "" + itensController.coin;
    }
}
