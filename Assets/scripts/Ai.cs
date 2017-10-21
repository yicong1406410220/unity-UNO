using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour {

    public Myrbyg[] myrbg;

    //public float speed = 1;

    GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = this.gameObject.GetComponent<GameController>();
        //InvokeRepeating("AiCard", 2, 1F);
        if(PlayerPrefs.HasKey("speed") == false)
        {
            PlayerPrefs.SetFloat("speed", 1f);
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        StartCoroutine(AiCard());
    }



    private IEnumerator AiCard()
    {
        for (int i = 1; i < 4; i++)
        {
            if (GameController.Bout == i && GameController.playing == 1)
            {
                GameController.playing = 0;
                yield return new WaitForSeconds(PlayerPrefs.GetFloat("speed"));
                gameController.BFSCard(i);
                //Debug.Log(GameController.Bout);
                break;
            }

        }
    }
}
