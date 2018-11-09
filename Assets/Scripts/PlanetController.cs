using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

    public bool view;
	
	void Start () {

        view = false; ;

	}
	
	// Update is called once per frame
	void Update () {

        mov();
	
	}

    void mov()
    {
        if (view)
        {
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Rotate(0, -1, -1);
            }

            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Rotate(0, -1, 1);
            }

            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Rotate(0, 1, 1);
            }

            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Rotate(0, 1, -1);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.Rotate(0, -1, 0);
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.Rotate(0, 1, 0);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                this.gameObject.transform.Rotate(0, 0, 1);
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                this.gameObject.transform.Rotate(0, 0, -1);
            }

        }
        else
        {

        }
    }
}
