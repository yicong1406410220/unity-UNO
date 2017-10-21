using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ccw : MonoBehaviour {

    public Texture[] spin;

    RawImage rawimger;
    // Use this for initialization
    void Start () {
        rawimger = gameObject.GetComponent<RawImage>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameController.playOrder)
        {
            rawimger.texture = spin[0];
        }
        else
        {
            rawimger.texture = spin[1];
        }
       

		
	}
}
