using UnityEngine;
using System.Collections;

public class UIAtacarDefender : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("finish"))
        {
            Destroy(this.gameObject);
        }
	
	}
}
