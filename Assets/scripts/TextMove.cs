using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMove : MonoBehaviour {

    public Text mytext;

    public int speed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if(transform.position.x < -14)
        {
            Destroy(this.gameObject);
        }
	}
}
