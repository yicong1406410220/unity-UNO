using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

    public List<card> dPlie = new List<card>();

    SpriteRenderer Gs;

    public mycard mc;

    public card upcard;

    // Use this for initialization
    void Start () {
        Gs = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        int f = dPlie.Count - 1;
        if (f >= 0)
        {
            Gs.sprite = mc.cimger[(int)dPlie[f]];
            upcard = dPlie[f];
        }
        
        
	}
}
