using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainclik : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray,out hit,100))
            {
                if (hit.collider.tag == "card" && hit.collider.gameObject.GetComponent<mycard>().back == false)
                {
                    mycard cardf = hit.collider.gameObject.GetComponent<mycard>();
                    Transform f = hit.collider.gameObject.transform;
                    //Debug.Log(hit.collider.gameObject.GetComponent<mycard>().pro.ToString());
                    if (cardf.Click == false)
                    {
                        f.position = new Vector3(f.position.x, f.position.y + 0.3f, 0);
                        cardf.Click = true;
                    }
                    else
                    {
                        f.position = new Vector3(f.position.x, f.position.y - 0.3f, 0);
                        cardf.Click = false;
                    }

                }
            }

        }

    }
}
