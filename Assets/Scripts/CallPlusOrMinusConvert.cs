using UnityEngine;
using System.Collections;

public class CallPlusOrMinusConvert : MonoBehaviour {

    private LaboratorioController laboratorioController;

    void Start()
    {

        laboratorioController = GameObject.Find("LaboratorioController").GetComponent<LaboratorioController>();

    }

    public void CallMinusPlus()
    {
        laboratorioController.AttMinusPlus(this.gameObject);
    }
}
