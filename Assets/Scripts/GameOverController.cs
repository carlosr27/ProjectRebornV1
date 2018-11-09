using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

    private ItensController itensController;

    public GameObject Aguia, Mamute, Peixe;
    public GameObject HabAtk,HabDef;

    public TextMesh ouroTXT, ferroTXT, uranioTXT, bronzeTXT;

	// Use this for initialization
	void Start () {

        Aguia = GameObject.Find("Aguia");
        Peixe = GameObject.Find("Peixe");
        Mamute = GameObject.Find("Mamute");

        itensController = GameObject.Find("Itens").GetComponent<ItensController>();

        int ferro = Random.Range(1, 11);
        int ouro = Random.Range(1, 6);
        int uranio = Random.Range(0, 2);
        int bronze = Random.Range(1, 16);

        Debug.Log(ferro);
        Debug.Log(ouro);
        Debug.Log(uranio);
        Debug.Log(bronze);

        ouroTXT.text = "+" + ouro;
        ferroTXT.text = "+" + ferro;
        bronzeTXT.text = "+" + bronze;
        uranioTXT.text = "+" + uranio;

        itensController.ouro += ouro;
        itensController.ferro += ferro;
        itensController.uranio += uranio;
        itensController.bronze += bronze;

    }
	
	public void GotoLab()
    {

        Aguia.GetComponent<AguiaBehaviour>().AguiaPrefab.SetActive(true);
        Mamute.GetComponent<MamuteBehaviour>().MamutePrefab.SetActive(true);
        Peixe.GetComponent<PeixeBehaviour>().peixePrefab.SetActive(true);

        Peixe.GetComponent<PeixeBehaviour>().UI.SetActive(true);
        Aguia.GetComponent<AguiaBehaviour>().UI.SetActive(true);
        Mamute.GetComponent<MamuteBehaviour>().UI.SetActive(true);

        //Desativar UIS
        Aguia.GetComponent<AguiaBehaviour>().HabAtk.SetActive(true);
        Aguia.GetComponent<AguiaBehaviour>().HabDef.SetActive(true);

        Mamute.GetComponent<MamuteBehaviour>().HabAtk.SetActive(true);
        Mamute.GetComponent<MamuteBehaviour>().HabDef.SetActive(true);

        Peixe.GetComponent<PeixeBehaviour>().HabAtk.SetActive(true);
        Peixe.GetComponent<PeixeBehaviour>().HabDef.SetActive(true);

        Peixe.GetComponent<PeixeBehaviour>().load = false;
        Aguia.GetComponent<AguiaBehaviour>().load = false;
        Mamute.GetComponent<MamuteBehaviour>().load = false;

        Application.LoadLevel("LABORATORIO");

    }
}
